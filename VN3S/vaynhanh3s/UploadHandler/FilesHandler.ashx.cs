using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using vaynhanh3s.UploadHandler;

namespace vaynhanh3s.UploadHandler
{
    public class FilesHandler : IHttpHandler
    {

        private readonly JavaScriptSerializer _js;
        private string storeLocation;
        private string relativePath = ConfigurationManager.AppSettings["BaseWebsiteUrl"].ToString() + "/Upload/Images/";
        private string StorageRoot
        {
            get { return storeLocation; } //Path should! always end with '/'
        }

        public FilesHandler()
        {
            var defaultUploadLocation = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/Images/"));
            var webStoreLocation = HttpContext.Current.Server.MapPath("~");
            storeLocation = defaultUploadLocation;

            _js = new JavaScriptSerializer { MaxJsonLength = 41943040 };
        }

        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Pragma", "no-cache");
            context.Response.AddHeader("Cache-Control", "private, no-cache");

            HandleMethod(context);
        }

        // Handle request based on method
        private void HandleMethod(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "HEAD":
                case "GET":
                    if (GivenFilename(context)) DeliverFile(context);
                    //else ListCurrentFiles(context);
                    break;

                case "POST":
                case "PUT":
                    UploadFile(context);
                    break;

                case "DELETE":
                    DeleteFile(context);
                    break;

                case "OPTIONS":
                    ReturnOptions(context);
                    break;

                default:
                    context.Response.ClearHeaders();
                    context.Response.StatusCode = 405;
                    break;
            }
        }

        private static void ReturnOptions(HttpContext context)
        {
            context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
            context.Response.StatusCode = 200;
        }

        // Delete file from the server
        private void DeleteFile(HttpContext context)
        {
            var filePath = StorageRoot + context.Request["f"];
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        // Upload file to the server
        private void UploadFile(HttpContext context)
        {
            var statuses = new List<FilesStatus>();
            var headers = context.Request.Headers;
            try
            {
                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(context, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], context, statuses);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            WriteJsonIframeSafe(context, statuses);
        }

        // Upload partial file
        private void UploadPartialFile(string fileName, HttpContext context, List<FilesStatus> statuses)
        {
            if (context.Request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var inputStream = context.Request.Files[0].InputStream;
            var fullName = StorageRoot + Path.GetFileName(fileName);

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new FilesStatus(new FileInfo(fullName)));
        }

        // Upload entire file
        private void UploadWholeFile(HttpContext context, List<FilesStatus> statuses)
        {
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                var file = context.Request.Files[i];
                //var query = from f in files
                //            where f.name == file.FileName 
                //            select f;
                var fullFilename = file.FileName;
                var extension = "";
                var fileName = "";

                if (fullFilename.IndexOf('.') > 0)
                {
                    fileName = fullFilename.Substring(0, fullFilename.LastIndexOf('.'));
                    if (fileName.Length >= 120)
                        fileName = fileName.Substring(0, 60);
                    extension = fullFilename.Substring(fullFilename.LastIndexOf('.'));
                }
                //if (query.ToArray().Length > 0)
                fileName = fileName + "_" + Guid.NewGuid() + extension;

                var fullPath = storeLocation + Path.GetFileName(fileName);

                var maxWidthHeight = 2048;
                var img = new WebImage(file.InputStream);
                if (img.Width > maxWidthHeight || img.Height > maxWidthHeight)
                    img.Resize(maxWidthHeight, maxWidthHeight, true, false);

                img.Save(fullPath);

                //string fullName = Path.GetFileName(fileName);
                statuses.Add(new FilesStatus(fullFilename, file.ContentLength, fullPath, relativePath + Path.GetFileName(fileName)));
            }
        }

        private void WriteJsonIframeSafe(HttpContext context, List<FilesStatus> statuses)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else
                    context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }
            var objs = new { files = statuses };
            var jsonObj = _js.Serialize(objs);
            context.Response.Write(jsonObj);
        }

        private static bool GivenFilename(HttpContext context)
        {
            return !string.IsNullOrEmpty(context.Request["f"]);
        }

        //private void DeliverFile(HttpContext context)
        //{
        //    if (HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        var fullFileName = context.Request["f"];
        //        var extension = fullFileName.Substring(fullFileName.LastIndexOf('.')).Trim();
        //        var filename = fullFileName.Substring(fullFileName.IndexOf('_') + 1, (fullFileName.LastIndexOf('_') - fullFileName.IndexOf('_') - 1)).Trim();

        //        var filePath = StorageRoot + fullFileName;

        //        if (File.Exists(filePath))
        //        {
        //            context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + extension + "\"");
        //            context.Response.ContentType = "application/octet-stream";
        //            context.Response.ClearContent();
        //            context.Response.WriteFile(filePath);
        //        }
        //        else
        //            context.Response.StatusCode = 404;
        //    }
        //    else
        //        context.Response.StatusCode = 401;
        //}

        private void DeliverFile(HttpContext context)
        {
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            var fullFileName = context.Request["f"];
            var type = context.Request["t"] != null ? int.Parse(context.Request["t"]) : 0;
            var extension = fullFileName.Substring(fullFileName.LastIndexOf('.')).Trim();
            var filename = fullFileName.Substring(fullFileName.IndexOf('=') + 1, (fullFileName.LastIndexOf('_') - fullFileName.IndexOf('=') - 1)).Trim();
            string filePath = "";

            filePath = fullFileName;

            if (File.Exists(filePath))
            {
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal), filename.Length - filename.LastIndexOf("\\", StringComparison.Ordinal));

                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + extension + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(filePath);
            }
            else
            {
                context.Response.StatusCode = 404;
                context.Response.Redirect("~/Error/Error404");
            }
            //}
            //else
            //{
            //    context.Response.StatusCode = 401;
            //    context.Response.Redirect("~/Error/Error404");
            //}
        }

        private void ListCurrentFiles(HttpContext context)
        {
            var files =
                new DirectoryInfo(StorageRoot)
                    .GetFiles("*", SearchOption.TopDirectoryOnly)
                    .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                    .Select(f => new FilesStatus(f))
                    .ToArray();
            string jsonObj = _js.Serialize(files);
            context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
            context.Response.Write(jsonObj);
            context.Response.ContentType = "application/json";
        }

    }
}
using System;
using System.IO;

namespace vaynhanh3s.UploadHandler
{
    public class FilesStatus
    {
        public const string HandlerPath = "/UploadHandler/";

        public string group { get; set; }
        public string name { get; set; }
        public string fullpath { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string progress { get; set; }
        public string url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_url { get; set; }
        public string delete_type { get; set; }
        public string error { get; set; }

        public FilesStatus() { }

        public FilesStatus(FileInfo fileInfo) { SetValues(fileInfo.Name, (int)fileInfo.Length, fileInfo.FullName); }

        public FilesStatus(string fileName, int fileLength, string fullPath) { SetValues(fileName, fileLength, fullPath); }

        public FilesStatus(string fileName, int fileLength, string fullPath, string url) { SetValues(fileName, fileLength, fullPath, url); }

        private void SetValues(string fileName, int fileLength, string fullPath, string url)
        {
            name = fileName;
            size = fileLength;
            progress = "1.0";
            //url = HandlerPath + "FilesHandler.ashx?f=" + fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
            //delete_url = HandlerPath + "FilesHandler.ashx?f=" + fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
            //url = HandlerPath + "FilesHandler.ashx?f=" + fullPath;
            url = url;
            delete_url = HandlerPath + "FilesHandler.ashx?f=" + fullPath;
            delete_type = "DELETE";
            fullpath = url;
            var ext = Path.GetExtension(fullPath);

            var fileSize = ConvertBytesToMegabytes(new FileInfo(fullPath).Length);
            if (fileSize > 3 || !IsImage(ext)) thumbnail_url = "/Content/img/generalFile.png";
            else thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath);
        }

        private void SetValues(string fileName, int fileLength, string fullPath)
        {
            name = fileName;
            type = "image/png";
            size = fileLength;
            progress = "1.0";
            //url = HandlerPath + "FilesHandler.ashx?f=" + fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
            //delete_url = HandlerPath + "FilesHandler.ashx?f=" + fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
            url = HandlerPath + "FilesHandler.ashx?f=" + fullPath;
            delete_url = HandlerPath + "FilesHandler.ashx?f=" + fullPath;
            delete_type = "DELETE";
            fullpath = fullPath;
            var ext = Path.GetExtension(fullPath);

            var fileSize = ConvertBytesToMegabytes(new FileInfo(fullPath).Length);
            if (fileSize > 3 || !IsImage(ext)) thumbnail_url = "/Content/img/generalFile.png";
            else thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath);
        }

        private bool IsImage(string ext)
        {
            return ext == ".gif" || ext == ".jpg" || ext == ".png";
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
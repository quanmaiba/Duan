using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using University.Web.Models;
using University.Web.Models.Lop;

namespace University.Web.Controllers
{
    public class LopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LuuLop([FromBody] LuuLop model)
        {
            var luuLopResult = new LuuLopRes() {
                Message = "Lỗi, vui lòng thử lại.",
                Result = 0
            };
            try 
            {
                var url = $"{Common.Common.ApiUrl}/lop/LuuLop";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(model);
                    streamWrite.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resKetQua = streamReader.ReadToEnd();
                    luuLopResult = JsonConvert.DeserializeObject<LuuLopRes>(resKetQua);
                }
                if (luuLopResult.Result > 0)
                {
                    return new JsonResult(new { status = 1, message = luuLopResult.Message });
                }
            }
            catch(Exception ex) 
            { }
            return new JsonResult(new { status = 0, message = luuLopResult.Message });

        }

        public IActionResult LayDanhSachLop()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                var danhSachLop = new List<LopItem>();
                var url = $"{Common.Common.ApiUrl}/Lop/LayDanhSachLop";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                var response = httpWebRequest.GetResponse();
                {
                    string responseData;
                    Stream responseStream = response.GetResponseStream();
                    try
                    {
                        StreamReader streamReader = new StreamReader(responseStream);
                        try
                        {
                            responseData = streamReader.ReadToEnd();
                        }
                        finally
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                    finally
                    {
                        ((IDisposable)responseStream).Dispose();
                    }
                    danhSachLop = JsonConvert.DeserializeObject<List<LopItem>>(responseData);
                }
                var customerData = danhSachLop;

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var property = GetProperty(sortColumn);
                    if (sortColumnDirection == "asc")
                    {
                        customerData = customerData.OrderBy(property.GetValue).ToList();
                    }
                    else
                    {
                        customerData = customerData.OrderByDescending(property.GetValue).ToList();
                    }
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.TenLop.ToLower().Contains(searchValue.ToLower())).ToList();
                }

                //total number of rows count   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    status = -1,
                    message = "Something went wrong, please contact administrator."
                });
            }
        }

        private PropertyInfo GetProperty(string columnName)
        {
            var properties = typeof(LopItem).GetProperties();
            PropertyInfo prop = null;
            foreach (var property in properties)
            {
                if (property.Name.ToLower().Equals(columnName.ToLower()))
                {
                    prop = property;
                    break;
                }
            }
            return prop;
        }
    }
}

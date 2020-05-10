using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLNV.Web.Models;
using QLNV.Web.Models.PhongBan;

namespace QLNV.Web.Controllers
{
    public class PhongBanController : Controller
    {
        public IActionResult Index()
        {
            var phongbans = new List<PhongBanView>();
            var url = $"{Common.Common.ApiUrl}/phongban/danhsachphongban";
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
                phongbans = JsonConvert.DeserializeObject<List<PhongBanView>>(responseData);
            }
            return View(phongbans);
        }

        public IActionResult TaoPhongBan()
        {
            TempData["ThanhCong"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult TaoPhongBan(TaoPhongBan model)
        {
            int ketQua = 0;
            var url = $"{Common.Common.ApiUrl}/phongban/taophongban";
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
                ketQua = int.Parse(resKetQua);
            }
            if(ketQua > 0)
            {
                TempData["ThanhCong"] = "Đã tạo phòng ban thành công";
            }
            ModelState.Clear();
            return View(new TaoPhongBan() { });
        }

        public IActionResult SuaPhongBan(int id)
        {
            var phongban = new SuaPhongBan();
            var url = $"{Common.Common.ApiUrl}/phongban/layphongban/{id}";
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
                phongban = JsonConvert.DeserializeObject<SuaPhongBan>(responseData);
            }
            TempData["ThanhCong"] = null;
            TempData["Loi"] = null;
            return View(phongban);
        }

        [HttpPost]
        public IActionResult SuaPhongBan (SuaPhongBan model)
        {
            int ketQua = 0;
            var url = $"{Common.Common.ApiUrl}/phongban/suaphongban";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resKetQua = streamReader.ReadToEnd();
                ketQua = int.Parse(resKetQua);
            }
            if (ketQua > 0)
            {
                TempData["ThanhCong"] = "Đã cập nhật phòng ban thành công";
                ModelState.Clear();
            }
            else
            {
                TempData["Loi"] = "Không thể cập nhật phòng ban";
            }
            return View(new SuaPhongBan() { });
        }

        public IActionResult XoaPhongBan(int id)
        {
            var ketQua = false;
            var url = $"{Common.Common.ApiUrl}/phongban/xoaphongban/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE";
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
                ketQua = JsonConvert.DeserializeObject<bool>(responseData);
            }
            return RedirectToAction("Index", "PhongBan");
        }
    }
}

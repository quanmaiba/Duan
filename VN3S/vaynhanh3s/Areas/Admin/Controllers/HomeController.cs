using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using vaynhanh3s.vnmon;
using vaynhanh3s.Domain.Request.Customer;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.Response.Customer;
using vaynhanh3s.Domain.TTEnum;

namespace vaynhanh3s.Areas.QuanTri.Controllers
{
    public class HomeController : BaseController
    {
        // GET: QuanTri/Home
        [CustomAuthorize(Quyen.QuanTri, Quyen.Xem)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Gets(IDataTablesRequest request, DateTime? tuNgay, DateTime? denNgay, bool? daXuatRaExcel, bool? updateExcel)
        {
            try
            {
                var result = (await _service.GetCustomers(new GetCustomers()
                {
                    DaXuatRaExcel = daXuatRaExcel,
                    TuNgay = tuNgay,
                    DenNgay = denNgay,
                    UpdateExcel = updateExcel
                })).Payload;

                var dtResult = new List<Customer>();

                var columns = request.Columns.Cast<IColumn>().ToArray();
                var searchValue = request.Search.Value;

                //if (!string.IsNullOrWhiteSpace(searchValue))
                //    dtResult = result.Where(c => c.Description.Contains(searchValue)).ToList();
                //else
                //    dtResult = result.ToList();
                dtResult = result.ToList();

                if (result != null && result.Any())
                {
                    var response = DataTablesResponse.Create(request, result.Count(), dtResult.Count, dtResult.Skip(request.Length * request.Start / request.Length).Take(request.Length));
                    return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
                }

                return new DataTablesJsonResult(DataTablesResponse.Create(request, 0, 0, new List<GetsResult>()), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }

        [HttpPost]
        public async Task<ActionResult> XuatExcel(DateTime? tuNgay, DateTime? denNgay, bool? daXuatRaExcel, bool? updateExcel)
        {
            try
            {
                var result = (await _service.GetCustomers(new GetCustomers()
                {
                    DaXuatRaExcel = daXuatRaExcel,
                    TuNgay = tuNgay,
                    DenNgay = denNgay,
                    UpdateExcel = updateExcel
                })).Payload;

                using (var pkg = new ExcelPackage())
                {

                    Response.ContentEncoding = Encoding.UTF8;

                    HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=DanhSachKhachHang_"+ DateTime.Now.ToString() +".xlsx");

                    if (result != null && result.Any())
                    {
                        var headerColor = ColorTranslator.FromHtml("#efefef");

                        var ws = pkg.Workbook.Worksheets.Add("Danh sách khách hàng");

                        ws.PrinterSettings.PaperSize = ePaperSize.A3;
                        ws.PrinterSettings.Orientation = eOrientation.Landscape;
                        ws.PrinterSettings.TopMargin = 0.75M;
                        ws.PrinterSettings.BottomMargin = 0.75M;
                        ws.PrinterSettings.LeftMargin = 0.25M;
                        ws.PrinterSettings.RightMargin = 0.25M;

                        ws.PrinterSettings.FitToPage = true;
                        ws.PrinterSettings.FitToWidth = 1;
                        ws.PrinterSettings.FitToHeight = 0;

                        var ridx = 1;
                        ws.Cells[ridx, 1].Value = "Danh sách khách hàng";
                        ws.Cells[ridx, 1].Style.Font.Size = 28;

                        ridx += 2;
                        var colNumber = 7;

                        for (var i = 1; i < colNumber; i++)
                        {
                            ws.Cells[ridx, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[ridx, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            ws.Cells[ridx, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Gray);
                            ws.Cells[ridx, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[ridx, i].Style.Fill.BackgroundColor.SetColor(headerColor);
                            ws.Cells[ridx, i].Style.WrapText = true;
                        }


                        ws.Cells[ridx, 1].Value = "Họ và tên";
                        ws.Cells[ridx, 2].Value = " Số điện thoại";
                        ws.Cells[ridx, 3].Value = "Số CMND";
                        ws.Cells[ridx, 4].Value = "Tỉnh thành";
                        ws.Cells[ridx, 5].Value = "Điều kiện vay";
                        ws.Cells[ridx, 6].Value = "Ngày đăng ký";

                        ridx++;

                        foreach (var item in result)
                        {
                           
                            ws.Cells[ridx, 1].Value = item.HoTen;
                            ws.Cells[ridx, 2].Value = item.SoDienThoai;
                            ws.Cells[ridx, 3].Value = item.SoCMND;
                            ws.Cells[ridx, 4].Value = item.TinhThanh;
                            ws.Cells[ridx, 5].Value = item.DieuKienVay;
                            ws.Cells[ridx, 6].Value = item.NgayDangKy;


                            borderCell(ws, ridx, 1, false);
                            borderCell(ws, ridx, 2, false);
                            borderCell(ws, ridx, 3, false);
                            borderCell(ws, ridx, 4, false);
                            borderCell(ws, ridx, 5, false);
                            borderCell(ws, ridx, 6, false);

                            ridx++;
                        }
                        ws.Column(1).Width = 25;
                        ws.Column(2).Width = 15;
                        ws.Column(3).Width = 15;
                        ws.Column(4).Width = 20;
                        ws.Column(5).Width = 40;
                        ws.Column(6).Width = 15;
                    }
                    else
                    {
                        var ws = pkg.Workbook.Worksheets.Add("Không có khách hàng thỏa điều kiện");
                        ws.Cells[1, 1].Value = "Không có khách hàng thỏa điều kiện";
                    }

                    return File(pkg.GetAsByteArray(), "application/vnd.ms-excel");
                }
            }
            catch (Exception ex)
            {
                return Json(new { code = -1, msg = Util.GeneralMessage.SomeThingWentWrong, ex });
            }
        }

        private void borderCell(ExcelWorksheet ws, int row, int columnCount, bool center)
        {
            for (var i = 1; i <= columnCount; i++)
            {
                ws.Cells[row, i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Gray);
                ws.Cells[row, i].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                ws.Cells[row, i].Style.WrapText = true;
                if (center)
                    ws.Cells[row, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }


    }
}
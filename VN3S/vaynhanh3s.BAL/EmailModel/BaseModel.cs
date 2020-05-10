using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.BAL.EmailModel
{
    public class BaseModel
    {
        public BaseModel()
        {
            CuaHangs = new List<CuaHang>();
        }

        public string BaseWebsiteURL { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public List<CuaHang> CuaHangs { get; set; }
    }

    public class CuaHang
    {
        public long Id { get; set; }
        public long IdCongTy { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string GhiChu { get; set; }
    }
}

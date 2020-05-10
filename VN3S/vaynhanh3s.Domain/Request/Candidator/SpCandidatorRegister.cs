using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.Domain.Request.Candidator
{
    public class SpCandidatorRegister
    {
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCMND { get; set; }
        public int TinhThanhId { get; set; }
        public int VitriId { get; set; }
    }
}

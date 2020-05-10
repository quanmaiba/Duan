using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.Domain.Request.Customer
{
    public class GetCustomers
    {
        public bool? DaXuatRaExcel { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public bool? UpdateExcel { get; set; }
    }
}

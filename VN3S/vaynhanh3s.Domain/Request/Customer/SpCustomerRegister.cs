﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaynhanh3s.Domain.Request.Customer
{
    public class SpCustomerRegister
    {
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCMND { get; set; }
        public int TinhThanhId { get; set; }
        public int DieuKienVayId { get; set; }
    }
}

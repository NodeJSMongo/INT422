using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Controllers
{
    public class PhoneBase
    {
        public PhoneBase()
        {
            DateReleased =DateTime.Now;
            PhoneName = "";
            Manufacturer = "";
        }
        public int Id { get; set; }
        public String PhoneName { get; set; }
        public String Manufacturer { get; set; }
        public DateTime DateReleased { get; set; }
        public int MSRP { get; set; }
        public double ScreenSize { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment4.Controllers
{
    public class InvoiceWithDetail : InvoiceBase
    {
        public InvoiceWithDetail()
        {

            InvoiceLines = new List<InvoiceLineWithDetail>();

        }

        public IEnumerable<InvoiceLineWithDetail> InvoiceLines { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerEmployeeFirstName { get; set; }
        public string CustomerEmployeeLastName { get; set; }
    }
}
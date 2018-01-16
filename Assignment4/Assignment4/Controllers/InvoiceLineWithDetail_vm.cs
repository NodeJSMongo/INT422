using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment4.Controllers
{
    public class InvoiceLineWithDetail : InvoiceLineBase
    {
        public InvoiceLineWithDetail()
        {
        }

        public string TrackName { get; set; }
        public string TrackComposer { get; set; }
        public string TrackAlbumTitle { get; set; }
        public string TrackAlbumArtistName { get; set; }
        public string TrackMediaTypeName { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class TrackBase
    {
        public TrackBase()
        {
        }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Key]
        public int TrackId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }
    }

    public class TrackWithDetail : TrackBase
    {

        public MediaTypeBase MediaType { get; set; }

        public String AlbumTitle;
    }

    public class TrackAdd
    {
        public TrackAdd()
        {
            Milliseconds = 0;

        }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(220)]
        public string Composer { get; set; }

        [Required]
        public int Milliseconds { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }


        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int MediaTypeId { get; set; }


    }

    public class TrackAddForm : TrackAdd
    {



        [Display(Name = "Album")]

        public SelectList AlbumList { get; set; }


        public String AlbumTitle;



        [Display(Name = "MediaType")]

        public SelectList MediaTypeList { get; set; }
        public String MediaTypeTitle;


    }


}
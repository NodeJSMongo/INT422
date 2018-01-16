using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


// This view model will carry data to the HTML Form, but does not describe the data package that is posted back to the controller method from the browser user

namespace Assignment_3.Controllers
{
    public class EmployeeAdd : Controller
    {
        public EmployeeAdd() { }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(80)]
        public string Company { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }
    }

    // Notice the inheritance pattern here - it works in this situation
    public class EmployeeBase : EmployeeAdd 
    {
        public EmployeeBase() { }

        // Reminder... must use the [Key] data annotation here
        [Key]
        public int EmployeeId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class PhonesController : Controller
    {
        //collection of Phones
        private List<PhoneBase> Phones;
        //add a constructor and initialize the collection
        public PhonesController()
        {
            Phones = new List<PhoneBase>();

            var iphone = new PhoneBase();

            iphone.Id = 1;
            iphone.PhoneName = "iPhone 7";
            iphone.Manufacturer = "Apple";
            iphone.DateReleased = new DateTime(2016, 11, 11);
            iphone.MSRP = 890;
            iphone.ScreenSize = 5.5;
            Phones.Add(iphone);

            var samsung = new PhoneBase();

            samsung.Id = 1;
            samsung.PhoneName = "samsung s7";
            samsung.Manufacturer = "Samsung";
            samsung.DateReleased = new DateTime(2016, 5, 21);
            samsung.MSRP = 890;
            samsung.ScreenSize = 5.7;
            Phones.Add(samsung);

            var motorolla = new PhoneBase();

            motorolla.Id = 1;
            motorolla.PhoneName = "motorolla 7";
            motorolla.Manufacturer = "Motorolla";
            motorolla.DateReleased = new DateTime(2016, 7, 31);
            motorolla.MSRP = 890;
            motorolla.ScreenSize = 5.2;
            Phones.Add(motorolla);

            var galaxy = new PhoneBase();

            galaxy.Id = 1;
            galaxy.PhoneName = "galaxy s6 ";
            galaxy.Manufacturer = "Samsung";
            galaxy.DateReleased = new DateTime(2016, 10,11);
            galaxy.MSRP = 890;
            galaxy.ScreenSize = 5.6;
            Phones.Add(galaxy);
        }

       

        // GET: Phones
        public ActionResult Index()
        {

            return View(Phones);
        }

        // GET: Phones/Details/5
        public ActionResult Details(int Id)
        {

            return View(Phones[Id-1]);
        }

        // GET: Phones/Create
        public ActionResult Create()
        {

            return View(new PhoneBase());
        }

        // POST: Phones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var newItem = new PhoneBase();
                newItem.Id = Phones.Count + 1;
                newItem.PhoneName = collection["PhoneNumber"];
                newItem.Manufacturer = collection["Manufacturer"];
                newItem.DateReleased = Convert.ToDateTime(collection["DateReleased"]);
                int msrp;
                double ss;
                bool isNumber;

                // MSRP
                isNumber = Int32.TryParse(collection["MSRP"], out msrp);
                newItem.MSRP = msrp;

                // Screen Size
                isNumber = double.TryParse(collection["ScreenSize"], out ss);
                newItem.ScreenSize = ss;

                // Add to the collection
                Phones.Add(newItem);
                return RedirectToAction("Details", newItem);
            }
            catch(ArgumentOutOfRangeException e)
            {
                return View("Your Input is correct but we are unable to store the value this time. sorry for the inconvenient.");
                throw (e);
                
            }
        }

      /*  // GET: Phones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Phones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Phones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Phones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } */
    }
}

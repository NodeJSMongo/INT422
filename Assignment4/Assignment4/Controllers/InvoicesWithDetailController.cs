using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment4.Controllers
{
    public class InvoicesWithDetailController : Controller
    {
        // GET: InvoicesWithDetail

        Manager m = new Manager();
        // GET: InvoicesWithDetail

        public ActionResult Index()
        {
            var c = m.InvoiceGetAll();
            return View(c);
        }


        // GET: InvoicesWithDetail/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }


        // GET: InvoicesWithDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoicesWithDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoicesWithDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoicesWithDetail/Edit/5
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

        // GET: InvoicesWithDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoicesWithDetail/Delete/5
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
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class EmployeesController : Controller
    {

        Manager m = new Manager();
        // GET: Employees
        public ActionResult Index()
        {
            var o = m.EmployeeGetAll();

            return View(o);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
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

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            //Attempt to fetch
            var o = m.EmployeeGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var editForm = m.mapper.Map<EmployeeEditContactInfoForm>(o);
                return View(editForm);
            }

        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, EmployeeEditContactInfo newItem)
        {
            //Validate the input
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.EmployeeId });
            }
            if (id.GetValueOrDefault() != newItem.EmployeeId)
            {
                return RedirectToAction("index");
            }

            var editedItem = m.EmployeeEditContactInfo(newItem);
            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = newItem.EmployeeId });
            }
            else
            {
                return RedirectToAction("index");
            }



        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
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
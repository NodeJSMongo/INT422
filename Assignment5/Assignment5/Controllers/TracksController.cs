using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index()
        {
            var o = m.TrackGetAllWithDetail();
            return View(o);
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.TrackGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
                return HttpNotFound();
            else


                return View(o);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            System.Diagnostics.Debug.WriteLine("GET");
            var form = new TrackAddForm();
            form.AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title");
            form.MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name");
            return View(form);
        }

        // POST: Tracks/Create
        [HttpPost]

        public ActionResult Create(TrackAddForm newItem)
        {
            TrackBase addedItem = null;
            if (ModelState.IsValid)
            {
                addedItem = m.TrackAdd(newItem);
            }
            else
            {
                return View(newItem);
            }

            return RedirectToAction("Index");
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tracks/Edit/5
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

        // GET: Tracks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tracks/Delete/5
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
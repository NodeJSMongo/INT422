using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class TracksController : Controller
    {

        Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index()
        {
            ViewBag.Title = "Track List (All tracks)";
            var o = m.TrackGetAll();
            return View(o);
        }

        public ActionResult Pop()
        {
            ViewBag.Title = "Track List (Pop)";
            var o = m.TrackGetAllPop();
            return View("Index", o);
        }

        public ActionResult DeepPurple()
        {
            ViewBag.Title = "Track List (Deep Purple)";
            var o = m.TrackGetAllDeepPurple();
            return View("Index", o);
        }

        public ActionResult LongestTracks()
        {
            ViewBag.Title = "Track List (Longest tracks)";
            var o = m.TrackGetAllTop100Longest();
            return View("Index", o);
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
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
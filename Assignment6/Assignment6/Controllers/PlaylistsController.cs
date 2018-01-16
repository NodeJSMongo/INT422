using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment6.Controllers
{
    public class PlaylistsController : Controller
    {
        private Manager m = new Manager();
        // GET: Playlists
        public ActionResult Index()
        {
            var o = m.PlaylistGetAllWithTracks();
            return View(o);
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.PlaylistGetByIdWithDetail(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
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

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.PlaylistGetByIdWithDetail(id.GetValueOrDefault());
            System.Diagnostics.Debug.WriteLine("Tracks " + o.TracksCount);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<PlaylistEditTracksForm>(o);

                var selectedValues = o.Tracks.Select(jd => jd.TrackId);

                form.TrackList = new MultiSelectList(items: m.TrackGetAll(), dataValueField: "TrackId", dataTextField: "NameFull", selectedValues: selectedValues);
                System.Diagnostics.Debug.WriteLine("SIZE at the beg " + form.Tracks.Count());

                List<TrackBase> temp = new List<TrackBase>();
                foreach (var item in o.Tracks)
                {
                    temp.Add(item);
                }
                form.Tracks = temp;

                System.Diagnostics.Debug.WriteLine("TB size is " + temp.Count());
                System.Diagnostics.Debug.WriteLine("Tracks size is " + form.Tracks.Count());

                return View(form);
            }

        }

        // POST: Playlists/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, PlaylistEditTracks collection)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = collection.Id });
            }

            if (id.GetValueOrDefault() != collection.Id)
            {
                return RedirectToAction("index");
            }

            var editedItem = m.PlaylistEditTracks(collection);

            if (editedItem == null)
            {
                return RedirectToAction("edit", new { id = collection.Id });
            }
            else
            {
                return RedirectToAction("Details", new { id = collection.Id });
            }
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Playlists/Delete/5
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
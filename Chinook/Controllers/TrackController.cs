﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Repository;
using Chinook.Model;

namespace Chinook.Controllers
{
    public class TrackController : BaseController<Track>
    {

        public ActionResult Index()
        {
            return View(_repository.GetList().OrderByDescending(p => p.TrackId).Take(15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (!ModelState.IsValid) return View(track);
            _repository.Add(track);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var track = _repository.GetById(x => x.TrackId == id);
            if (track == null) return RedirectToAction("Index");
            return View(track);
        }

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (!ModelState.IsValid) return View(track);
            _repository.Update(track);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var track = _repository.GetById(x => x.TrackId == id);
            if (track == null) return RedirectToAction("Index");
            return View(track);
        }

        [HttpPost]
        public ActionResult Delete(Track track)
        {
            track = _repository.GetById(x => x.TrackId
                        == track.TrackId);
            _repository.Delete(track);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var track = _repository.GetById(x => x.TrackId == id);
            if (track == null) return RedirectToAction("Index");
            return View(track);
        }
    }
}
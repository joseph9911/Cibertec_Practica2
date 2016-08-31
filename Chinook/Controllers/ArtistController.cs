using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Repository;
using Chinook.Model;
using Chinook.Filters;

namespace Chinook.Controllers
{
    public class ArtistController : BaseController<Artist>
    {

        public ActionResult Index()
        {
            return View(_repository.GetList().OrderByDescending(p => p.ArtistId).Take(15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            _repository.Add(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            _repository.Update(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            artist = _repository.GetById(x => x.ArtistId
                        == artist.ArtistId);
            _repository.Delete(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }
    }
}

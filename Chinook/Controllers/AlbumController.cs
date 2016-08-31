using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Repository;
using Chinook.Model;

namespace Chinook.Controllers
{
    public class AlbumController : BaseController<Album>
    {
        
        public ActionResult Index()
        {
            return View(_repository.GetList().OrderByDescending(p => p.AlbumId).Take(15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (!ModelState.IsValid) return View(album);
            _repository.Add(album);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var album = _repository.GetById(x => x.AlbumId == id);
            if (album == null) return RedirectToAction("Index");
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (!ModelState.IsValid) return View(album);
            _repository.Update(album);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var album = _repository.GetById(x => x.AlbumId == id);
            if (album == null) return RedirectToAction("Index");
            return View(album);
        }

        [HttpPost]
        public ActionResult Delete(Album album)
        {
            album = _repository.GetById(x => x.AlbumId
                        == album.AlbumId);
            _repository.Delete(album);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var album = _repository.GetById(x => x.AlbumId == id);
            if (album == null) return RedirectToAction("Index");
            return View(album);
        }
    }
}
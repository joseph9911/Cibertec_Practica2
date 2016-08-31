using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Repository;
using Chinook.Model;

namespace Chinook.Controllers
{
    public class GenreController : BaseController<Genre>
    {

        public ActionResult Index()
        {
            return View(_repository.GetList().OrderByDescending(p => p.GenreId).Take(15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            _repository.Add(genre);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var genre = _repository.GetById(x => x.GenreId == id);
            if (genre == null) return RedirectToAction("Index");
            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            _repository.Update(genre);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var genre = _repository.GetById(x => x.GenreId == id);
            if (genre == null) return RedirectToAction("Index");
            return View(genre);
        }

        [HttpPost]
        public ActionResult Delete(Genre genre)
        {
            genre = _repository.GetById(x => x.GenreId
                        == genre.GenreId);
            _repository.Delete(genre);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var genre = _repository.GetById(x => x.GenreId == id);
            if (genre == null) return RedirectToAction("Index");
            return View(genre);
        }
    }
}
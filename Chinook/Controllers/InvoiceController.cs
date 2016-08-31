using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Repository;
using Chinook.Model;

namespace Chinook.Controllers
{
    public class InvoiceController : BaseController<Invoice>
    {
        
        public ActionResult Index()
        {
            return View(_repository.GetList().OrderByDescending(p => p.InvoiceId).Take(15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            if (!ModelState.IsValid) return View(invoice);
            _repository.Add(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var invoice = _repository.GetById(x => x.InvoiceId == id);
            if (invoice == null) return RedirectToAction("Index");
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            if (!ModelState.IsValid) return View(invoice);
            _repository.Update(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var invoice = _repository.GetById(x => x.InvoiceId == id);
            if (invoice == null) return RedirectToAction("Index");
            return View(invoice);
        }

        [HttpPost]
        public ActionResult Delete(Invoice invoice)
        {
            invoice = _repository.GetById(x => x.InvoiceId
                        == invoice.InvoiceId);
            _repository.Delete(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var invoice = _repository.GetById(x => x.InvoiceId == id);
            if (invoice == null) return RedirectToAction("Index");
            return View(invoice);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Repository;
using Chinook.Model;

namespace Chinook.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {

        public ActionResult Index()
        {
            return View(_repository.GetList().OrderByDescending(p => p.EmployeeId).Take(15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _repository.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _repository.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            employee = _repository.GetById(x => x.EmployeeId
                        == employee.EmployeeId);
            _repository.Delete(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var employee = _repository.GetById(x => x.EmployeeId == id);
            if (employee == null) return RedirectToAction("Index");
            return View(employee);
        }
    }
}
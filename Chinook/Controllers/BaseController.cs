using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chinook.Filters;
using Chinook.Repository;

namespace Chinook.Controllers
{
    [ExceptionControl]
    [AuditControl]
    public class BaseController<T> : Controller where T:class
    {

        protected IRepository<T> _repository;
        public BaseController()
        {
            _repository = new BaseRepository<T>();
        }
    }
}
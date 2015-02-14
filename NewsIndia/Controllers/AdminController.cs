using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsIndia.AuthFilters;

namespace NewsIndia.Controllers
{

    /// <summary>
    /// Implemented for the various funtionliaty of Admin
    /// </summary>
    /// 
    [UserAuth]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
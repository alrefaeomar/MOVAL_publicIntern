using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInPortal.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace CheckInPortal.Controllers
{
    public class CheckInController : Controller
    {
        // GET: CheckIn
        public ActionResult Index()
        {

            return View();
        }
    }
}
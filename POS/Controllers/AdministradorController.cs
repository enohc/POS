﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;

namespace POS.Controllers
{
    public class AdministradorController : Controller
    {
        private POSDataContext db = new POSDataContext();
        // GET: Administrador
        public ActionResult Index()
        {
            var q = db.MENUs.ToList();   
            return View(q);
        }
        
        [HttpGet]
        public ActionResult Mantenimentos(string page) {
            string pages = "../" + page;
            return Redirect(page);
            //return View(page);        
        }
    }
}
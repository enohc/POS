using POS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class MenuController : Controller
    {
        private POSDataContext db = new POSDataContext();

        // GET: Menu
        public ActionResult Index()
        {
            List<MENU> menus = db.MENUs.ToList();
            return View(menus);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(MENU m)
        {
            db.MENUs.InsertOnSubmit(m);
            db.SubmitChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {            
            MENU menu = db.MENUs.Where( m => m.idMenu == int.Parse( id)).Single();
            return View(menu);
        }

        [HttpPost]
        public ActionResult Editar(MENU m)
        {
            db.MENUs.GetModifiedMembers(m);
            db.SubmitChanges();
            return Redirect("Index");
        }

    }
}
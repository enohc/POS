using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;

namespace POS.Controllers
{
    public class RolController : Controller
    {
        private POSDataContext db = new POSDataContext();

        // GET: Menu
        public ActionResult Index()
        {
            List<ROL> rol = db.ROLs.ToList();
            return View(rol);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ROL m)
        {
            db.ROLs.InsertOnSubmit(m);
            db.SubmitChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ROL u = db.ROLs.Where(m => m.idRol ==id).Single();
            return View(u);
        }

        [HttpPost]
        public ActionResult Editar(ROL m)
        {
            db.ROLs.GetModifiedMembers(m);
            db.SubmitChanges();
            return Redirect("Index");
        }
    }

}
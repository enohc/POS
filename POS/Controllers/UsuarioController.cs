using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;
namespace POS.Controllers
{
    public class UsuarioController : Controller
    {
        private POSDataContext db = new POSDataContext();

        // GET: Menu
        public ActionResult Index()
        {
            List<USUARIO> menus = db.USUARIOs.ToList();
            return View(menus);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(USUARIO m)
        {
            db.USUARIOs.InsertOnSubmit(m);
            db.SubmitChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            USUARIO u = db.USUARIOs.Where(m => m.DUI.Equals(id)).Single();
            return View(u);
        }

        [HttpPost]
        public ActionResult Editar(USUARIO m)
        {
            db.USUARIOs.GetModifiedMembers(m);
            db.SubmitChanges();
            return Redirect("Index");
        }
    }
}
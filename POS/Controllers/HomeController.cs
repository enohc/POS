using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;


namespace POS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            string page = "Login";
            return View(page);       
        }

    [HttpPost]
    public ActionResult Index(USUARIO usr)
    {
            string page = "Login";
            var db = new POSDataContext();
            var q  = db.USUARIOs.Where(u =>  u.clave.Equals(usr.clave) && u.usuario1.Equals(usr.usuario1)).SingleOrDefault();


            if (q == null)
            {
                ViewBag.errorMessage = "Usuario O Clave invalido";                
                page = "Login";
            }
            else {
                page = q.ROL1.nombre;
            }

        return View();
    }

}
}
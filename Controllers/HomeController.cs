using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
//using static WebApplication1.Models.ListModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dbmanager = new DBmanager();
            List<Ppm99> ppm99s = dbmanager.GetPpmList();
            ViewBag.ppm99s = ppm99s;
            return View();
        }

        public ActionResult CreatPPM()
        {
                return View();
        }

        [HttpPost]
        public ActionResult CreatPPM(Ppm99 PPM99)
        {
            DBmanager dbmanager = new DBmanager();
            try {
                dbmanager.NewCard(PPM99);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public ActionResult EditPPM(int stfn)
        {
            DBmanager dbmanager = new DBmanager();
            Ppm99 ppm99 = dbmanager.GetPpm99Detail(stfn);
            return View(ppm99);
        }

        [HttpPost]
        public ActionResult EditPPM(Ppm99 PPM99)
        {
            DBmanager dbmanager = new DBmanager();
            dbmanager.UpdatePpm99Detail(PPM99);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HRListController : Controller
    {
        public ActionResult StaffList()
        {
            StaffListModel dbmanager = new StaffListModel();
            List<Ppm99> ppm99s = dbmanager.GetStaffList();
            ViewBag.ppm99s = ppm99s;
            return View();
        }

        //新增/修改/刪除/作廢/編輯

        /// <summary>
        /// 新增員工明細
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatPPM()
        {
                return View();
        }

        [HttpPost]
        public ActionResult CreatPPM(Ppm99 PPM99)
        {
            StaffListModel dbmanager = new StaffListModel();
            try {
                dbmanager.NewCard(PPM99);
                return RedirectToAction("StaffList");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public ActionResult EditPPM(int stfn)
        {
            StaffListModel dbmanager = new StaffListModel();
            Ppm99 ppm99 = dbmanager.GetPpm99Detail(stfn);
            return View(ppm99);
        }

        [HttpPost]
        public ActionResult EditPPM(Ppm99 PPM99)
        {
            StaffListModel dbmanager = new StaffListModel();
            dbmanager.UpdatePpm99Detail(PPM99);
            return RedirectToAction("StaffList");
        }
    }
}
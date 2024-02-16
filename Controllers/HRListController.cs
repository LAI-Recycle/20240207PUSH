using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HRListController : Controller
    {
        /// <summary>
        /// 員工資料清單
        /// </summary>
        /// <returns></returns>
        public ActionResult StaffList()
        {
            StaffListModel dbmanager = new StaffListModel();
            List<StaffList> stafflist = dbmanager.GetStaffList();

            return View(stafflist);
        }
    }
}
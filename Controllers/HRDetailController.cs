using System;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HRDetailController : Controller
    {
        ///新增/修改/刪除/作廢
        StaffDetailModel dbmanager = new StaffDetailModel();

        /// <summary>
        /// 新增員工明細
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddStaffDetail()
        {
            return View();
        }

        /// <summary>
        /// 新增員工明細
        /// </summary>
        /// <param name="staffdetail"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddStaffDetail(StaffDetail staffdetail, string submitButton, string[] ppm99_transportList)
        {
            if (submitButton == "save")
            {
                try
                {
                    dbmanager.AddStaffDetail(staffdetail, ppm99_transportList);

                    return RedirectToAction("StaffList", "HRList");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    return View();
                }
            }
            else
            {
                return RedirectToAction("StaffList", "HRList");
            }
        }

        /// <summary>
        /// 修改員工明細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateStaffDetail(int id)
        {
            StaffDetail staffdetail = dbmanager.GetStaffDetail(id);

            return View(staffdetail);
        }

        /// <summary>
        /// 修改員工明細
        /// </summary>
        /// <param name="staffdetail"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateStaffDetail(StaffDetail staffdetail, string submitButton, string[] ppm99_transportList)
        {
            if (submitButton == "update")
            {
                dbmanager.UpdateStaffDetail(staffdetail, ppm99_transportList);
            }

            return RedirectToAction("StaffList", "HRList");
        }
        /// <summary>
        /// 刪除員工明細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteStaffDetail(int id)
        {
            dbmanager.DeleteStaffDetail(id);

            return RedirectToAction("StaffList", "HRList");
        }

        /// <summary>
        /// 檢查員工編號
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CheckStfnDetail(int ppm99_stfn)
        {
            if (dbmanager.CheckStfnDetail(ppm99_stfn))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

    }
}
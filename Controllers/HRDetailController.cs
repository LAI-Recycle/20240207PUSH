using System;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HRDetailController : Controller
    {
        ///�s�W/�ק�/�R��/�@�o
        StaffDetailModel dbmanager = new StaffDetailModel();

        /// <summary>
        /// �s�W���u����
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddStaffDetail()
        {
            return View();
        }

        /// <summary>
        /// �s�W���u����
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
        /// �ק���u����
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
        /// �ק���u����
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
        /// �R�����u����
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
        /// �ˬd���u�s��
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
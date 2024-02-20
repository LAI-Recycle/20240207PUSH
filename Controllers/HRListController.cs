using System.Web.Mvc;
using WebApplication1.Models;
using System.Linq;
using PagedList;

namespace WebApplication1.Controllers
{
    public class HRListController : Controller
    {
        /// <summary>
        /// 員工資料清單
        /// </summary>
        /// <returns></returns>
        public ActionResult StaffList(StaffListModel dbmanager, int page = 1, int pageSize = 5)
        {
            dbmanager.GetStaffList();
            IPagedList<StaffListModel.Staff> result = dbmanager.StaffList.OrderBy(x => x.ppm99_stfn).ToPagedList(page, pageSize);

            return View(result);
        }
    }
}
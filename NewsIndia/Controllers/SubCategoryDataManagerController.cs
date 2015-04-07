using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BusinessClasses;
using NewsIndia.AuthFilters;

namespace NewsIndia.Controllers
{
    [UserAuth]
    [AdminAuth]
    public class SubCategoryDataManagerController : Controller
    {

        /// <summary>
        /// Used to Display the subcategory Data Master
        /// </summary>
        /// <returns></returns>
        public ActionResult SubCategoryDataMaster()
        {
            ViewBag.ActiveCategoryInfo = NewsIndiaBAL.SubCategoryManager.GetActiveCategories();
            return View();
        }

        /// <summary>
        /// Used to get the list of all SubCategories present for the category
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSubCategories(int categoryId)
        {
            try
            {
                return Json(NewsIndiaBAL.SubCategoryDataManager.GetSubCategories(categoryId),
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new List<SubCategoryInformation>(), JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Used to display the table of the SubCategory
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowSubCategoryDataTable()
        {
            var subCategories = NewsIndiaBAL.SubCategoryDataManager.GetSubCategoryDataList();
            return View(subCategories);
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessClasses;
using EntityProject;

namespace NewsIndiaDAL
{
    public class LayoutMethods
    {
        /// <summary>
        /// Used to get menu for layout
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetMenuList()
        {
            try
            {
                using (var nie = new NewsIndiaTVEntities())
                {
                    return nie.CategoryMasters.Where(m => m.IsActive).Select(menu => new Category()
                     {
                         CategoryName = menu.CategoryName,
                         CategoryId = menu.ID,
                         SubCategory =
                             menu.SubCategoryMasters.Where(m => m.CategoryID == menu.ID).Select(n => new SubCategory()
                             {
                                 SubCategoryId = n.ID,
                                 SubCategoryName = n.SubCategoryName
                             }).ToList()
                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }

        /// <summary>
        /// Used to get the Information about the side banner
        /// </summary>
        /// <returns></returns>
        public static List<SideBannerMaster> GetSideBanner()
        {
            try
            {
                using (var nie = new NewsIndiaTVEntities())
                {
                    return nie.SideBannerMasters.Where(m => m.IsActive).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<SideBannerMaster>();
            } 
        }
    }
}

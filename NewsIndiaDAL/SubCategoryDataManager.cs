using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessClasses;
using EntityProject;

namespace NewsIndiaDAL
{
    public class SubCategoryDataManager
    {

        /// <summary>
        /// Used to get the list of all the SubCategory Data
        /// </summary>
        /// <param name="subCategoryDataId"></param>
        public static List<SubCategoryDataTableModel> GetSubCategoryDataList(int subCategoryDataId = 0)
        {
            try
            {
                using (var nie = new NewsIndiaTVEntities())
                {
                    return
                        nie.SubCategoryDataMasters.Where(m => m.IsActive && (subCategoryDataId == 0 || m.SubCategoryId == subCategoryDataId))
                            .Select(m => new SubCategoryDataTableModel()
                                {
                                    CategoryName = m.SubCategoryMaster.CategoryMaster.CategoryName,
                                    IsCategoryActive = m.SubCategoryMaster.CategoryMaster.IsActive,
                                    IsCategoryVisible = m.SubCategoryMaster.CategoryMaster.IsVisible,
                                    IsVisible = m.IsVisible,
                                    IsSubCategoryActive = m.SubCategoryMaster.IsActive,
                                    IsSubCategoryVisible = m.SubCategoryMaster.IsVisible,
                                    SubCategoryDataId = m.ID,
                                    SubCategoryDataTitle = m.Title,
                                    SubCategoryDataShowing = (m.IsVisible && m.SubCategoryMaster.IsActive && m.SubCategoryMaster.IsVisible && m.SubCategoryMaster.CategoryMaster.IsVisible && m.SubCategoryMaster.CategoryMaster.IsActive)

                                }
                            ).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<SubCategoryDataTableModel>();
            }

        }
        /// <summary>
        /// Used to get the list of all the subCatgories present under the category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static List<SubCategoryInformation> GetSubCategories(int categoryId)
        {
            try
            {
                using (var nie = new NewsIndiaTVEntities())
                {
                    return
                        nie.SubCategoryMasters.Where(m => m.CategoryID == categoryId && m.IsActive)
                            .Select(m => new SubCategoryInformation()
                            {
                                SubCategoryId = m.ID,
                                SubCategoryName = m.SubCategoryName
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<SubCategoryInformation>();
            }
        }

        /// <summary>
        /// Used to remove the SubCategory
        /// </summary>
        /// <param name="subCategoryDataId"></param>
        /// <returns></returns>
        public static bool RemoveSubCategoryData(int subCategoryDataId)
        {
            try
            {
                using (var nie = new NewsIndiaTVEntities())
                {
                    var subCategoryDataInfo = nie.SubCategoryDataMasters.FirstOrDefault(m => m.ID == subCategoryDataId);
                    if (subCategoryDataInfo != null)
                        subCategoryDataInfo.IsActive = false;
                    nie.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

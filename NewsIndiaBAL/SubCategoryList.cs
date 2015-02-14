using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessClasses;
using EntityProject;
using NewsIndiaDAL;

namespace NewsIndiaBAL
{
    public class SubCategoryList
    {
        /// <summary>
        /// Used to get List of the subCategory
        /// </summary>
        /// <returns></returns>
        public static List<SubCategoryListModel> GetSubCategoryListView(int subCategory = 0)
        {
            try
            {

                return SubCategoryListDisplay.GetSubCategoryListView(subCategory);

            }
            catch (Exception ex)
            {
                return new List<SubCategoryListModel>();
            }
        }


        /// <summary>
        /// Used to get Information about SubCategory
        /// </summary>
        /// <param name="subCategoryId"></param>
        /// <returns></returns>
        public static string GetSubCategoryInformation(int subCategoryId = 0)
        {
            try
            {

                return SubCategoryListDisplay.GetSubCategoryInformation(subCategoryId);

            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

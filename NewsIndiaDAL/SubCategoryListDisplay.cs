﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessClasses;
using EntityProject;

namespace NewsIndiaDAL
{
    public class SubCategoryListDisplay
    {
        /// <summary>
        /// Used to get List of the subCategory
        /// </summary>
        /// <returns></returns>
        public static List<SubCategoryListModel> GetSubCategoryListView(int subCategory = 0)
        {
            try
            {
                using (var nie = new NewsIndiaTVEntities())
                {
                    return nie.SubCategoryDataMasters.Where(m => m.SubCategoryId == subCategory).Select(
                        m => new SubCategoryListModel()
                        {
                            Title = m.Title,
                            Description = m.Description,
                            SubCategoryDataId = m.ID,
                            Attachments = m.SubCategoryDataAttachments.Where(c => c.SubCategoryDataID == m.ID).Select(
                            c => new SubCategoryAttachment()
                            {
                                FileName = c.FileName,
                                FileType = (AttachmentType)c.AttachmentID,
                                SubCategoryAttachmentId = c.ID
                            }).ToList()
                        }
                        ).ToList();
                }
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
                using (var nie = new NewsIndiaTVEntities())
                {
                    return nie.SubCategoryMasters.FirstOrDefault(m => m.ID == subCategoryId).SubCategoryName;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}

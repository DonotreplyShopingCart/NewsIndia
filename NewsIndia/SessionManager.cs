using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessClasses;
using EntityProject;
using NewsIndiaBAL;

namespace NewsIndia
{
    public class SessionManager
    {
        /// <summary>
        /// Used to load the Menu In the Session
        /// </summary>
        public static void GetMenuInSessionUser()
        {
            if (HttpContext.Current.Session["MENU_INFORMATION"] == null)
            {
                HttpContext.Current.Session.Add("MENU_INFORMATION", UserLayout.GetUserMenuList());
                HttpContext.Current.Session.Add("MENU_SIDEBANNER_INFORMATION", UserLayout.GetSideBannerList());
            }
            else
            {
                HttpContext.Current.Session["MENU_INFORMATION"] = UserLayout.GetUserMenuList();
                HttpContext.Current.Session.Add("MENU_SIDEBANNER_INFORMATION", UserLayout.GetSideBannerList());
            } 
        }

        /// <summary>
        /// Used to get the Menu Items from Session
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetMenuItemFromSession()
        {
            return (List<Category>)HttpContext.Current.Session["MENU_INFORMATION"];
        }

        /// <summary>
        /// Used to get the Menu Items from Session
        /// </summary>
        /// <returns></returns>
        public static List<SideBannerMaster> GetSideBarMenuItemFromSession()
        {
            return (List<SideBannerMaster>)HttpContext.Current.Session["MENU_SIDEBANNER_INFORMATION"];
        }

    }
}
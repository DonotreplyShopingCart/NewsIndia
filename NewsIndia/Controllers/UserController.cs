using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessClasses;
using Common;
using NewsIndiaBAL;
using Newtonsoft.Json;

namespace NewsIndia.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            var userModel = new UserModel();
            List<CountryMaster> countriesList = new List<CountryMaster>();
            var countryList = CountryList.GetCountryList();
            List<StateMaster> statesList = new List<StateMaster>();
            var stateList = StateList.GetStateList();
            //string strapiForCountries = "api/Country/GetAllCountries?pageNumber=" + 0 + "&pageSize=" + "0" + "&searchKeyword=" + null + "&sortColumnName=" + null + "&sortOrder=" + "asc";
            //var countryList = JsonConvert.DeserializeObject<ApiResponse<List<CountryMaster>>>(Client.DownloadString(strapiForCountries));
            //countriesList = countryList.Model;
            if (countryList.Any())
            {
                if (countryList.Count > 0)
                {
                    countriesList.RemoveAt(countriesList.Count - 1);
                    userModel.DropDownForCountry =
                        countriesList.Select(c => new SerializableSelectListItem
                        {
                            Text = c.CountryName,
                            Value = c.CountryId.ToString(CultureInfo.InvariantCulture)
                        });
                }
            }

            if (stateList.Any())
            {
                if (statesList.Count > 0)
                {
                    statesList.RemoveAt(statesList.Count - 1);
                    userModel.DropDownForState =
                        statesList.Select(c => new SerializableSelectListItem
                        {
                            Text = c.StateName,
                            Value = c.StateId.ToString(CultureInfo.InvariantCulture)
                        });
                }
            }

            return View();
        }
    }
}
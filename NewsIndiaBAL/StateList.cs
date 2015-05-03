using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessClasses;
using NewsIndiaDAL;

namespace NewsIndiaBAL
{
    public class StateList
    {
        public static List<StateMaster> GetStateList(int subCategory = 0)
        {
            try
            {

                return StateData.GetStateList().ToList();

            }
            catch (Exception ex)
            {
                return new List<StateMaster>();
            }
        }
    }
}

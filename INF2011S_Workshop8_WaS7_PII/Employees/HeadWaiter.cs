using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.Employees
{
    public class HeadWaiter :Role
    {
    private decimal salary;

        #region properties
        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        #endregion

        #region Constructor
        public HeadWaiter():  base()
        {
            RoleValue = RoleType.Headwaiter;
            description = "Headwaiter";
            salary = 0;
        }
        #endregion

        #region Methods
        public override decimal Payment()
        {
            //Will be calculated when shifts are available
            return salary;
        }
        #endregion

    }
}

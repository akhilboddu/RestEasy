using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace INF2011S_Workshop8_WaS7_PII.Employees
{
    public class Waiter : Role
    {
        private decimal tips;
        private decimal rate;
        private int noOfShifts;

        #region Properties

        public decimal Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }
        public int NumberOfShifts
        {
            get
            {
                return noOfShifts;
            }
            set
            {
                noOfShifts = value;
            }
        }
        public decimal Tips
        {
            get
            {
                return tips;
            }
            set
            {
                tips = value;
            }
        }
        #endregion

        #region Constructors
        public Waiter() :  base()
        {
            RoleValue = RoleType.Waiter;
            description = "Waiter";
            noOfShifts = 0;
            rate = 0;
        }
        #endregion

        #region Methods
        public override decimal Payment()
        {
            //Will be calculated when shifts are available
            return rate * noOfShifts + tips;
        }
        
        #endregion
    }
}

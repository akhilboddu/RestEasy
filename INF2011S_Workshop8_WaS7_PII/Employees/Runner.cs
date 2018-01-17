using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.Employees
{
    public class Runner : Role
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
        #endregion

        public Runner() :  base()
        {
            RoleValue = RoleType.Runner;
            description = "Runner";
            noOfShifts = 0;
            rate = 0;
            tips = 0;
        }

        #region Methods

        public override decimal Payment()
        {
            //Will be calculated when shifts are available
            return rate * noOfShifts;
        }

        public override decimal Payment(decimal tipsVal)
        {
            tips = tipsVal;  //*** I assume that the tips will be sent to the runner
            //Will be calculated when shifts are available
            return rate * noOfShifts + tips;
        }
        #endregion
    }
}

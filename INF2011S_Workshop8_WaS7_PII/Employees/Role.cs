using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.Employees
{
    public class Role
    {
       public enum RoleType
        {
            NoRole = 0,
            Headwaiter = 1,
            Waiter = 2,
            Runner = 3
        } 
        protected RoleType roleval;
        protected string description;

        #region Role properties 
        public RoleType RoleValue
        {
            get
            {
                return roleval;
            }
            set
            {
                roleval = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        #endregion
        public Role()
        {
            roleval = RoleType.NoRole;
            description = "No Role";
        }
       
        public virtual decimal Payment()
        {
            return 0;
        }

        public virtual decimal Payment(decimal percentage)
        {
            return 0;
        }

    }
}

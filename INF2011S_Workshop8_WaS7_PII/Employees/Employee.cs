using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.Employees
{
    public class Employee: Person
    {
        #region Data members
        //An employee has ALL the attributes of a person AND 
        //he/she also has an Employee number and a ROLE object
        //because an object already knows HOW to behave, I made the role "attribute" public
        private string empID;
        public Role role;
        #endregion

        #region Properties
        public string EmpID
        {
            get
            {
                return empID;
            }
            set
            {
                empID = value;
            }
        }       
        #endregion

        #region Constructors
        //Employee will always be created in a specific role -- IF NO role is assigned  
        //Role will just be a generic default where role type is 0 and description is: "No Role"
        public Employee(Role.RoleType roleValue)
        {
            switch (roleValue)
            {
                case Role.RoleType.NoRole:
                    role = new Role();
                    break;
                case Role.RoleType.Headwaiter:
                    role = new HeadWaiter();
                    break;
                case Role.RoleType.Waiter:
                    role = new Waiter();
                    break;
                case Role.RoleType.Runner:
                    role = new Runner();
                    break;
            }
        }
        #endregion

        //***One can add a ToString method here to override the ToString method of a Person object
        public override string ToString()
        {
            return this.empID + ":    " + this.Name;
        }
    }
}

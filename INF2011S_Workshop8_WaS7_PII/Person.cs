using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII
{
    public abstract class Person
    {
        private string id;
        private string name;
        private string phone;

        #region Properties

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        #endregion

        #region Constructors
        public Person()
        {
            id = "";
            name = "";
            phone = "";
        }

        public Person(string idVal, string nameVal, string phoneVal)
        {
            id = idVal;
            name = nameVal;
            phone = phoneVal;
        }
        #endregion

        public override string ToString()
        {
            return name + '\n' + phone;
        }
    }
}

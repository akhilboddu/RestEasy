using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INF2011S_Workshop8_WaS7_PII.Employees;

namespace INF2011S_Workshop8_WaS7_PII.Shifts
{
    public class Shift
    {
        public enum ShiftType
        {
            Day = 0,
            Evening = 1
        }
        private Calendar myCal = CultureInfo.InvariantCulture.Calendar;
        private long shiftID;
        private DateTime date;
        private ShiftType shift;
        private int shiftNumber;
        private Collection<Employee> employeesOnShift;

        private decimal[] tips = new decimal[8];

        #region Property Methods
        public Collection<Employee> EmployeesOnShift
        {
            get { return employeesOnShift; }
        }

        public decimal[] Tip
        {
            get { return tips; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DayOfWeek Weekday
        {
            get { return myCal.GetDayOfWeek(date); }
        }

        public ShiftType ShiftDayEve
        {
            get { return shift; }
            set { shift = value; }
        }

        public int Number
        {
            get { return shiftNumber; }
            set { shiftNumber = value; }
        }
        #endregion

        public Shift()
        {
            employeesOnShift = new Collection<Employee>();
        }

        #region Shift Methods
        public bool Add2Shift(Employee emp)
        {
            bool addedToCollection = true;

            if (employeesOnShift.Count == 0)
            { employeesOnShift.Add(emp); }
            else
            {
                if (employeesOnShift.Contains(emp))
                {
                    addedToCollection = false;
                }
                else
                {
                    employeesOnShift.Add(emp);
                }
                return addedToCollection;
            }
            return addedToCollection;
        }

        public void RemoveFromShift(Employee anEmp)
        {
            employeesOnShift.Remove(anEmp);
        }
        #endregion
    }
}

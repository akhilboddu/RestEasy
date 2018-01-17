using INF2011S_Workshop8_WaS7_PII.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class GuestController
    {
        RestEasyDB guestDB;
        Collection<Guest> guests;   //***W3

        #region Properties
        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }
        #endregion

        public GuestController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            guestDB = new RestEasyDB();
            guests = guestDB.AllGuests;
        }

      

        #region Database Communication
        public void DataMaintenance(Guest aGuest, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            guestDB.DataSetChange(aGuest, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the Guest to the Collection
                    guests.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;  // replace Guest at this index with the updated Guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);  // find the index of the specific Guest in collection
                    guests.RemoveAt(index);  // remove that Guest form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Guest Guest)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return guestDB.UpdateDataSource(Guest);
        }
        #endregion

        #region Search Methods
        //This method receives a Guest ID as a parameter; finds the Guest object in the collection of employees and then returns this object
        public Guest Find(string id)
        {
            int index = 0;
            if (guests[index].IdPassport == null)
            {
                return null;
            }

            bool found = (guests[index].IdPassport == id);  
            int count = guests.Count;
            while (!(found) && (index < guests.Count - 1)) 
            {
                index = index + 1;
                found = (guests[index].IdPassport == id);   // this will be TRUE if found
            }
            return guests[index];  // this is the one!  
        }

        public int FindIndex(Guest aGuest)
        {
            int counter = 0;
            bool found = false;
            found = (aGuest.IdPassport == guests[counter].IdPassport);  
            while (!(found) & counter < guests.Count - 1)
            {
                counter += 1;
                found = (aGuest.IdPassport == guests[counter].IdPassport);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        public bool myownfindmethod(string id)
        {
            bool isFound = false;
            for(int i =0; i<guests.Count; i++)
            {
                if (guests[i].IdPassport.Equals(id))
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
            }

            return isFound;
        }

      
    }
}

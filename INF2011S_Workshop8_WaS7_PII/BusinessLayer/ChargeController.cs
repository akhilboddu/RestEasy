using INF2011S_Workshop8_WaS7_PII.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class ChargeController
    {
        ChargeDB chargeDB;
        Collection<Charge> charges;   //***W3

        #region Properties
        public Collection<Charge> AllCharges
        {
            get
            {
                return charges;
            }
        }
        #endregion

        public ChargeController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            chargeDB = new ChargeDB();
            charges = chargeDB.AllCharges;
        }



        #region Database Communication
        public void DataMaintenance(Charge aAccount, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            chargeDB.DataSetChange(aAccount, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the Guest to the Collection
                    charges.Add(aAccount);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aAccount);
                    charges[index] = aAccount;  // replace Guest at this index with the updated Guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aAccount);  // find the index of the specific Guest in collection
                    charges.RemoveAt(index);  // remove that Guest form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Charge aAccount)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return chargeDB.UpdateDataSource(aAccount);
        }
        #endregion

        #region Search Methods
        //This method receives a Guest ID as a parameter; finds the Guest object in the collection of employees and then returns this object
        public Charge Find(string id)
        {
            int index = 0;
            if (charges[index].AccountID == 0)
            {
                return null;
            }

            bool found = (Convert.ToString(charges[index].AccountID) == id);
            int count = charges.Count;
            while (!(found) && (index < charges.Count - 1))
            {
                index = index + 1;
                found = (Convert.ToString(charges[index].AccountID) == id);   // this will be TRUE if found
            }
            return charges[index];  // this is the one!  
        }

        public int FindIndex(Charge aAccount)
        {
            int counter = 0;
            bool found = false;
            found = (aAccount.AccountID == charges[counter].AccountID);
            while (!(found) & counter < charges.Count - 1)
            {
                counter += 1;
                found = (aAccount.AccountID == charges[counter].AccountID);
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
            for (int i = 0; i < charges.Count; i++)
            {
                if (charges[i].AccountID.Equals(id))
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
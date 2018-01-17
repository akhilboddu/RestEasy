using INF2011S_Workshop8_WaS7_PII.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class AccountController
    {
        AccountDB accountDB;
        Collection<Account> accounts;   //***W3

        #region Properties
        public Collection<Account> AllAccounts
        {
            get
            {
                return accounts;
            }
        }
        #endregion

        public AccountController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;
        }



        #region Database Communication
        public void DataMaintenance(Account aAccount, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            accountDB.DataSetChange(aAccount, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the Guest to the Collection
                    accounts.Add(aAccount);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aAccount);
                    accounts[index] = aAccount;  // replace Guest at this index with the updated Guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aAccount);  // find the index of the specific Guest in collection
                    accounts.RemoveAt(index);  // remove that Guest form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Account aAccount)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return accountDB.UpdateDataSource(aAccount);
        }
        #endregion

        #region Search Methods
        //This method receives a Guest ID as a parameter; finds the Guest object in the collection of employees and then returns this object
        public Account Find(string id)
        {
            int index = 0;

            if (accounts[index].AccountID == 0)
            {
                return null;
            }

            bool found = (Convert.ToString(accounts[index].AccountID) == id);
            int count = accounts.Count;
            while (!(found) && (index < accounts.Count - 1))
            {
                index = index + 1;
                found = (Convert.ToString(accounts[index].AccountID) == id);   // this will be TRUE if found
            }
            return accounts[index];  // this is the one!  
        }

        public int FindIndex(Account aAccount)
        {
            int counter = 0;
            bool found = false;
            found = (aAccount.AccountID == accounts[counter].AccountID);
            while (!(found) & counter < accounts.Count - 1)
            {
                counter += 1;
                found = (aAccount.AccountID == accounts[counter].AccountID);
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
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountID.Equals(id))
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


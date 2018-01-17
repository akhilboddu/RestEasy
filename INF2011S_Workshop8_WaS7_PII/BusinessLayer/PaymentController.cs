using INF2011S_Workshop8_WaS7_PII.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class PaymentController
    {
        Collection<Payment> payments;
        PaymentDB paymentDB;

        public Collection<Payment> AllPayments
        {
            get
            {
                return payments;
            }
        }

        public PaymentController()
        {
            paymentDB = new PaymentDB();
            payments = paymentDB.AllPayments;
        }



        #region Database Communication
        public void DataMaintenance(Payment aAccount, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            paymentDB.DataSetChange(aAccount, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the Guest to the Collection
                    payments.Add(aAccount);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aAccount);
                    payments[index] = aAccount;  // replace Guest at this index with the updated Guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aAccount);  // find the index of the specific Guest in collection
                    payments.RemoveAt(index);  // remove that Guest form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Payment aAccount)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return paymentDB.UpdateDataSource(aAccount);
        }
        #endregion

        #region Search Methods
        //This method receives a Guest ID as a parameter; finds the Guest object in the collection of employees and then returns this object
        public Payment Find(string id)
        {
            int index = 0;
            if (payments[index].AccountID == 0)
            {
                return null;
            }

            bool found = (Convert.ToString(payments[index].AccountID) == id);
            int count = payments.Count;
            while (!(found) && (index < payments.Count - 1))
            {
                index = index + 1;
                found = (Convert.ToString(payments[index].AccountID) == id);   // this will be TRUE if found
            }
            return payments[index];  // this is the one!  
        }

        public int FindIndex(Payment aAccount)
        {
            int counter = 0;
            bool found = false;
            found = (aAccount.AccountID == payments[counter].AccountID);
            while (!(found) & counter < payments.Count - 1)
            {
                counter += 1;
                found = (aAccount.AccountID == payments[counter].AccountID);
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
            for (int i = 0; i < payments.Count; i++)
            {
                if (payments[i].AccountID.Equals(id))
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

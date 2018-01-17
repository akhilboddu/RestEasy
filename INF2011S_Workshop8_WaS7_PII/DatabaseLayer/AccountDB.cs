using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.DatabaseLayer
{
    public class AccountDB : DB
    {
        //Data members        
        private string table1 = "Account";
        private string sqlLocal1 = "SELECT * FROM Account";


        //Need to create enums for correct table access

        private Collection<Account> accounts;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public AccountDB() : base()
        {
            accounts = new Collection<Account>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }

        public Collection<Account> AllAccounts
        {
            get
            {
                return accounts;
            }
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Account aAccount, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aAccount, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aAccount, dataTable)];
                    FillRow(aRow, aAccount, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aAccount, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        #endregion

        #region Utility Methods
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Guest object
            DataRow myRow = null;
            Account aAccount;

            //READ from the table  

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new object
                    aAccount = new Account();

                    aAccount.AccountID = Convert.ToInt32(myRow["Id"]);
                    aAccount.IDPassport = Convert.ToString(myRow["IDPASSPORT"]);
                    aAccount.ReservationRef = Convert.ToString(myRow["RESERVATIONREF"]).TrimEnd();
                    aAccount.Status = Convert.ToInt32(myRow["ACCSTATUS"]);
                    aAccount.Balance = Convert.ToDecimal(myRow["BALANCE"]);

                    accounts.Add(aAccount);
                }
            }
        }
        private void FillRow(DataRow aRow, Account aAccount, DB.DBOperation operation)
        {
            aRow["Id"] = aAccount.AccountID;  //NOTE square brackets to indicate index of collections of fields in row.
            aRow["IDPASSPORT"] = aAccount.IDPassport;
            aRow["RESERVATIONREF"] = aAccount.ReservationRef;
            aRow["ACCSTATUS"] = aAccount.Status;
            aRow["BALANCE"] = aAccount.Balance;

        }

        //The FindRow method finds the row for a specific Guest(by ID)  in a specific table
        private int FindRow(Account aAccount, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                //Ignore rows marked as deleted in dataset
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //In c# there is no item property (but we use the 2-dim array) it is automatically known to the compiler when used as below
                    if (aAccount.AccountID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["Id"]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex += 1;
            }
            return returnValue;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Account aAccount)
        {
            //Create Parameters to communicate with SQL INSERT
            //https://www.google.co.za/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=size+in+bytes+of+Int+in+SQL

            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.Int, 10, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@RESERVATIONREF", SqlDbType.Int, 20, "RESERVATIONREF");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ACCSTATUS", SqlDbType.Bit, 20, "ACCSTATUS");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@BALANCE", SqlDbType.Decimal, 20, "BALANCE");
            daMain.InsertCommand.Parameters.Add(param);

            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Build_UPDATE_Parameters(Account aAccount)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.Int, 10, "ID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RESERVATIONREF", SqlDbType.Int, 20, "RESERVATIONREF");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ACCSTATUS", SqlDbType.Bit, 20, "ACCSTATUS");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@BALANCE", SqlDbType.Decimal, 20, "BALANCE");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ID", SqlDbType.Int, 20, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }
        private void Create_INSERT_Command(Account aAccount)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Account (ID, IDPASSPORT, RESERVATIONREF, ACCSTATUS, BALANCE) VALUES (@ID, @IDPASSPORT, @RESERVATIONREF, @ACCSTATUS, @BALANCE)", cnMain);
            Build_INSERT_Parameters(aAccount);
        }

        private void Create_UPDATE_Command(Account aAccount)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed
            daMain.UpdateCommand = new SqlCommand("UPDATE Account SET IDPASSPORT =@IDPASSPORT, RESERVATIONREF =@RESERVATIONREF, ACCSTATUS =@ACCSTATUS, BALANCE =@BALANCE" + " WHERE ID =@ID", cnMain);
            Build_UPDATE_Parameters(aAccount);
        }

        private string Create_DELETE_Command(Account aAccount)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Account WHERE ID = @ID", cnMain); // may use idpassport

            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }
        public bool UpdateDataSource(Account aAccount)
        {
            bool success = true;
            Create_INSERT_Command(aAccount);
            Create_UPDATE_Command(aAccount);
            Create_DELETE_Command(aAccount);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

    }
}
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
    public class PaymentDB : DB
    {
        //Data members        
        private string table1 = "Payment";
        private string sqlLocal1 = "SELECT * FROM Payment";


        //Need to create enums for correct table access

        private Collection<Payment> payments;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public PaymentDB() : base()
        {
            payments = new Collection<Payment>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }

        public Collection<Payment> AllPayments
        {
            get
            {
                return payments;
            }
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Payment aPayment, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aPayment, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aPayment, dataTable)];
                    FillRow(aRow, aPayment, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aPayment, dataTable)];
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
            Payment aPayment;

            //READ from the table  

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Guest object
                    aPayment = new Payment();

                    aPayment.PaymentID = Convert.ToInt32(myRow["Id"]);
                    aPayment.AccountID = Convert.ToInt32(myRow["ACCOUNTID"]);
                    aPayment.Type = Convert.ToString(myRow["TYPE"]).TrimEnd();
                    aPayment.Amount = Convert.ToDecimal(myRow["AMOUNT"]);

                    payments.Add(aPayment);
                }
            }
        }
        private void FillRow(DataRow aRow, Payment aPayment, DB.DBOperation operation)
        {
            aRow["Id"] = aPayment.PaymentID;  //NOTE square brackets to indicate index of collections of fields in row.
            aRow["ACCOUNTID"] = aPayment.AccountID;
            aRow["TYPE"] = aPayment.Type;
            aRow["AMOUNT"] = aPayment.Amount;

        }

        //The FindRow method finds the row for a specific Guest(by ID)  in a specific table
        private int FindRow(Payment aPayment, string table)
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
                    if (aPayment.PaymentID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["Id"]))
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
        private void Build_INSERT_Parameters(Payment aPayment)
        {
            //Create Parameters to communicate with SQL INSERT
            //https://www.google.co.za/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=size+in+bytes+of+Int+in+SQL

            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.Int, 10, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@ACCOUNTID", SqlDbType.Int, 20, "ACCOUNTID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@TYPE", SqlDbType.VarChar, 20, "TYPE");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@AMOUNT", SqlDbType.Decimal, 20, "AMOUNT");
            daMain.InsertCommand.Parameters.Add(param);

            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Build_UPDATE_Parameters(Payment aPayment)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.Int, 10, "ID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@ACCOUNTID", SqlDbType.Int, 20, "ACCOUNTID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@TYPE", SqlDbType.VarChar, 20, "TYPE");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@AMOUNT", SqlDbType.Decimal, 20, "AMOUNT");
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
        private void Create_INSERT_Command(Payment aPayment)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Payment (ID, ACCOUNTID, TYPE, AMOUNT) VALUES (@ID, @ACCOUNTID, @TYPE, @AMOUNT)", cnMain);
            Build_INSERT_Parameters(aPayment);
        }

        private void Create_UPDATE_Command(Payment aPayment)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed
            daMain.UpdateCommand = new SqlCommand("UPDATE Payment SET ACCOUNTID =@ACCOUNTID, TYPE =@TYPE, AMOUNT =@AMOUNT " + "WHERE ID =@ID", cnMain);
            Build_UPDATE_Parameters(aPayment);
        }

        private string Create_DELETE_Command(Payment aPayment)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Payment WHERE ID = @ID", cnMain); // may use idpassport

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
        public bool UpdateDataSource(Payment aPayment)
        {
            bool success = true;
            Create_INSERT_Command(aPayment);
            Create_UPDATE_Command(aPayment);
            Create_DELETE_Command(aPayment);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

    }
}

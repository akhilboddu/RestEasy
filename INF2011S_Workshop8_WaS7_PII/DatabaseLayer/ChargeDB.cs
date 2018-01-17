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
    public class ChargeDB : DB
    {
        //Data members        
        private string table1 = "Charge";
        private string sqlLocal1 = "SELECT * FROM Charge";


        //Need to create enums for correct table access

        private Collection<Charge> charges;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public ChargeDB() : base()
        {
            charges = new Collection<Charge>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }

        public Collection<Charge> AllCharges
        {
            get
            {
                return charges;
            }
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Charge aCharge, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aCharge, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCharge, dataTable)];
                    FillRow(aRow, aCharge, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aCharge, dataTable)];
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
            Charge aCharge;

            //READ from the table  

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Guest object
                    aCharge = new Charge();

                    aCharge.ChargeID = Convert.ToInt32(myRow["Id"]);
                    aCharge.AccountID = Convert.ToInt32(myRow["ACCOUNTID"]);
                    aCharge.Type = Convert.ToString(myRow["TYPE"]).TrimEnd();
                    aCharge.Amount = Convert.ToDecimal(myRow["AMOUNT"]);

                    charges.Add(aCharge);
                }
            }
        }
        private void FillRow(DataRow aRow, Charge aCharge, DB.DBOperation operation)
        {
            aRow["Id"] = aCharge.ChargeID;  //NOTE square brackets to indicate index of collections of fields in row.
            aRow["ACCOUNTID"] = aCharge.AccountID;
            aRow["TYPE"] = aCharge.Type;
            aRow["AMOUNT"] = aCharge.Amount;

        }

        //The FindRow method finds the row for a specific Guest(by ID)  in a specific table
        private int FindRow(Charge aCharge, string table)
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
                    if (aCharge.ChargeID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["Id"]))
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
        private void Build_INSERT_Parameters(Charge aCharge)
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

        private void Build_UPDATE_Parameters(Charge aCharge)
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
        private void Create_INSERT_Command(Charge aCharge)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Charge (ID, ACCOUNTID, TYPE, AMOUNT) VALUES (@ID, @ACCOUNTID, @TYPE, @AMOUNT)", cnMain);
            Build_INSERT_Parameters(aCharge);
        }

        private void Create_UPDATE_Command(Charge aCharge)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed
            daMain.UpdateCommand = new SqlCommand("UPDATE Charge SET ACCOUNTID =@ACCOUNTID, TYPE =@TYPE, AMOUNT =@AMOUNT " + "WHERE ID =@ID", cnMain);
            Build_UPDATE_Parameters(aCharge);
        }

        private string Create_DELETE_Command(Charge aCharge)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Charge WHERE ID = @ID", cnMain); // may use idpassport

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
        public bool UpdateDataSource(Charge aCharge)
        {
            bool success = true;
            Create_INSERT_Command(aCharge);
            Create_UPDATE_Command(aCharge);
            Create_DELETE_Command(aCharge);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

    }
}

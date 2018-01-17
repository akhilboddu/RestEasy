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
    class RestEasyDB : DB
    {
        //Data members        
        private string table1 = "Guest";
        private string sqlLocal1 = "SELECT * FROM Guest";


        //Need to create enums for correct table access

        private Collection<Guest> guests;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public RestEasyDB() : base()
        {
            guests = new Collection<Guest>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }

        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Guest aGuest, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aGuest, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
                    FillRow(aRow, aGuest, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aGuest, dataTable)];
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
            Guest aGuest;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Guest object
                    aGuest = new Guest();
                    //Obtain each Guest attribute from the specific field in the row in the table
                    aGuest.GuestID = Convert.ToString(myRow["ID"]).TrimEnd();
                    aGuest.FirstName = Convert.ToString(myRow["FIRSTNAME"]).TrimEnd();
                    aGuest.LastName = Convert.ToString(myRow["LASTNAME"]).TrimEnd();
                    aGuest.GuestAddress = Convert.ToString(myRow["GUESTADDRESS"]).TrimEnd();
                    aGuest.EmailAddress = Convert.ToString(myRow["EMAIL"]).TrimEnd();
                    aGuest.IdPassport = Convert.ToString(myRow["IDPASSPORT"]).TrimEnd();
                    guests.Add(aGuest);
                }
            }
        }
        private void FillRow(DataRow aRow, Guest aGuest, DB.DBOperation operation)
        {

            aRow["ID"] = aGuest.GuestID;  //NOTE square brackets to indicate index of collections of fields in row.
            aRow["IDPASSPORT"] = aGuest.IdPassport;
            aRow["FIRSTNAME"] = aGuest.FirstName;
            aRow["LASTNAME"] = aGuest.LastName;
            aRow["GUESTADDRESS"] = aGuest.GuestAddress;
            aRow["EMAIL"] = aGuest.EmailAddress;

        }

        //The FindRow method finds the row for a specific Guest(by ID)  in a specific table
        private int FindRow(Guest aGuest, string table)
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
                    if (aGuest.GuestID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
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
        private void Build_INSERT_Parameters(Guest aGuest)
        {
            //Create Parameters to communicate with SQL INSERT
            //https://www.google.co.za/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=size+in+bytes+of+Int+in+SQL

            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.VarChar, 10, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@FIRSTNAME", SqlDbType.VarChar, 20, "FIRSTNAME");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@LASTNAME", SqlDbType.VarChar, 20, "LASTNAME");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@GUESTADDRESS", SqlDbType.NVarChar, 200, "GUESTADDRESS");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@EMAIL", SqlDbType.NVarChar, 100, "EMAIL");
            daMain.InsertCommand.Parameters.Add(param);

            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Build_UPDATE_Parameters(Guest aGuest)
        {
            SqlParameter param = default(SqlParameter);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@FIRSTNAME", SqlDbType.VarChar, 20, "FIRSTNAME");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@LASTNAME", SqlDbType.VarChar, 20, "LASTNAME");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@GUESTADDRESS", SqlDbType.NVarChar, 200, "GUESTADDRESS");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@EMAIL", SqlDbType.NVarChar, 100, "EMAIL");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }
        private void Create_INSERT_Command(Guest aGuest)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Guest (ID, FIRSTNAME, LASTNAME, GUESTADDRESS, IDPASSPORT, EMAIL) VALUES (@ID, @FIRSTNAME, @LASTNAME, @GUESTADDRESS, @IDPASSPORT, @EMAIL)", cnMain);
            Build_INSERT_Parameters(aGuest);
        }

        private void Create_UPDATE_Command(Guest aGuest)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed
            daMain.UpdateCommand = new SqlCommand("UPDATE Guest SET FIRSTNAME =@FIRSTNAME, LASTNAME =@LASTNAME, GUESTADDRESS =@GUESTADDRESS, EMAIL =@EMAIL " + "WHERE IDPASSPORT =@IDPASSPORT", cnMain);
            Build_UPDATE_Parameters(aGuest);
        }

        private string Create_DELETE_Command(Guest aGuest)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Guest WHERE IDPASSPORT = @IDPASSPORT", cnMain); // may use idpassport

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
        public bool UpdateDataSource(Guest aGuest)
        {
            bool success = true;
            Create_INSERT_Command(aGuest);
            Create_UPDATE_Command(aGuest);
            Create_DELETE_Command(aGuest);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

    }
}


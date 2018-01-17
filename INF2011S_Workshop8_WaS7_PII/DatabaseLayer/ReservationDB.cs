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

    /*
     CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL PRIMARY KEY,
	STARTDATE DATE NOT NULL,
	ENDDATE DATE NOT NULL,
	IDPASSPORT VARCHAR (20) NOT NULL,
	ROOM INT NOT NULL
)
         */
    public class ReservationDB : DB
    {
        //Data members        
        private string table1 = "Reservation";
        private string sqlLocal1 = "SELECT * FROM Reservation";


        //Need to create enums for correct table access

        private Collection <Reservation> reservations;

        //***every column (field) in a database table has a name, data type and the datatype has a size
        //*** we will use this struct later in the workshop series
        public struct ColumnAttribs
        {
            public string myName;
            public SqlDbType myType;
            public int mySize;
        }

        //Default Constructor
        public ReservationDB() : base()
        {
            reservations = new Collection<Reservation>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);

        }

        public Collection<Reservation> AllReservations
        {
            get
            {
                return reservations;
            }
        }

        public DataSet GetDataSet()
        {
            return dsMain;
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Reservation aReservation, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table1;
            //***In this case the dataset change refers to adding to a database table
            //***We now have  3 tables.. once they are placed in an array .. this becomes easier 

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aReservation, operation);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    // to Edit
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aReservation, dataTable)];
                    FillRow(aRow, aReservation, operation);
                    break;
                case DB.DBOperation.Delete:
                    //to delete
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aReservation, dataTable)];
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
            Reservation aReservation;

            //READ from the table  

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Guest object
                    aReservation = new Reservation();

                    aReservation.Id = Convert.ToInt32(myRow["Id"]);
                    aReservation.StartDate = Convert.ToString(myRow["STARTDATE"]).TrimEnd();
                    aReservation.EndDate = Convert.ToString(myRow["ENDDATE"]).TrimEnd();
                    aReservation.IdPassport = Convert.ToString(myRow["IDPASSPORT"]).TrimEnd();
                    aReservation.RoomNumber = Convert.ToInt32(myRow["ROOM"]);

                    reservations.Add(aReservation);
                }
            }
        }
        private void FillRow(DataRow aRow, Reservation aReservation, DB.DBOperation operation)
        {
            aRow["ID"] = aReservation.Id;  //NOTE square brackets to indicate index of collections of fields in row.
            aRow["STARTDATE"] = aReservation.StartDate;
            aRow["ENDDATE"] = aReservation.EndDate;
            aRow["IDPASSPORT"] = aReservation.IdPassport;
            aRow["ROOM"] = aReservation.RoomNumber;

        }

        //The FindRow method finds the row for a specific Guest(by ID)  in a specific table
        private int FindRow(Reservation aReservation, string table)
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
                    if (aReservation.Id == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["Id"]))
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
        private void Build_INSERT_Parameters(Reservation aReservation)
        {
            //Create Parameters to communicate with SQL INSERT
            //https://www.google.co.za/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=size+in+bytes+of+Int+in+SQL

            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.Int, 10, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@STARTDATE", SqlDbType.Date, 20, "STARTDATE");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ENDDATE", SqlDbType.Date, 20, "ENDDATE");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ROOM", SqlDbType.Int, 10, "ROOM");
            daMain.InsertCommand.Parameters.Add(param);

            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Build_UPDATE_Parameters(Reservation aReservation)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@ID", SqlDbType.Int, 10, "ID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            //Do the same for Description & answer -ensure that you choose the right size
            param = new SqlParameter("@STARTDATE", SqlDbType.Date, 20, "STARTDATE");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ENDDATE", SqlDbType.Date, 20, "ENDDATE");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@IDPASSPORT", SqlDbType.VarChar, 20, "IDPASSPORT");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ROOM", SqlDbType.Int, 10, "ROOM");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ID", SqlDbType.VarChar, 20, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }
        private void Create_INSERT_Command(Reservation aReservation)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Reservation (ID, STARTDATE, ENDDATE, IDPASSPORT, ROOM) VALUES (@ID, @STARTDATE, @ENDDATE, @IDPASSPORT, @ROOM)", cnMain);
            Build_INSERT_Parameters(aReservation);
        }

        private void Create_UPDATE_Command(Reservation aReservation)
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed
            daMain.UpdateCommand = new SqlCommand("UPDATE Reservation SET STARTDATE =@STARTDATE, ENDDATE =@ENDDATE, IDPASSPORT =@IDPASSPORT, ROOM =@ROOM " + "WHERE IDPASSPORT =@IDPASSPORT", cnMain);
            Build_UPDATE_Parameters(aReservation);
        }

        private string Create_DELETE_Command(Reservation aReservation)
        {
            string errorString = null;
            //Create the command that must be used to delete values from the the appropriate table
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Reservation WHERE ID = @ID", cnMain); // may use idpassport

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
        public bool UpdateDataSource(Reservation aReservation)
        {
            bool success = true;
            Create_INSERT_Command(aReservation);
            Create_UPDATE_Command(aReservation);
            Create_DELETE_Command(aReservation);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion

        public DataTable ReadDataGender()
        {
            //Declare references (for table, reader and command)
            DataTable genderTable = new DataTable();
            SqlDataReader reader;
            SqlCommand command;
            string selectString = "select STARTDATE, count(Id) as ReservationTotal from Reservation group by STARTDATE ";
            try
            {
                command = new SqlCommand(selectString, cnMain);           //Create a new command
                cnMain.Open();                                                                       //open the connection
                command.CommandType = CommandType.Text;                   //Command Type
                reader = command.ExecuteReader();                        //Read from table
                //  read data from readerObject and load in table                  
                genderTable.Load(reader);
                reader.Close();     //close the reader 
                cnMain.Close();     //close the connection
                return genderTable;
            }
            catch (Exception ex)
            {
                return (null);
            }
        }

    }
}

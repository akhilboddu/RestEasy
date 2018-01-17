using INF2011S_Workshop8_WaS7_PII.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class ReservationController
    {
        ReservationDB reservationDB;
        Collection<Reservation> reservations;   //***W3
        Reservation reservation; // holds a single reservation object used to make a booking
        #region Properties
        public Collection<Reservation> AllReservations
        {
            get
            {
                return reservations;
            }
        }

        internal Reservation Reservation
        {
            get
            {
                return Reservation1;
            }

            set
            {
                Reservation1 = value;
            }
        }

        internal Reservation Reservation1
        {
            get
            {
                return reservation;
            }

            set
            {
                reservation = value;
            }
        }
        #endregion

        bool[,] reservedRooms;

        public ReservationController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            reservationDB = new ReservationDB();
            reservations = reservationDB.AllReservations;
            reservation = new Reservation();

            reservedRooms = new bool[31, 5];
            for (int x = 0; x <31; x++)
            {
                for(int y = 0; y <5; y++)
                {
                    reservedRooms[x, y] = false;
                }
            }

            determineBookedRooms();
        }

        public void calculateBookingCost()
        {
            reservation.ReservationAmount = 0; // reset reservation amount

            int dayStart = Convert.ToInt32(reservation.StartDate);
            int dayEnd = Convert.ToInt32(reservation.EndDate);
            //MessageBox.Show("Start:\t"+dayStart);

            //MessageBox.Show("End:\t" + dayEnd);

            // low season
            if (dayEnd <= 7)
            {
                reservation.ReservationAmount += 550 * (dayEnd - dayStart);
                return;
            }

            // mid season
            if (dayEnd <= 15)
            {
                if (dayStart >= 8)
                {
                    reservation.ReservationAmount += 750 * (dayEnd - dayStart);
                }
                else
                {
                    reservation.ReservationAmount += 550 * (7 - dayStart) + 750 * (dayEnd - 7);
                }
                return;
            }

            // peak season
            if (dayEnd > 15)
            {
                if (dayStart >= 16)
                {
                    reservation.ReservationAmount += 995 * (dayEnd - dayStart);
                }

                if (dayStart > 7 && dayStart <= 15)
                {
                    reservation.ReservationAmount += 995 * (dayEnd - 15) + 750 * (dayStart - 7);
                }

                if (dayStart < 8)
                {
                    reservation.ReservationAmount += 550 * (7 - dayStart) + (650 * 8) + 995 * (dayEnd - 15);
                }
                return;
            }
        }

        public void calculateBookingCost(DateTime start, DateTime end)
        {

            int dayStart = start.Day;
            int dayEnd = end.Day;

            // low season
            if (dayEnd <= 7)
            {
                reservation.ReservationAmount += 550 * (dayEnd - dayStart);
                return;
            }

            // mid season
            if (dayEnd <= 15)
            {
                if (dayStart >= 8)
                {
                    reservation.ReservationAmount += 750 * (dayEnd - dayStart);

                }
                else
                {
                    reservation.ReservationAmount += 550 * (7 - dayStart) + 750 * (dayEnd - 7);
                }
                return;
            }

            // peak season
            if (dayEnd > 15)
            {
                if (dayStart >= 16)
                {
                    reservation.ReservationAmount += 995 * (dayEnd - dayStart);
                }

                if (dayStart > 7 && dayStart <= 15)
                {
                    reservation.ReservationAmount += 995 * (dayEnd - 15) + 750 * (dayStart - 7);
                }

                if (dayStart < 8)
                {
                    reservation.ReservationAmount += 550 * (7 - dayStart) + (650 * 8) + 995 * (dayEnd - 15);
                }
                return;
            }


        }

        #region Database Communication
        public void DataMaintenance(Reservation aReservation, DB.DBOperation operation)
        {
            int index = 0;
            //perform a given database operation to the dataset in meory; 
            reservationDB.DataSetChange(aReservation, operation);
            //perform operations on the collection
            switch (operation)
            {
                case DB.DBOperation.Add:
                    //*** Add the Guest to the Collection
                    reservations.Add(aReservation);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aReservation);
                    reservations[index] = aReservation;  // replace Guest at this index with the updated Guest
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aReservation);  // find the index of the specific Guest in collection
                    reservations.RemoveAt(index);  // remove that Guest form the collection
                    break;
            }
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Reservation res)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return reservationDB.UpdateDataSource(res);
        }
        #endregion

        #region Search Methods
        public Reservation Find(int id)
        {
            int index = 0;
            bool found = (reservations[index].Id == id);
            int count = reservations.Count;
            while (!(found) && (index < reservations.Count - 1))
            {
                index = index + 1;
                found = (reservations[index].Id == id);   // this will be TRUE if found
            }
            return reservations[index];  // this is the one!  
        }

        //This method receives a Guest ID as a parameter; finds the Guest object in the collection of employees and then returns this object
        public Reservation Find(string id)
        {
            int index = 0;
            bool found = (reservations[index].IdPassport == id);
            int count = reservations.Count;
            while (!(found) && (index < reservations.Count - 1))
            {
                index = index + 1;
                found = (reservations[index].IdPassport == id);   // this will be TRUE if found
            }
            return reservations[index];  // this is the one!  
        }

        public Reservation Find(string id, bool pointless)
        {
            int index = 0;
            bool found = (reservations[index].Id == Convert.ToInt32(id));
            int count = reservations.Count;
            while (!(found) && (index < reservations.Count - 1))
            {
                index = index + 1;
                found = (reservations[index].Id == Convert.ToInt32(id));   // this will be TRUE if found
            }
            return reservations[index];  // this is the one!  
        }

        public int FindIndex(Reservation aReservation)
        {
            int counter = 0;
            bool found = false;
            found = (aReservation.IdPassport == reservations[counter].IdPassport);
            while (!(found) & counter < reservations.Count - 1)
            {
                counter += 1;
                found = (aReservation.IdPassport == reservations[counter].IdPassport);
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

        // determine which rooms are reserved
        public void determineBookedRooms()
        {
            // check the reservation dates and set room unavailable
            foreach (Reservation res in reservations)
            {
                int start = Convert.ToDateTime(res.StartDate).Day;
                int end = Convert.ToDateTime(res.EndDate).Day;
                int room = res.RoomNumber;
                for (int x =start; x < end; x++)
                {
                    reservedRooms[x, room-1] = true;
                }
            }
        }

        // determine which rooms can be booked for a stay period
        public bool[] allocateRoom(int startDay, int endDay)
        {
            bool[] unavailable = { false, false, false, false, false};

            // loop through stay period
            for (int i = startDay; i < endDay; i++)
            {
                // loop through rooms
                for(int j =0; j < 5; j++)
                {
                    if (reservedRooms[i, j] == true)
                    {
                        unavailable[j] = true;
                    }
                }
                
            }

            return unavailable;
        }

        public bool myownfindmethod(string id)
        {
            bool isFound = false;
            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].IdPassport.Equals(id))
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

        public bool findResId(int resID)
        {
            bool isFound = false;
            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].Id == resID)
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

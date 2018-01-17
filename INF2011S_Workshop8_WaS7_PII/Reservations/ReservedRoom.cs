using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.ObjectModel;
using INF2011S_Workshop8_WaS7_PII.BusinessLayer;

namespace INF2011S_Workshop8_WaS7_PII.Reservations
{
    class ReservedRoom
    {
        // determines whether a room is booked or not
        private enum ReservationStatus
        {
            AVAILABLE,
            RESERVED
        }

        private string reservationID;
        private Calendar myCal = CultureInfo.InvariantCulture.Calendar;
        private DateTime date;
        private int bookingNumber;
        private ReservationStatus status;
        private Collection<Reservation> reservedRooms;

        public ReservedRoom()
        {
            reservedRooms = new Collection<Reservation>();
        }

        #region Shift Methods
        public bool Add2Shift(Reservation reserved)
        {
            bool addedToCollection = true;

            if (reservedRooms.Count == 0)
            { reservedRooms.Add(reserved); }
            else
            {
                if (reservedRooms.Contains(reserved))
                {
                    addedToCollection = false;
                }
                else
                {
                    reservedRooms.Add(reserved);
                }
                return addedToCollection;
            }
            return addedToCollection;
        }

        public void RemoveFromReservation(Reservation reserved)
        {
            reservedRooms.Remove(reserved);
        }
        #endregion


        public string ReservationID
        {
            get
            {
                return reservationID;
            }

            set
            {
                reservationID = value;
            }
        }

        public Calendar MyCal
        {
            get
            {
                return myCal;
            }

            set
            {
                myCal = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

        }

        public int BookingNumber
        {
            get
            {
                return bookingNumber;
            }

            set
            {
                bookingNumber = value;
            }
        }

        private ReservationStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        internal Collection<Reservation> ReservedRooms
        {
            get
            {
                return reservedRooms;
            }
        }


    }
}

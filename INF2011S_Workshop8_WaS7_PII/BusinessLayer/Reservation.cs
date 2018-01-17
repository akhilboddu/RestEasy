using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class Reservation
    {

        private int id;
        private string startDate; // yyyy/mm/dd
        private string endDate;
        private string idPassport;
        private int roomNumber;
        private decimal reservationAmount;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public string IdPassport
        {
            get
            {
                return idPassport;
            }

            set
            {
                idPassport = value;
            }
        }

        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }

            set
            {
                roomNumber = value;
            }
        }

        public decimal ReservationAmount
        {
            get
            {
                return reservationAmount;
            }

            set
            {
                reservationAmount = value;
            }
        }

        public Reservation()
        {

            // random reservation number
            string temp = "";
            System.Random random = new System.Random();
            for (int i = 0; i <=5; i++)
            {
                temp += Convert.ToString(Convert.ToInt32(random.Next(0, 9)));
                id = Convert.ToInt32(temp);
            }

            ReservationAmount = 0;
        } // default

        public Reservation(string start, string end, string id, int room)
        {
            StartDate = start;
            EndDate = end;
            IdPassport = id;
            RoomNumber = room;
        }

        public void generateId()
        {
            string temp = "";
            System.Random random = new System.Random();
            for (int i = 0; i <= 5; i++)
            {
                temp += Convert.ToString(Convert.ToInt32(random.Next(0, 9)));
                id = Convert.ToInt32(temp);
            }
        }


    }
}

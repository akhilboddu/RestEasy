using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    /*
    *
    * CREATE TABLE [dbo].[Account]
    (
        [Id] INT NOT NULL PRIMARY KEY,
        IDPASSPORT VARCHAR (20) NOT NULL,
        RESERVATIONREF INT NOT NULL,
        ACCSTATUS BIT DEFAULT 0 NOT NULL,
        BALANCE DECIMAL (7, 2) NOT NULL
    )
    * 
    */

    public class Account
    {
        private ReservationController reservationController;
        private GuestController guestController;

        private int accountID; // primary key
        private string IdPassport;
        private string reservationRef;
        private int status;
        private decimal balance;

        public Account()
        {
            string temp = "";
            System.Random random = new System.Random();
            for (int i = 0; i <= 5; i++)
            {
                temp += Convert.ToString(Convert.ToInt32(random.Next(0, 9)));
                accountID = Convert.ToInt32(temp);
            }
        }

        public Account(ReservationController resCon, GuestController guestCon)
        {
            reservationController = resCon;
            guestController = guestCon;

            string temp = "";
            System.Random random = new System.Random();
            for (int i = 0; i <= 5; i++)
            {
                temp += Convert.ToString(Convert.ToInt32(random.Next(0, 9)));
                accountID = Convert.ToInt32(temp);
            }

            reservationRef = Convert.ToString(reservationController.Reservation.Id);


            IDPassport = guestController.AllGuests[guestController.AllGuests.Count - 1].IdPassport;
            reservationController.calculateBookingCost();
            status = 0;
            balance = reservationController.Reservation.ReservationAmount;
        }


        #region getters and setters
        public int AccountID
        {
            get
            {
                return accountID;
            }

            set
            {
                accountID = value;
            }
        }

        public string IDPassport
        {
            get
            {
                return IdPassport;
            }

            set
            {
                IdPassport = value;
            }
        }

        public string ReservationRef
        {
            get
            {
                return reservationRef;
            }

            set
            {
                reservationRef = value;
            }
        }

        public int Status
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

        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }
    #endregion
    }
}

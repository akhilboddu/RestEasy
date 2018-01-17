using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    /*
     CREATE TABLE [dbo].[Payment]
    (
	    [Id] INT NOT NULL PRIMARY KEY,
	    ACCOUNTID INT NOT NULL,
	    TYPE VARCHAR (20) NOT NULL,
	    AMOUNT DECIMAL (7, 2) NOT NULL
    )
             */
    public class Payment
    {

        private int paymentID;
        private string type;
        private int accountID;
        private decimal amount;

        public Payment()
        {
            string temp = "";
            System.Random random = new System.Random();
            for (int i = 0; i <= 5; i++)
            {
                temp += Convert.ToString(Convert.ToInt32(random.Next(0, 9)));
                paymentID = Convert.ToInt32(temp);
            }
        }

        public int PaymentID
        {
            get
            {
                return paymentID;
            }

            set
            {
                paymentID = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

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

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
    }
}

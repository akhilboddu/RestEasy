using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public class Guest
    {
        private string guestID;
        private string firstName;
        private string lastName;
        private string idPassport;
        private string guestAddress;
        private string emailAddress;
        public string specialReqs;

        public Guest(string first, string last, string id, string address, string email, string reqs)
        {
            // autogen guestId

            System.Random random = new System.Random();
            //GuestID += LastName.Substring(0, 3).ToUpper();
            for (int i = 0; i <= 10; i++)
            {
                GuestID += random.Next(0, 9);
            }

            FirstName = first;
            LastName = last;
            id = IdPassport;
            GuestAddress = address;
            EmailAddress = email;
            specialReqs = reqs;
        }

        public Guest()
        {
            System.Random random = new System.Random();
            // GuestID += LastName.Substring(0, 3).ToUpper();
            for (int i = 0; i <= 10; i++)
            {
                GuestID += random.Next(0, 9);
            }
        } // default




        public string GuestID
        {
            get
            {
                return guestID;
            }

            set
            {
                guestID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
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

        public string GuestAddress
        {
            get
            {
                return guestAddress;
            }

            set
            {
                guestAddress = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }

            set
            {
                emailAddress = value;
            }
        }
    }

}


using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class GuestForm : Form
    {

        //Attributes
        Guest aGuest;
        GuestController guestController;
        private Collection<Guest> guests;
        private bool guestExists;
        private ReservationController reservationController;
        private RestEasyMDIParent restEasy;

        internal Collection<Guest> Guests
        {
            get
            {
                return guests;
            }

            set
            {
                guests = value;
            }
        }

        public bool GuestExists
        {
            get
            {
                return guestExists;
            }

            set
            {
                guestExists = value;
            }
        }

        public GuestForm(ReservationController res, RestEasyMDIParent re)
        {
            InitializeComponent();
            panelVerification.Show();
            panelGuestDetails.Hide();
            btnSearchAgain.Hide();
            guestController = new GuestController(); // pass in instance
            Guests = guestController.AllGuests;
            reservationController = res;
            restEasy = re;

            this.MdiParent = restEasy;
        }

        private void btnConfirmGuest_Click(object sender, EventArgs e)
        {
            if (hasEmptyFields())
            {
                MessageBox.Show("Please fill in missing details");
            }
            Match matchFirstName = Regex.Match(txtFirstName.Text, @"(?i)^[a-z]+");
            Match matchLastName = Regex.Match(txtLastName.Text, @"(?i)^[a-z]+");
            if (matchFirstName.Success == false || matchFirstName.Success == false)
            {
                MessageBox.Show("Please correct fields before continuing.");
            }
            else
            {
                PopulateObject();
                guestController.DataMaintenance(aGuest, DatabaseLayer.DB.DBOperation.Add);
                guestController.FinalizeChanges(aGuest);
                // MessageBox.Show("Guest added!");
                PaymentForm paymentForm = new PaymentForm(restEasy, reservationController, aGuest);
                paymentForm.Show();
                this.Hide();

                // clearGuestDetails();

            }
            
        }

        #region utility methods

        // assumes correct input
        private void PopulateObject()
        {

            aGuest = new Guest(); // instantiates guestID
            aGuest.IdPassport = txtID2.Text;
            aGuest.FirstName = txtFirstName.Text;
            aGuest.LastName = txtLastName.Text;
            aGuest.GuestAddress = txtAddress.Text;
            aGuest.EmailAddress = txtEmail.Text;
            reservationController.Reservation.IdPassport = txtID2.Text;
        }
        #endregion

        private void btnCreateGuest_Click(object sender, EventArgs e)
        {
            switchToGuestDetailsPanel();
        }

        public void switchToGuestDetailsPanel()
        {
            panelVerification.Hide();
            btnSearchAgain.Show();
            panelGuestDetails.Show();
        }

        public void switchToVerificationDetailsPanel()
        {
            panelGuestDetails.Hide();
            btnSearchAgain.Hide();
            panelVerification.Show();
        }

        public void clearGuestDetails()
        {
            txtID2.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }

        public bool hasEmptyFields()
        {
            bool isEmpty = false;  
            if(txtID2.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtAddress.Text == "" || txtEmail.Text == "")
            {
                isEmpty = true;
            }

            return isEmpty;
        }

        private void btnCheckIfExists_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Please fill in missing ID/Passport");
            }
            else
            {
                aGuest = guestController.Find(txtID.Text.Trim());
                int index = guestController.FindIndex(aGuest);
                if (aGuest.IdPassport != txtID.Text)
                {
                    MessageBox.Show("Guest Does not exist. Please create new record.");
                    switchToGuestDetailsPanel();
                }
                else
                {
                    if (guestController.myownfindmethod(txtID.Text) == true)
                    {
                        MessageBox.Show("Guest found.");
                        viewRetrievedGuestDetails(index);
                        switchToGuestDetailsPanel();

                        // add id/passport attribute to reservation
                        reservationController.Reservation.IdPassport = txtID.Text;

                        // show payment form

                        PaymentForm paymentForm = new PaymentForm(restEasy, reservationController, aGuest);
                        paymentForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Guest Does not exist. Please create new record.");
                        switchToGuestDetailsPanel();

                    }
                    
                }

            }
        }

        public void viewRetrievedGuestDetails(int index)
        {
            txtID2.Text = Guests[index].IdPassport;
            txtFirstName.Text = Guests[index].FirstName;
            txtLastName.Text = Guests[index].LastName;
            txtAddress.Text = Guests[index].GuestAddress;
            txtEmail.Text = Guests[index].EmailAddress;
            makeFieldsReadOnly();
        }

        public void makeFieldsReadOnly()
        {
            txtID2.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtEmail.ReadOnly = true;
        }

        private void btnSearchAgain_Click(object sender, EventArgs e)
        {
            switchToVerificationDetailsPanel();
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReservationForm reservationForm = new ReservationForm(new ReservationController(), restEasy);
            reservationForm.Show();
        }
    }
}

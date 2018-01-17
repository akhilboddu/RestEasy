using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class EnquiryForm : Form
    {
        private GuestController guestController;
        private ReservationController resController;
        private AccountController accountController;

        private Collection<Reservation> reservations;
        private Collection<Guest> guests;
        private Collection<Account> guestAccounts;

        private Reservation aReservation;
        private Guest aGuest;
        private Account anAccount;

        RestEasyMDIParent restEasy;


        public EnquiryForm(RestEasyMDIParent re)
        {
            resController = new ReservationController();
            guestController = new GuestController();
            accountController = new AccountController();
            reservations = resController.AllReservations;
            guests = guestController.AllGuests;
            guestAccounts = accountController.AllAccounts;
            InitializeComponent();
            hideAllPanels();
            restEasy = re;
        }

        public void hideAllPanels()
        {
            Panel_Reservation.Hide();
            panel_Listview.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    {
                        viewReservation();
                        break;
                    }

                case 1:
                    {
                        Panel_Reservation.Hide();
                        panel_EnterResID.Show();
                        setUpListView();

                        break;
                    }
            }
        }



        public void viewReservation()
        {
            Panel_Reservation.Show();
            panel_EnterResID.Show();
            panel_ReservationDetails.Hide();
            panel_Listview.Hide();
        }

        public void switchToResDetailsPanel()
        {
            panel_EnterResID.Hide();
            panel_ReservationDetails.Show();
        }

        public void viewExtractedDetails(int index)
        {
            aGuest = guestController.Find(reservations[index].IdPassport);
            int guestIndex = guestController.FindIndex(aGuest);

            lblResID.Text = reservations[index].Id.ToString();
            lblFname.Text = guests[guestIndex].FirstName;
            lblLname.Text = guests[guestIndex].LastName;
            lblSDate.Text = reservations[index].StartDate;
            lblEDate.Text = reservations[index].EndDate;

            //deposit amnt
            resController.calculateBookingCost(Convert.ToDateTime(reservations[index].StartDate), Convert.ToDateTime(reservations[index].EndDate));
            lblDepositAmount.Text = "R " + String.Format("{0:f2}", resController.Reservation.ReservationAmount * 1 / 10);

            //deposit status
            anAccount = accountController.Find(guestAccounts[index].IDPassport);
            int accountIndex = accountController.FindIndex(anAccount);

            if (guestAccounts[accountIndex].Status == 0)
            {
                lblDepositStatus.Text = "NOT PAID";
                panelDeposit.BackColor = Color.Red;
            }
            else
            {
                lblDepositStatus.Text = "PAID";
                panelDeposit.BackColor = Color.Aquamarine;
            }



        }

        private void btnSearchResID_Click_1(object sender, EventArgs e)
        {

            if (txtResID.Text == "")
            {
                MessageBox.Show("Please fill in the reservation ID");
            }
            else
            {
                string resId_as_string = txtResID.Text.Trim();
                int typedInresId;
                if (Int32.TryParse(resId_as_string, out typedInresId))
                {
                    //get index where ids are equal
                    aReservation = resController.Find(typedInresId);
                    int index = resController.FindIndex(aReservation);
                    //MessageBox.Show(index + " <- index of typedIn reference number");     //debug
                    if (aReservation.Id != Convert.ToInt32(resId_as_string))
                    {
                        MessageBox.Show("Reference Number does not exist. Please try again");
                    }
                    else
                    {
                        viewExtractedDetails(index);
                        switchToResDetailsPanel();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Reference number");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(restEasy);
            this.Hide();
            homePage.Show();
        }

        #region The list view

        public void setUpListView()
        {
            ListViewItem flaggedDetails;
            panel_Listview.Show();

            FlaggedGuests_listview.Clear();

            FlaggedGuests_listview.View = View.Details;
            FlaggedGuests_listview.FullRowSelect = true;


            FlaggedGuests_listview.Columns.Insert(0, "Guest ID", 120, HorizontalAlignment.Left);
            FlaggedGuests_listview.Columns.Insert(1, "First Name", 120, HorizontalAlignment.Left);
            FlaggedGuests_listview.Columns.Insert(2, "Last Name", 120, HorizontalAlignment.Left);
            FlaggedGuests_listview.Columns.Insert(3, "Account ID", 120, HorizontalAlignment.Left);
            FlaggedGuests_listview.Columns.Insert(4, "Balance", 120, HorizontalAlignment.Left);

            for (int i = 0; i < guestAccounts.Count; i++)
            {

                if (guestAccounts[i].Status == 0)
                {

                    //MessageBox.Show("show: " + guestAccounts[i].IDPassport);

                    // Guest ID
                    string _1 = guestAccounts[i].IDPassport;

                    // First name & Last Name
                    aGuest = guestController.Find(guestAccounts[i].IDPassport);
                    int index = guestController.FindIndex(aGuest);
                    string _2 = guests[index].FirstName;
                    string _3 = guests[index].LastName;

                    // Account ID
                    string _4 = guestAccounts[i].AccountID.ToString();

                    // Balance
                    string _5 = guestAccounts[i].Balance.ToString();

                    flaggedDetails = new ListViewItem(new[] { _1, _2, _3, _4, _5 });
                    FlaggedGuests_listview.Items.Add(flaggedDetails);
                }


                FlaggedGuests_listview.Refresh();
            }


            FlaggedGuests_listview.GridLines = true;

        }

        #endregion

        private void FlaggedGuests_listview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

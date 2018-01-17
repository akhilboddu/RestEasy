using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using System;
using System.Collections.Generic;
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
    public partial class PaymentForm : Form
    {
        RestEasyMDIParent restEasy;
        ReservationController reservationController;
        Guest aGuest;

        public PaymentForm(RestEasyMDIParent re, ReservationController res, Guest guest)
        {
            InitializeComponent();
            restEasy = re;
            reservationController = res;
            aGuest = guest;

            // set labels on initialisation
            lblDeposit.Text = "R"+ String.Format("{0:f2}", reservationController.Reservation.ReservationAmount*1/10);

            this.MdiParent = restEasy;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            // null and empty char checks

            if (txtCardHolderName.Text == null || txtCardHolderName.Text == "")
            {
                MessageBox.Show("Fill in missing fields");
                return;
            }

            if (txtCreditCardNumber.Text == null || txtCreditCardNumber.Text == "")
            {
                MessageBox.Show("Fill in missing fields");
                return;
            }

            if (txtCVVNumber.Text == null || txtCVVNumber.Text == "")
            {
                MessageBox.Show("Fill in missing fields");
                return;
            }

            if (txtOTP.Text == null || txtOTP.Text == "")
            {
                MessageBox.Show("Fill in missing fields");
                return;
            }

            // invalid entry checks
            Match matchCardHolderName = Regex.Match(txtCardHolderName.Text, @"(?i)^[a-z]+");

            if(matchCardHolderName.Success == false)
            {
                MessageBox.Show("Card holder name may only contain non-numeric characters (A-Z), (a-z).");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCreditCardNumber.Text, "^[0-9]+$")){
                MessageBox.Show("Card card number should only contain numeric values (0-9).");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCVVNumber.Text, "^[0-9]+$")){
                MessageBox.Show("CVV number should only contain numeric values (0-9).");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtOTP.Text, "^[0-9]+$")){
                MessageBox.Show("OTP Pin should only contain numeric values (0-9).");
                return;
            }

            // commit to database
            
            reservationController.Reservation.StartDate = "2017/12/" + reservationController.Reservation.StartDate;
            reservationController.Reservation.EndDate = "2012/12/" + reservationController.Reservation.EndDate;

            reservationController.DataMaintenance(reservationController.Reservation, DatabaseLayer.DB.DBOperation.Add);
            reservationController.FinalizeChanges(reservationController.Reservation);

            Account anAccount = new Account();

            anAccount.Status = 1; // paid
            anAccount.ReservationRef = Convert.ToString(reservationController.Reservation.Id);
            anAccount.IDPassport = aGuest.IdPassport;
            anAccount.Balance = reservationController.Reservation.ReservationAmount;

            AccountController accController = new AccountController();
            accController.DataMaintenance(anAccount, DatabaseLayer.DB.DBOperation.Add);
            accController.FinalizeChanges(anAccount);

            SummaryPage summaryPage = new SummaryPage(restEasy, reservationController, aGuest);
            this.Hide();
            summaryPage.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCardHolderName.Text = "";
            txtCreditCardNumber.Text = "";
            txtCVVNumber.Text = "";
            txtOTP.Text = "";
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(restEasy);
            this.Hide();
            homePage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // commit to database

            reservationController.Reservation.StartDate = "2017/12/" + reservationController.Reservation.StartDate;
            reservationController.Reservation.EndDate = "2012/12/" + reservationController.Reservation.EndDate;

            reservationController.DataMaintenance(reservationController.Reservation, DatabaseLayer.DB.DBOperation.Add);
            reservationController.FinalizeChanges(reservationController.Reservation);

            Account anAccount = new Account();
            anAccount.Status = 0; // paid
            anAccount.ReservationRef = Convert.ToString(reservationController.Reservation.Id);
            anAccount.IDPassport = aGuest.IdPassport;
            anAccount.Balance = reservationController.Reservation.ReservationAmount;

            AccountController accController = new AccountController();
            accController.DataMaintenance(anAccount, DatabaseLayer.DB.DBOperation.Add);
            accController.FinalizeChanges(anAccount);

            SummaryPage summaryPage = new SummaryPage(restEasy, reservationController, aGuest);
            this.Hide();
            summaryPage.Show();
        }
    }
}

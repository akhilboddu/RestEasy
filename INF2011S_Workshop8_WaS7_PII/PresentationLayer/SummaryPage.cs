using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class SummaryPage : Form
    {

        RestEasyMDIParent restEasy;
        ReservationController reservationController;
        Guest guest;

        public SummaryPage(RestEasyMDIParent re, ReservationController res, Guest aGuest)
        {
            InitializeComponent();
            restEasy = re;
            reservationController = res;
            this.MdiParent = restEasy;

            guest = aGuest;

            lblFirstName.Text = aGuest.FirstName;
            lblLastName.Text = aGuest.LastName;
            lblStartDate.Text = res.Reservation.StartDate;
            lblEndDate.Text = res.Reservation.EndDate;
            lblTotalAmount.Text = Convert.ToString(String.Format("{0:f2}", res.Reservation.ReservationAmount));
            lblReferenceNumber.Text = Convert.ToString(reservationController.Reservation.Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage(restEasy);
            homePage.Show();
        }

        private void SummaryPage_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmationLetter_Click(object sender, EventArgs e)
        {
            Email email = new Email(guest.FirstName, guest.LastName, Convert.ToString(reservationController.Reservation.Id), Convert.ToDateTime(reservationController.Reservation.StartDate), Convert.ToDateTime(reservationController.Reservation.EndDate), reservationController.Reservation.ReservationAmount);
            email.sendEmail("RestEasy Booking Confirmation", guest.EmailAddress);
        }
    }
}

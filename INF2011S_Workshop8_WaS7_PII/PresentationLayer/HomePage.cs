using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using System.Net.Mail;
using System.Net;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class HomePage : Form
    {
        // used to dock to MDI parent
        RestEasyMDIParent restEasy;

        public HomePage(RestEasyMDIParent re)
        {
            restEasy = re;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnAddReservation, "Add a new reservation");

            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.btnEditReservation, "Edit an existing reservation");

            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.SetToolTip(this.btnChargesPayments, "Add a charge or payment to an account");

            System.Windows.Forms.ToolTip ToolTip4 = new System.Windows.Forms.ToolTip();
            ToolTip4.SetToolTip(this.btnBookingEnquiry, "Make an enquiry on a reservation or guest");

            System.Windows.Forms.ToolTip ToolTip5 = new System.Windows.Forms.ToolTip();
            ToolTip5.SetToolTip(this.btnReport, "Create a report");

            System.Windows.Forms.ToolTip ToolTip6 = new System.Windows.Forms.ToolTip();
            ToolTip6.SetToolTip(this.btnExit, "Exit the system");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomPage roomPage = new RoomPage(restEasy);
            roomPage.Show(restEasy);
           
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnBookingEnquiry_Click(object sender, EventArgs e)
        {
            EnquiryForm enquiryForm = new EnquiryForm(restEasy);
            this.Hide();
            enquiryForm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportForm reportForm = new PresentationLayer.ReportForm(restEasy);
            reportForm.Show();
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditReservationForm editReservation = new EditReservationForm(restEasy);
            editReservation.Show();
        }

        private void btnChargesPayments_Click(object sender, EventArgs e)
        {
            ChargesPaymentsForm chargesPaymentsForm = new ChargesPaymentsForm(restEasy);
            this.Hide();
            chargesPaymentsForm.Show();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // Email email = new Email("Jaren", "Hendricks", "A6969", Convert.ToDateTime("2017/12/25"), Convert.ToDateTime("2017/12/26"), Convert.ToDecimal(2500));
           //  email.sendEmail("Confirmation letter", "hndjar002@myuct.ac.za");
        }
    }
}

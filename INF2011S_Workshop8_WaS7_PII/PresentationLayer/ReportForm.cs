using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class ReportForm : Form
    {
        RestEasyMDIParent restEasy;

        public ReportForm(RestEasyMDIParent re)
        {
            InitializeComponent();
            restEasy = re;

            // set default index to 0
            cbxReportType.SelectedIndex = 0;

            lblReportContent.Hide();
            cbxReportContent.Hide();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // 0 - occupancy
            // 1 - summary

            int index = cbxReportType.SelectedIndex;
            DateTime start = Convert.ToDateTime(dateStart.Text);
            DateTime end = Convert.ToDateTime(dateEnd.Text);
            generateReport(index, start, end);
        }

        public void generateReport(int reportType, DateTime start, DateTime end)
        {

            int period = end.Day - start.Day;

            switch (reportType)
            {
                case 0: // occupancy - reservations
                    {
                        ReservationController reservationController = new ReservationController();
                        Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                        PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("./../../Reports/occupancy-report"+start.Day+".pdf", FileMode.Create));
                        doc.Open();

                        Paragraph paragraph = new Paragraph("Occupancy Report - " + start.Day + "/12/2017 until " + end.Day + "/12/2017");
                        doc.Add(paragraph);
   
                        int counter = 0; // keep track of occupancy for the period
                        foreach (Reservation reservation in reservationController.AllReservations)
                        {
                            if (Convert.ToDateTime(reservation.StartDate).Day >= start.Day && Convert.ToDateTime(reservation.EndDate).Day >= end.Day)
                            {
                                // add entire period to counter
                                counter+= Convert.ToDateTime(reservation.EndDate).Day - Convert.ToDateTime(reservation.StartDate).Day;
                            }

                            if (Convert.ToDateTime(reservation.StartDate).Day >= start.Day && Convert.ToDateTime(reservation.EndDate).Day > end.Day)
                            {
                                counter += end.Day - Convert.ToDateTime(reservation.StartDate).Day;
                            }

                            if (Convert.ToDateTime(reservation.StartDate).Day < start.Day && Convert.ToDateTime(reservation.EndDate).Day <= end.Day)
                            {
                                counter += Convert.ToDateTime(reservation.EndDate).Day - start.Day;
                            }

                            Paragraph para = new Paragraph(reservation.Id+" "+reservation.StartDate+" "+reservation.EndDate);
                            doc.Add(para);
                            
                        }

                        doc.Add(new Paragraph("Days in the period:\t"+period));
                        doc.Add(new Paragraph("Total reservations made:\t"+Math.Abs(counter)));
                        doc.Add(new Paragraph("Average occupancy in period:\t"+counter/period));
                        doc.Close();
                        MessageBox.Show("Occupancy report generated");

                        /*
                        DateTime rStart = Convert.ToDateTime(reservation.StartDate);
                        DateTime rEnd = Convert.ToDateTime(reservation.EndDate);



                        // cases

                        // 1: reservation falls completely between the period
                        if (rStart.Day >= start.Day && rEnd.Day <= end.Day)
                        {
                            countReservations += rEnd.Day - rStart.Day;
                        }

                        // 2: start is out of period but end day falls within
                        if (rStart.Day <= start.Day && rEnd.Day <= end.Day)
                        {
                            countReservations += rEnd.Day - start.Day;
                        }

                        // 3: start period is in period but end falls out
                        if (rStart.Day <= end.Day && rEnd.Day >= end.Day)
                        {
                            countReservations += end.Day - rStart.Day;
                        }

                        if (count % 7 == 0)
                        {
                                weekTally[counter] = countReservations;
                            counter++;
                        }

                        count++; // used to track the weeks
                    }

                    decimal median = countReservations / period;

                    this.Hide();
                    Report report = new Report(median, weekTally, start, end, countReservations);
                    report.Show();
                    */
                        break;
                    }

                case 1: // detailed report
                    {

                        if (cbxReportContent.SelectedIndex == 0)
                        {
                            ReservationController reservationController = new ReservationController();
                            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("./../../Reports/detailed-reservation-report" + start.Day + ".pdf", FileMode.Create));
                            doc.Open();
                            Paragraph paragraph = new Paragraph("Detailed Report - " + start.Day + "/12/2017 until " + end.Day + "/12/2017.");
                            doc.Add(paragraph);
                            int counter = 0;
                            foreach (Reservation reservation in reservationController.AllReservations)
                            {
                                Paragraph para = new Paragraph(reservation.Id + " " + reservation.StartDate + " " + reservation.EndDate);
                                doc.Add(para);
                                counter++;
                            }
                            doc.Add(new Paragraph("Total reservations:\t" + counter));
                            doc.Close();
                            MessageBox.Show("Detailed " + cbxReportContent.SelectedItem.ToString() + " report generated.");
                        }
                        
                        if (cbxReportContent.SelectedIndex == 1)
                        {
                            GuestController guestController = new GuestController();
                            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("./../../Reports/detailed-guest-report" + start.Day + ".pdf", FileMode.Create));
                            doc.Open();
                            int counter = 0;
                            foreach (Guest guest in guestController.AllGuests)
                            {
                                Paragraph para = new Paragraph(guest.GuestID + " " + guest.IdPassport + " " + guest.GuestAddress + " " + guest.FirstName+" "+ guest.LastName +" "+ guest.GuestAddress + " " +guest.EmailAddress);
                                doc.Add(para);
                                counter++;
                            }
                            doc.Add(new Paragraph("Total guests:\t" + counter));
                            doc.Close();
                            MessageBox.Show("Detailed " + cbxReportContent.SelectedItem.ToString() + " report generated.");
                        }

                        if (cbxReportContent.SelectedIndex == 2)
                        {
                            ChargeController chargeController = new ChargeController();
                            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("./../../Reports/detailed-charge-report" + start.Day + ".pdf", FileMode.Create));
                            doc.Open();
                            int counter = 0;
                            foreach (Charge charge in chargeController.AllCharges)
                            {
                                Paragraph para = new Paragraph(charge.ChargeID + " " + charge.AccountID + " " + charge.Type +  " " + charge.Amount);
                                doc.Add(para);
                                counter++;
                            }
                            doc.Add(new Paragraph("Total charges:\t" + counter));
                            doc.Close();
                            MessageBox.Show("Detailed " + cbxReportContent.SelectedItem.ToString() + " report generated.");
                        }

                        if (cbxReportContent.SelectedIndex == 3)
                        {
                            PaymentController paymentController = new PaymentController();
                            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("./../../Reports/detailed-payment-report" + start.Day + ".pdf", FileMode.Create));
                            doc.Open();
                            int counter = 0;
                            foreach (Payment payment in paymentController.AllPayments)
                            {
                                Paragraph para = new Paragraph(payment.PaymentID + " " + payment.AccountID + " " + payment.Type + " " + payment.Amount);
                                doc.Add(para);
                                counter++;
                            }
                            doc.Add(new Paragraph("Total payments:\t" + counter));
                            doc.Close();
                            MessageBox.Show("Detailed " + cbxReportContent.SelectedItem.ToString() + " report generated.");
                        }

                        break;
                    }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(restEasy);
            homePage.Show();
            this.Hide();
        }

        private void cbxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxReportType.SelectedIndex == 1)
            {
                lblReportContent.Show();
                cbxReportContent.Show();
            }else
            {
                lblReportContent.Show();
                cbxReportContent.Show();
                cbxReportContent.SelectedIndex = 0;
            }
        }

        private void cbxReportContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // block out datepicker if index not 0 (reservations)

            if(cbxReportContent.SelectedIndex != 0)
            {
                dateStart.Enabled = false;
                dateEnd.Enabled = false;
            }
            else
            {
                dateStart.Enabled = true;
                dateEnd.Enabled = true;
            }
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            dateEnd.MinDate = dateStart.Value.AddDays(1);
        }
    }
}

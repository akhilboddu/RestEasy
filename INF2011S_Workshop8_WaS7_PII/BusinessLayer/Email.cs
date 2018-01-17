using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    class Email
    {
        static readonly string imgLink = "http://www.mansinghhotels.com/blog/wp-content/themes/mansingh-blog/includes/images/banner.jpg";

        private string firstName;
        private string lastName;
        private string refNumber;
        private DateTime start;
        private DateTime end;
        private decimal amount;
        private decimal deposit;
        private DateTime payBy;

        // confirmation letter
        public Email(string first, string last, string refNum, DateTime s, DateTime e, decimal amt)
        {
            firstName = first;
            lastName = last;
            refNumber = refNum;
            start = s;
            end = e;
            amount = amt;
            deposit = amount * 1 / 10;
            // payment due 14 days before stay
            payBy = start.AddDays(-14);
        }



        public void sendEmail(string subject, string recipientEmail)
        {
            

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("resteasycapetown@gmail.com");
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = "<img src="+imgLink+"><h1>Thank you for booking with RestEasy, "+firstName+"! We look forward to seeing you.</h1><br><br>Booking Reference Number: "+refNumber+"<br>Start Date: "+start+"<br>End Date: "+end+"<br><br><strong>Payment by: </strong>"+payBy+"<br><br><strong>Deposit: </strong>"+deposit+ "<br><br><strong>Total amount: </strong>"+amount;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("resteasycapetown@gmail.com", "resteasy1");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Confirmation email sent.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send confirmation letter. Please try again.");
            }
        }
    }
}

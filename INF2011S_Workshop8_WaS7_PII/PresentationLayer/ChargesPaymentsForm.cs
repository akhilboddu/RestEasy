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
    public partial class ChargesPaymentsForm : Form
    {
        RestEasyMDIParent restEasy;

        static string [] paymentTypes = { "Deposit", "Room Account", "Other" };
        static string [] chargeTypes = { "Room Tariff", "Phone Bill", "Food", "Room Service", "Other" };

        ChargeController chargeController;
        PaymentController paymentController;
        AccountController accountController;
        ReservationController reservationController;
        decimal amount;
        Account aAccount;

        public ChargesPaymentsForm(RestEasyMDIParent re)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            restEasy = re;
            this.MdiParent = restEasy;

            chargeController = new ChargeController();
            paymentController = new PaymentController();
            accountController = new AccountController();
            reservationController = new ReservationController();

            amount = 0;

            radioButton1.Checked = true;
            rbnCharge.Checked = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void hidePanels()
        {
            panel_CashPayment.Hide();
            panel_CreditCard.Hide();
            panel_EFT.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // assuming "this" is the window containing your progress bar..
            // following code runs in background worker thread...


            DialogResult result = MessageBox.Show("Are you sure you want to confirm payment?", "Alert", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                // GuestForm guest = new GuestForm(reserrestEasy);
               // guest.Show();
            }

        }

        private void ChargesPaymentsForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            hidePanels();
            RadioButton ccRB = sender as RadioButton;

            if (ccRB.Checked)
            {
                panel_CreditCard.Show();
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            hidePanels();
            panel_CashPayment.Show();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            hidePanels();
            panel_EFT.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void rbnCharge_CheckedChanged(object sender, EventArgs e)
        {
            // remove current items from combo box
            /*
            for( int i = 0; i < cbxTypes.Items.Count; i++ )
            {
                cbxTypes.Items.RemoveAt(i);
            }




            */
            cbxTypes.Items.Clear();

            for ( int i = 0; i < chargeTypes.Length; i++ )
            {
                cbxTypes.Items.Add(chargeTypes[i]);
            }
            
            cbxTypes.SelectedIndex = 0;
        }

        private void rbnPayment_CheckedChanged(object sender, EventArgs e)
        {
            // remove current items from combo box
            /*
            for (int i = 0; i < cbxTypes.Items.Count; i++)
            {
                cbxTypes.Items.RemoveAt(i);
            }
            */
            cbxTypes.Items.Clear();

            for (int i = 0; i < paymentTypes.Length; i++)
            {
                cbxTypes.Items.Add(paymentTypes[i]);
            }
            
            cbxTypes.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(restEasy);
            this.Hide();
            homePage.Show();
        }


        // confirm payment button
        private void button2_Click_1(object sender, EventArgs e)
        {
            // CREDIT CARD
            if (radioButton1.Checked == true)
            {
                // null and empty char checks

                if (txtName.Text == null || txtName.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (txtCCNumber.Text == null || txtCCNumber.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (txtCVV.Text == null || txtCVV.Text == "")
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
                Match matchCardHolderName = Regex.Match(txtName.Text, @"(?i)^[a-z]+");

                if (matchCardHolderName.Success == false)
                {
                    MessageBox.Show("Card holder name may only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtCCNumber.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Card card number should only contain numeric values (0-9).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtCVV.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("CVV number should only contain numeric values (0-9).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtOTP.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("OTP Pin should only contain numeric values (0-9).");
                    return;
                }
            }

            // CASH PAYMENT
            if (radioButton2.Checked == true)
            {
                // null checks
                if (textBox7.Text == null || textBox7.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (textBox8.Text == null || textBox8.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (textBox5.Text == null || textBox5.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (textBox6.Text == null || textBox6.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                // invalid entry
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, @"(?i)^[a-z]+"))
                {
                    MessageBox.Show("Name of payer should only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox8.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Payer ID should only contain numeric values (0-9).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"(?i)^[a-z]+"))
                {
                    MessageBox.Show("Received By should only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, @"(?i)^[a-z]+"))
                {
                    MessageBox.Show("Charged To should only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }
            }

            // EFT
            if (radioButton3.Checked == true)
            {
                // null checks
                if (textBox4.Text == null || textBox4.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (textBox3.Text == null || textBox3.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (textBox2.Text == null || textBox2.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                if (textBox1.Text == null || textBox1.Text == "")
                {
                    MessageBox.Show("Fill in missing fields");
                    return;
                }

                // invalid entry
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"(?i)^[a-z]+"))
                {
                    MessageBox.Show("Beneficiary name should only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"(?i)^[a-z]+"))
                {
                    MessageBox.Show("Bank name should only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Account number should only contain numeric values (0-9).");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"(?i)^[a-z]+"))
                {
                    MessageBox.Show("Branch name should only contain non-numeric characters (A-Z), (a-z).");
                    return;
                }

            }

                // FINANCIAL ENTRIES
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Amount field should only contain numeric values (0-9).");
                return;
            }

            // ADD A CHARGE
            if (rbnCharge.Checked == true)
            {
                Charge aCharge = new Charge();
                aCharge.Type = cbxTypes.SelectedItem.ToString();
                aCharge.Amount = Convert.ToDecimal(txtAmount.Text);

                bool found = false;

                // link to account using id passport field of guests
                foreach (Account account in accountController.AllAccounts)
                {
                    if (account.IDPassport == txtIDPassport.Text.Trim())
                    {
                        found = true;
                        aCharge.AccountID = Convert.ToInt32(account.AccountID);
                        break;
                    }
                }

                if (found == false)
                {
                    MessageBox.Show("An error has occurred. Please try again.");
                }else // add charge
                {

                    aCharge.Type = cbxTypes.SelectedItem.ToString();
                    chargeController.DataMaintenance(aCharge, DatabaseLayer.DB.DBOperation.Add);
                    chargeController.FinalizeChanges(aCharge);

                    // defray balance in account
                    getAccount(txtIDPassport.Text);
                    aAccount.Balance += Convert.ToDecimal(txtAmount.Text);
                    accountController.DataMaintenance(aAccount, DatabaseLayer.DB.DBOperation.Edit);
                    accountController.FinalizeChanges(aAccount);

                    MessageBox.Show("Charge successfully added to account.");
                }

                return;
            }

            // ADD A PAYMENT
            if (rbnPayment.Checked == true)
            {
                Payment aPayment = new Payment();
                aPayment.Type = cbxTypes.SelectedItem.ToString();
                aPayment.Amount = Convert.ToDecimal(txtAmount.Text);
                if (aAccount == null)
                    getAccount(txtIDPassport.Text);
                increaseBalance();
                bool found = false;
                // link to account using id passport field of guests
                foreach (Account account in accountController.AllAccounts)
                {
                    if (account.IDPassport == txtIDPassport.Text.Trim())
                    {
                        found = true;
                        aPayment.AccountID = Convert.ToInt32(account.AccountID);
                        break;
                    }
                }

                if (found == false)
                {
                    MessageBox.Show("An error has occurred. Please try again.");
                }
                else
                { // add payment
                    aPayment.Type = cbxTypes.SelectedItem.ToString();
                    paymentController.DataMaintenance(aPayment, DatabaseLayer.DB.DBOperation.Add);
                    paymentController.FinalizeChanges(aPayment);

                    // update account balance
                    getAccount(txtIDPassport.Text);

                    aAccount.Balance -= Convert.ToDecimal(txtAmount.Text);
                    accountController.DataMaintenance(aAccount, DatabaseLayer.DB.DBOperation.Edit);
                    accountController.FinalizeChanges(aAccount);
                    MessageBox.Show("Payment successfully added to account.");
                }
            }
        }

        private void cbxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbnPayment.Checked == true && cbxTypes.SelectedIndex == 0)
            {
                btnCheck.Enabled = true;
            }else
            {
                btnCheck.Enabled = false;
            }

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // auto generate deposit amount
            if (rbnPayment.Checked == true && cbxTypes.SelectedIndex == 0)
            {
                string refNumber = txtIDPassport.Text;
                Reservation reservation = reservationController.Find(refNumber);
                int index = reservationController.FindIndex(reservation);

                if (index == reservationController.AllReservations.Count - 1)
                {
                    if (refNumber == Convert.ToString(reservationController.AllReservations[index].IdPassport))
                    {
                        getAccount(refNumber);
                        reservationController.calculateBookingCost(Convert.ToDateTime(reservation.StartDate), Convert.ToDateTime(reservation.EndDate));

                        amount = reservationController.Reservation.ReservationAmount * 1 / 10;
                        txtAmount.Text = Convert.ToString(reservationController.Reservation.ReservationAmount*1/10);
                    }
                    else
                    {
                        MessageBox.Show("Guest not on system. Please enter a different value.");
                    }
                }
                else
                {
                    getAccount(refNumber);
                    reservationController.calculateBookingCost(Convert.ToDateTime(reservation.StartDate), Convert.ToDateTime(reservation.EndDate));
                    amount = reservationController.Reservation.ReservationAmount * 1 / 10;
                    txtAmount.Text = Convert.ToString(reservationController.Reservation.ReservationAmount * 1 / 10);
                }
            }
        }

        public void getAccount(string id)
        {
            foreach (Account account in accountController.AllAccounts)
            {
                if (id == account.IDPassport)
                {
                    aAccount = account;
                    // getDeposit(account.ReservationRef);
                    return;
                }
            }
        }

        public void getDeposit(string id)
        {
            foreach(Reservation reservation in reservationController.AllReservations)
            {
                if (id == Convert.ToString(reservation.Id))
                {
                    MessageBox.Show("Reservation found.");
                    amount = reservation.ReservationAmount * 1 / 10;
                    txtAmount.Text = Convert.ToString(amount);
                    MessageBox.Show("Successfully");
                    return;
                }
            }
        }

        public void decreaseBalance()
        {
            aAccount.Balance = aAccount.Balance - amount;

            if (aAccount.Balance <= 0)
            {
                aAccount.Status = 1;
            }

            accountController.DataMaintenance(aAccount, DatabaseLayer.DB.DBOperation.Edit);
            accountController.FinalizeChanges(aAccount);
        }

        public void increaseBalance()
        {
            aAccount.Balance = aAccount.Balance + amount;

            if (aAccount.Balance > 0)
            {
                aAccount.Status = 0;
            }

            accountController.DataMaintenance(aAccount, DatabaseLayer.DB.DBOperation.Edit);
            accountController.FinalizeChanges(aAccount);
            

        }


    }
}

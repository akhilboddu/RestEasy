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
    public partial class EditReservationForm : Form
    {
        RestEasyMDIParent restEasy;
        ReservationController reservationController;
        int index;
        public EditReservationForm(RestEasyMDIParent re)
        {
            InitializeComponent();
            pnlEditReservation.Hide();
            lblReferenceDelete.Hide();
            txtReservationId.Hide();

            restEasy = re;
            reservationController = new ReservationController();
            index = 0;
            btnContinue.Enabled = false;
        }

        private void EditReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Reservation aReservation;

            if (cbxOperation.SelectedIndex == 0) // edit
            {
                aReservation = reservationController.Find((txtID.Text));
                // change booking dates - preceding dates not an issue because system is to be used in december
                aReservation.StartDate = Convert.ToString(dateStart.Value.Day);
                aReservation.EndDate = Convert.ToString(dateEnd.Value.Day);

                // check availability
                bool [] availRooms = reservationController.allocateRoom(Convert.ToInt32(aReservation.StartDate), Convert.ToInt32(aReservation.EndDate));

                int avail = 0;
                for (int i = 0; i < availRooms.Length; i++)
                {
                    if (availRooms[i] == false)
                    {
                        avail = i + 1;
                        break;
                    }
                }

                // no rooms available in period
                if (avail == 0)
                {
                    MessageBox.Show("No rooms available for the selected period. Please select another period.");
                    return;
                }
                else
                {
                    // ONLY ALLOW RESERVATION CHANGE IF ROOM AVAILABLE
                    // set room number
                    aReservation.RoomNumber = avail;
                    // commit change

                    aReservation.StartDate = "2017/12/" + aReservation.StartDate;
                    aReservation.EndDate = "2017/12/" + aReservation.EndDate;
                    reservationController.DataMaintenance(aReservation, DatabaseLayer.DB.DBOperation.Edit);
                    reservationController.FinalizeChanges(aReservation);

                    MessageBox.Show("Reservation date changed successfully.");
                }   
            }

            if (cbxOperation.SelectedIndex == 1) // delete
            {

                if (txtReservationId.Text == "" || txtReservationId.Text == null)
                {
                    MessageBox.Show("Please enter a valid reference number before trying again.");
                    return;
                }

                string id = txtReservationId.Text;

                aReservation = reservationController.Find(id);
                int index = reservationController.FindIndex(aReservation);

                // cater for event that no reservation is found but method returns the last element in the collection
                if (index + 1 == reservationController.AllReservations.Count)
                {
                    // MessageBox.Show(aReservation.Id+" "+ reservationController.AllReservations[reservationController.AllReservations.Count - 1].Id);
                    if (aReservation.Id != Convert.ToInt32(txtReservationId.Text))
                    {
                        MessageBox.Show("No reservation found. Please enter another ID value.");
                        return;
                    }else
                    {
                        reservationController.DataMaintenance(aReservation, DatabaseLayer.DB.DBOperation.Delete);
                        reservationController.FinalizeChanges(aReservation);
                        MessageBox.Show("Reservation deleted successfully.");
                    }

                }else
                {
                    reservationController.DataMaintenance(aReservation, DatabaseLayer.DB.DBOperation.Delete);
                    reservationController.FinalizeChanges(aReservation);
                    MessageBox.Show("Reservation deleted successfully.");
                }

                
            }
        }

        private void cbxOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbxOperation.SelectedIndex;

            if (cbxOperation.SelectedIndex == 0) // edit
            {
                pnlEditReservation.Show();
                // hide other operation input controls
                lblReferenceDelete.Hide();
                btnContinue.Enabled = false;
            }

            if(cbxOperation.SelectedIndex == 1) // cancel
            {
                btnContinue.Enabled = true;
                pnlEditReservation.Hide();
                lblReferenceDelete.Show();
                txtReservationId.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(restEasy);
            this.Hide();
            homePage.Show();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            // check availability

            dateEnd.MinDate = dateStart.Value.Date.AddDays(1);
        }

        /* check that reference id is valid */
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string refNumber = txtID.Text;
            Reservation reservation = reservationController.Find(refNumber, true);
            int index = reservationController.FindIndex(reservation);

            // if find returns the last index check that it is the correct reservation
            if (index == reservationController.AllReservations.Count - 1)
            {
                if (refNumber == Convert.ToString(reservationController.AllReservations[index].Id))
                {
                    dateStart.Enabled = true;
                    dateEnd.Enabled = true;

                    MessageBox.Show("Reservation found.");
                    btnContinue.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Reference Number does not exist. Please enter a different value.");
                }
            }else // returns correct reservation
            {
                MessageBox.Show("Reservation found.");
                dateStart.Enabled = true;
                dateEnd.Enabled = true;
                btnContinue.Enabled = true;
            }


        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            dateStart.Enabled = false;
            dateEnd.Enabled = false;
            btnContinue.Enabled = false;
        }
    }
}

using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using INF2011S_Workshop8_WaS7_PII.Shifts;
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
    internal partial class ReservationForm : Form
    {
        
        private BlockArray roomDates; // between start and end dates
        ReservationController reservationController;
        RestEasyMDIParent restEasy;

        private string reservationStartDate;
        private string reservationEndDate;

        int clickCount;

        Color one, two;
        Button firstClick, lastClick;

        public ReservationForm(ReservationController res, RestEasyMDIParent re)
        {
            clickCount = 0;

            InitializeComponent();
            reservationController = res;
            restEasy = re;
            showReservationDates();
            btnReset.Enabled = false;
            reservationController.Reservation.generateId();
            btnConfirmReservation.Enabled = false;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void ReservationForm_Closed(object sender, EventArgs e)
        {

        }

        private void btnConfirmReservation_Click(object sender, EventArgs e)
        {
            reservationController.calculateBookingCost();
            this.Hide();
            GuestForm guestForm = new GuestForm(reservationController, restEasy);
            guestForm.Show();
            guestForm.MdiParent = restEasy;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            restEasy.createNewHomePage();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            // we need to iterate through the reservations table and determine which rooms are available to be booked
        }

        public void showReservationDates()
        {
            //***Add control array, ShiftDates, to show the dates of the shifts – instantiate with parameters
            roomDates = new BlockArray(this, 30, 100, 50, 7);  //these blocks will appear in a column

            int intcnt = 0;

            // show all 31 days in the month
            for (intcnt = 0; intcnt <= 30; intcnt++)
            {
                roomDates.AddNewBlock();
                roomDates.Item(intcnt).Text = Convert.ToString(intcnt + 1);

                // determine colour using the reservations collection in reservationController
                roomDates.Item(intcnt).FlatStyle = FlatStyle.Flat;
        
                roomDates.Item(intcnt).Click += SlotSelected; // add action event listener to each button

                int count = 0;

                // determine number of reservations on each day
                for (int i =0; i < reservationController.AllReservations.Count; i++)
                {
                    // get single reservation
                    Reservation reserved = reservationController.AllReservations[i];
                    
                    // check the start and end date
                    string start = reserved.StartDate;
                    string end = reserved.EndDate;

                    DateTime startDT = Convert.ToDateTime(start);
                    DateTime endDT = Convert.ToDateTime(end);
                    int startDay = Convert.ToInt32(startDT.Day);
                    int endDay = Convert.ToInt32(endDT.Day);

                    if (intcnt+1 >= startDay && intcnt+1 <= endDay)
                        count++;
                }

                // colour dates depending on availability
                if (count == 0) { roomDates.Item(intcnt).BackColor = Color.White; }
                if(count > 0 && count < 5) { roomDates.Item(intcnt).BackColor = Color.Yellow; }
                if(count == 5) { roomDates.Item(intcnt).BackColor = Color.Red; roomDates.Item(intcnt).Enabled = false;}
            }
        }

        private void SlotSelected(System.Object sender, System.EventArgs e)
        {
            // have to check booking is within range


            clickCount++;
            Button button = (Button)sender;


            if (clickCount == 1)
            {
                // set attributes in reservation controller reservation object
                reservationController.Reservation.StartDate = button.Text;
                btnReset.Enabled = true;
                one = button.BackColor;
                firstClick = button;
                reservationStartDate = button.Text;
                lblFrom.Text = "From: " + reservationStartDate+" December 2017";


                // prevent preceding dates from being selected using the button label
                int blocked = Convert.ToInt32(reservationStartDate); // day

                button.BackColor = Color.Green;
            }

            if (clickCount == 2)
            {
                btnConfirmReservation.Enabled = true;
                // check if date is valid
                if (reservationController.Reservation.StartDate == button.Text || Convert.ToInt32(reservationController.Reservation.StartDate) > Convert.ToInt32(button.Text))
                {
                    clickCount--;
                    MessageBox.Show("Select a day after the start date.");
                    return;
                }

                // determine whether rooms are available for the period
                bool [] rooms = reservationController.allocateRoom(Convert.ToInt32(reservationStartDate), Convert.ToInt32(button.Text));

                bool availRoom = false;
                int roomNum = 0;
                for (int i = 0; i < rooms.Length; i++)
                {
                    if (rooms[i] == false)
                    {
                        availRoom = true;
                        roomNum = i + 1;
                    }
                }

                if (availRoom == true)
                {
                    reservationController.Reservation.RoomNumber = roomNum;
                }else
                {
                    clickCount--;
                    MessageBox.Show("No rooms available. Please select another range of dates.");
                    return;
                }

                reservationController.Reservation.EndDate = button.Text;
                two = button.BackColor;
                lastClick = button;
                reservationEndDate = button.Text;
                lblTo.Text = "To: " + reservationEndDate+" December 2017";
                button.BackColor = Color.Green;
            }

            if (clickCount > 2)
            {
                // do nothing
            }
        }

        // resets the form and any attributes that were instantiated
        private void btnReset_Click(object sender, EventArgs e)
        {
            // reset all items on the page
            clickCount = 0;
            if (firstClick != null)
                firstClick.BackColor = one;
            if (lastClick != null)
            lastClick.BackColor = two;

            // reset labels

            lblFrom.Text = "From: ";
            lblTo.Text = "To: ";

            showReservationDates();
            reservationController.Reservation.StartDate = null;
            reservationController.Reservation.EndDate = null;

            btnConfirmReservation.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // when a slot is deselected
        private void SlotDeselected(System.Object sender, System.EventArgs e)
        {
            // reset the grid
        }

       

    }
}

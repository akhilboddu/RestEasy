using INF2011S_Workshop8_WaS7_PII.PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF2011S_Workshop8_WaS7_PII.BusinessLayer
{
    public partial class RoomPage : Form
    {
        RestEasyMDIParent restEasy;
        public RoomPage(RestEasyMDIParent re)
        {
            InitializeComponent();
            restEasy = re;
        }

        private void RoomPage_Load(object sender, EventArgs e)
        {

        }

        void btnBookNow_MouseLeave(object sender, EventArgs e)
        {
            btnBookNow.BackColor = Color.White;
        }


        void btnBookNow_MouseEnter(object sender, EventArgs e)
        {
            btnBookNow.BackColor = Color.Cyan;
        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            restEasy.createNewReservationForm();
            this.Close();
        }
    }
}

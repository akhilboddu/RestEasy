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
    public partial class Report : Form
    {
        public Report(decimal median, int [] weeklyOccupancy, DateTime start, DateTime end, int numReservations)
        {
            InitializeComponent();

            txaOutput.AppendText("Occupancy Report - "+Convert.ToString(start.Date)+" until "+Convert.ToString(end.Date)+"\n");
            txaOutput.AppendText("Median occupancy for the period: "+median+"\n");
            for (int i =0; i < weeklyOccupancy.Length; i++)
            {
                txaOutput.AppendText("Week "+(i+1) +":\t"+weeklyOccupancy[i]+"\n");
            }

            txaOutput.AppendText("Total reservations:\t"+numReservations);
        }



        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}

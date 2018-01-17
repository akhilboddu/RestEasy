using INF2011S_Workshop8_WaS7_PII.BusinessLayer;
using INF2011S_Workshop8_WaS7_PII.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visifire.Charts;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class VisualisationPage : Form
    {
        private ReservationDB reservationDB;



        public VisualisationPage()
        {
            InitializeComponent();
            reservationDB = new ReservationDB();
            populate();
        }


        private void VisualisationPage_Load(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        public void populate()
        {
            DataTable genderTable;
            //  genderTable = studentInfoDB.ReadDataGender();
            Chart genderChart = new Chart();

            DataSeries male = new DataSeries();
            male.RenderAs = RenderAs.Column;
            male.LegendText = "Reservation";

            genderTable = reservationDB.ReadDataGender();

            foreach (DataRow genderRow in genderTable.Rows)
            {
                DataPoint aPoint = new DataPoint();
                // Set X & Y Value for a DataPoint
                aPoint.AxisXLabel = (genderRow.ItemArray[0]).ToString();
                aPoint.YValue = Convert.ToDouble(genderRow.ItemArray[1]);
                // Add dataPoint to DataPoints collection
                male.DataPoints.Add(aPoint);
            }
            genderChart.Series.Add(male);

            genderChart.SmartLabelEnabled = true;
            ReservationsElementHost.Child = genderChart;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

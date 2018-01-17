using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INF2011S_Workshop8_WaS7_PII.Employees;
using INF2011S_Workshop8_WaS7_PII.BusinessLayer;

namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    public partial class RestEasyMDIParent : Form
    {
        private int childFormNumber = 0;
        //1a. ***Declare a reference to an EmployeeForm object
      
        //1b *** Declare a reference to a EmployeeListForm object
       
        //***Declare a reference to a shiftsForm object
     
        //2. ***Declare a reference to an EmployeeController object

        private ReservationController reservationController;

        public RestEasyMDIParent()
        {
            InitializeComponent();
            createNewHomePage();
            this.WindowState = FormWindowState.Maximized;
            reservationController = new ReservationController();   
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        #region ToolstripMenus
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion

        #region ToolstripMenus Employees & Shifts
        private void listAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void listHeadWaitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void listWaitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void listRunnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void addAnEmplyeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addWeeklyShiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Employee & Shift Child Forms
        private void CreateNewEmployeeForm()
        {
          
           
        }

        private void CreateNewEmployeeListForm()
        {
            
           
        }

        private void CreateNewShiftsForm()
        {
           
          
        }
        #endregion

        private void EmployeesMDIParent_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }


        #region switching forms

        /*
         * have to call hide before / after each of these method calls
         */

        public void createNewHomePage()
        {
            HomePage homePage = new HomePage(this);
            homePage.StartPosition = FormStartPosition.CenterScreen;     
            homePage.MdiParent = this;
            homePage.Show();
        }

        public void createNewReservationForm()
        {
            ReservationForm reservationForm = new ReservationForm(reservationController, this);
            reservationForm.StartPosition = FormStartPosition.CenterScreen;
            reservationForm.MdiParent = this;
            reservationForm.Show();
        }

        #endregion

        private void makeReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewReservationForm();
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(this);
            reportForm.Show();
        }

        private void checkFlaggedGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnquiryForm enquiryForm = new EnquiryForm(this);
            enquiryForm.Show();
        }

        private void homePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(this);
            homePage.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservationVisualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualisationPage visuals = new VisualisationPage();
            visuals.MdiParent = this;
            visuals.Show();
        }
    }
}

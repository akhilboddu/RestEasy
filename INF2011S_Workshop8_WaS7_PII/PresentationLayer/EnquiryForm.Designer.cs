namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    partial class EnquiryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnquiryForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_Reservation = new System.Windows.Forms.Panel();
            this.panel_ReservationDetails = new System.Windows.Forms.Panel();
            this.lblEDate = new System.Windows.Forms.Label();
            this.lblSDate = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.panelDeposit = new System.Windows.Forms.Panel();
            this.lblDepositStatus = new System.Windows.Forms.Label();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_EnterResID = new System.Windows.Forms.Panel();
            this.btnSearchResID = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel_Listview = new System.Windows.Forms.Panel();
            this.FlaggedGuests_listview = new System.Windows.Forms.ListView();
            this.lblHeading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel_Reservation.SuspendLayout();
            this.panel_ReservationDetails.SuspendLayout();
            this.panelDeposit.SuspendLayout();
            this.panel_EnterResID.SuspendLayout();
            this.panel_Listview.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "View a Reservation",
            "View Flagged Guests"});
            this.comboBox1.Location = new System.Drawing.Point(236, 100);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::INF2011S_Workshop8_WaS7_PII.Properties.Resources.resteasy;
            this.pictureBox1.Location = new System.Drawing.Point(-123, -133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 216);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enquiry Type";
            // 
            // Panel_Reservation
            // 
            this.Panel_Reservation.Controls.Add(this.panel_ReservationDetails);
            this.Panel_Reservation.Controls.Add(this.panel_EnterResID);
            this.Panel_Reservation.Location = new System.Drawing.Point(146, 151);
            this.Panel_Reservation.Name = "Panel_Reservation";
            this.Panel_Reservation.Size = new System.Drawing.Size(457, 306);
            this.Panel_Reservation.TabIndex = 9;
            // 
            // panel_ReservationDetails
            // 
            this.panel_ReservationDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ReservationDetails.Controls.Add(this.lblEDate);
            this.panel_ReservationDetails.Controls.Add(this.lblSDate);
            this.panel_ReservationDetails.Controls.Add(this.lblLname);
            this.panel_ReservationDetails.Controls.Add(this.lblFname);
            this.panel_ReservationDetails.Controls.Add(this.lblResID);
            this.panel_ReservationDetails.Controls.Add(this.panelDeposit);
            this.panel_ReservationDetails.Controls.Add(this.label9);
            this.panel_ReservationDetails.Controls.Add(this.label10);
            this.panel_ReservationDetails.Controls.Add(this.label6);
            this.panel_ReservationDetails.Controls.Add(this.label5);
            this.panel_ReservationDetails.Controls.Add(this.label4);
            this.panel_ReservationDetails.Location = new System.Drawing.Point(0, 0);
            this.panel_ReservationDetails.Name = "panel_ReservationDetails";
            this.panel_ReservationDetails.Size = new System.Drawing.Size(457, 306);
            this.panel_ReservationDetails.TabIndex = 7;
            // 
            // lblEDate
            // 
            this.lblEDate.AutoSize = true;
            this.lblEDate.Location = new System.Drawing.Point(230, 172);
            this.lblEDate.Name = "lblEDate";
            this.lblEDate.Size = new System.Drawing.Size(97, 13);
            this.lblEDate.TabIndex = 23;
            this.lblEDate.Text = "Reference Number";
            // 
            // lblSDate
            // 
            this.lblSDate.AutoSize = true;
            this.lblSDate.Location = new System.Drawing.Point(230, 137);
            this.lblSDate.Name = "lblSDate";
            this.lblSDate.Size = new System.Drawing.Size(97, 13);
            this.lblSDate.TabIndex = 22;
            this.lblSDate.Text = "Reference Number";
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(230, 102);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(97, 13);
            this.lblLname.TabIndex = 21;
            this.lblLname.Text = "Reference Number";
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(230, 65);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(97, 13);
            this.lblFname.TabIndex = 20;
            this.lblFname.Text = "Reference Number";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Location = new System.Drawing.Point(230, 30);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(97, 13);
            this.lblResID.TabIndex = 19;
            this.lblResID.Text = "Reference Number";
            // 
            // panelDeposit
            // 
            this.panelDeposit.BackColor = System.Drawing.Color.Aquamarine;
            this.panelDeposit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeposit.Controls.Add(this.lblDepositStatus);
            this.panelDeposit.Controls.Add(this.lblDepositAmount);
            this.panelDeposit.Controls.Add(this.label8);
            this.panelDeposit.Location = new System.Drawing.Point(89, 205);
            this.panelDeposit.Name = "panelDeposit";
            this.panelDeposit.Size = new System.Drawing.Size(277, 68);
            this.panelDeposit.TabIndex = 18;
            // 
            // lblDepositStatus
            // 
            this.lblDepositStatus.AutoSize = true;
            this.lblDepositStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositStatus.Location = new System.Drawing.Point(102, 44);
            this.lblDepositStatus.Name = "lblDepositStatus";
            this.lblDepositStatus.Size = new System.Drawing.Size(66, 13);
            this.lblDepositStatus.TabIndex = 25;
            this.lblDepositStatus.Text = "NOT PAID";
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Location = new System.Drawing.Point(141, 17);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(97, 13);
            this.lblDepositAmount.TabIndex = 24;
            this.lblDepositAmount.Text = "Reference Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Deposit Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(111, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "End Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(111, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Start Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reference Number";
            // 
            // panel_EnterResID
            // 
            this.panel_EnterResID.Controls.Add(this.btnSearchResID);
            this.panel_EnterResID.Controls.Add(this.label7);
            this.panel_EnterResID.Controls.Add(this.txtResID);
            this.panel_EnterResID.Controls.Add(this.label3);
            this.panel_EnterResID.Location = new System.Drawing.Point(12, 80);
            this.panel_EnterResID.Name = "panel_EnterResID";
            this.panel_EnterResID.Size = new System.Drawing.Size(423, 144);
            this.panel_EnterResID.TabIndex = 8;
            // 
            // btnSearchResID
            // 
            this.btnSearchResID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchResID.Location = new System.Drawing.Point(170, 96);
            this.btnSearchResID.Name = "btnSearchResID";
            this.btnSearchResID.Size = new System.Drawing.Size(75, 23);
            this.btnSearchResID.TabIndex = 3;
            this.btnSearchResID.Text = "Search";
            this.btnSearchResID.UseVisualStyleBackColor = true;
            this.btnSearchResID.Click += new System.EventHandler(this.btnSearchResID_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(393, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Please enter the Reservation reference number and click on Search";
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(226, 50);
            this.txtResID.Name = "txtResID";
            this.txtResID.Size = new System.Drawing.Size(100, 20);
            this.txtResID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reference Number";
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(590, 494);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back To Home";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel_Listview
            // 
            this.panel_Listview.Controls.Add(this.FlaggedGuests_listview);
            this.panel_Listview.Controls.Add(this.lblHeading);
            this.panel_Listview.Location = new System.Drawing.Point(41, 139);
            this.panel_Listview.Name = "panel_Listview";
            this.panel_Listview.Size = new System.Drawing.Size(661, 337);
            this.panel_Listview.TabIndex = 11;
            // 
            // FlaggedGuests_listview
            // 
            this.FlaggedGuests_listview.Location = new System.Drawing.Point(12, 43);
            this.FlaggedGuests_listview.Name = "FlaggedGuests_listview";
            this.FlaggedGuests_listview.Size = new System.Drawing.Size(636, 283);
            this.FlaggedGuests_listview.TabIndex = 13;
            this.FlaggedGuests_listview.UseCompatibleStateImageBehavior = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(9, 15);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(126, 18);
            this.lblHeading.TabIndex = 11;
            this.lblHeading.Text = "Flagged Guests";
            // 
            // EnquiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 541);
            this.Controls.Add(this.panel_Listview);
            this.Controls.Add(this.Panel_Reservation);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(772, 580);
            this.MinimumSize = new System.Drawing.Size(772, 580);
            this.Name = "EnquiryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Make an Enquiry";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel_Reservation.ResumeLayout(false);
            this.panel_ReservationDetails.ResumeLayout(false);
            this.panel_ReservationDetails.PerformLayout();
            this.panelDeposit.ResumeLayout(false);
            this.panelDeposit.PerformLayout();
            this.panel_EnterResID.ResumeLayout(false);
            this.panel_EnterResID.PerformLayout();
            this.panel_Listview.ResumeLayout(false);
            this.panel_Listview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel_Reservation;
        private System.Windows.Forms.Panel panel_ReservationDetails;
        private System.Windows.Forms.Label lblEDate;
        private System.Windows.Forms.Label lblSDate;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel panelDeposit;
        private System.Windows.Forms.Label lblDepositStatus;
        private System.Windows.Forms.Label lblDepositAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_EnterResID;
        private System.Windows.Forms.Button btnSearchResID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel_Listview;
        private System.Windows.Forms.ListView FlaggedGuests_listview;
        private System.Windows.Forms.Label lblHeading;
    }
}
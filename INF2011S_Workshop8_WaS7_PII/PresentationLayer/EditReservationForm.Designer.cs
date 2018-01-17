namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    partial class EditReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditReservationForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtReservationId = new System.Windows.Forms.TextBox();
            this.cbxOperation = new System.Windows.Forms.ComboBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblReferenceDelete = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlEditReservation = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblReferenceEdit = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlEditReservation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::INF2011S_Workshop8_WaS7_PII.Properties.Resources.resteasy;
            this.pictureBox1.Location = new System.Drawing.Point(-125, -138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 211);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtReservationId
            // 
            this.txtReservationId.Location = new System.Drawing.Point(136, 165);
            this.txtReservationId.Name = "txtReservationId";
            this.txtReservationId.Size = new System.Drawing.Size(391, 20);
            this.txtReservationId.TabIndex = 1;
            // 
            // cbxOperation
            // 
            this.cbxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOperation.FormattingEnabled = true;
            this.cbxOperation.Items.AddRange(new object[] {
            "Edit a Reservation",
            "Cancel a Reservation"});
            this.cbxOperation.Location = new System.Drawing.Point(136, 110);
            this.cbxOperation.Name = "cbxOperation";
            this.cbxOperation.Size = new System.Drawing.Size(391, 21);
            this.cbxOperation.TabIndex = 3;
            this.cbxOperation.SelectedIndexChanged += new System.EventHandler(this.cbxOperation_SelectedIndexChanged);
            // 
            // btnContinue
            // 
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(510, 367);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(102, 23);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblReferenceDelete
            // 
            this.lblReferenceDelete.AutoSize = true;
            this.lblReferenceDelete.Location = new System.Drawing.Point(12, 165);
            this.lblReferenceDelete.Name = "lblReferenceDelete";
            this.lblReferenceDelete.Size = new System.Drawing.Size(97, 13);
            this.lblReferenceDelete.TabIndex = 5;
            this.lblReferenceDelete.Text = "Reference Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Operation";
            // 
            // pnlEditReservation
            // 
            this.pnlEditReservation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditReservation.Controls.Add(this.btnCheck);
            this.pnlEditReservation.Controls.Add(this.dateEnd);
            this.pnlEditReservation.Controls.Add(this.dateStart);
            this.pnlEditReservation.Controls.Add(this.lblEndDate);
            this.pnlEditReservation.Controls.Add(this.lblStart);
            this.pnlEditReservation.Controls.Add(this.lblReferenceEdit);
            this.pnlEditReservation.Controls.Add(this.txtID);
            this.pnlEditReservation.Location = new System.Drawing.Point(134, 165);
            this.pnlEditReservation.Name = "pnlEditReservation";
            this.pnlEditReservation.Size = new System.Drawing.Size(393, 167);
            this.pnlEditReservation.TabIndex = 7;
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(302, 23);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(65, 28);
            this.btnCheck.TabIndex = 18;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.Enabled = false;
            this.dateEnd.Location = new System.Drawing.Point(162, 131);
            this.dateEnd.MaxDate = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            this.dateEnd.MinDate = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(205, 20);
            this.dateEnd.TabIndex = 17;
            this.dateEnd.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            // 
            // dateStart
            // 
            this.dateStart.Enabled = false;
            this.dateStart.Location = new System.Drawing.Point(162, 76);
            this.dateStart.MaxDate = new System.DateTime(2018, 3, 2, 0, 0, 0, 0);
            this.dateStart.MinDate = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(205, 20);
            this.dateStart.TabIndex = 8;
            this.dateStart.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(3, 138);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 16;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(3, 82);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 13);
            this.lblStart.TabIndex = 14;
            this.lblStart.Text = "Start Date";
            // 
            // lblReferenceEdit
            // 
            this.lblReferenceEdit.AutoSize = true;
            this.lblReferenceEdit.Location = new System.Drawing.Point(3, 31);
            this.lblReferenceEdit.Name = "lblReferenceEdit";
            this.lblReferenceEdit.Size = new System.Drawing.Size(97, 13);
            this.lblReferenceEdit.TabIndex = 8;
            this.lblReferenceEdit.Text = "Reference Number";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(163, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(133, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(392, 367);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // EditReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 406);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlEditReservation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblReferenceDelete);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.cbxOperation);
            this.Controls.Add(this.txtReservationId);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(640, 445);
            this.MinimumSize = new System.Drawing.Size(640, 445);
            this.Name = "EditReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit a Reservation";
            this.Load += new System.EventHandler(this.EditReservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlEditReservation.ResumeLayout(false);
            this.pnlEditReservation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtReservationId;
        private System.Windows.Forms.ComboBox cbxOperation;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblReferenceDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlEditReservation;
        private System.Windows.Forms.Label lblReferenceEdit;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCheck;
    }
}
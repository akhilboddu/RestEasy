namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    partial class GuestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmGuest = new System.Windows.Forms.Button();
            this.btnCheckIfExists = new System.Windows.Forms.Button();
            this.panelGuestDetails = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.panelVerification = new System.Windows.Forms.Panel();
            this.btnCreateGuest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSearchAgain = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelGuestDetails.SuspendLayout();
            this.panelVerification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(430, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirmGuest
            // 
            this.btnConfirmGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmGuest.Location = new System.Drawing.Point(652, 402);
            this.btnConfirmGuest.Name = "btnConfirmGuest";
            this.btnConfirmGuest.Size = new System.Drawing.Size(114, 23);
            this.btnConfirmGuest.TabIndex = 12;
            this.btnConfirmGuest.Text = "Confirm Guest";
            this.btnConfirmGuest.UseVisualStyleBackColor = true;
            this.btnConfirmGuest.Click += new System.EventHandler(this.btnConfirmGuest_Click);
            // 
            // btnCheckIfExists
            // 
            this.btnCheckIfExists.BackColor = System.Drawing.Color.White;
            this.btnCheckIfExists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIfExists.Location = new System.Drawing.Point(38, 103);
            this.btnCheckIfExists.Name = "btnCheckIfExists";
            this.btnCheckIfExists.Size = new System.Drawing.Size(138, 23);
            this.btnCheckIfExists.TabIndex = 13;
            this.btnCheckIfExists.Text = "Search";
            this.btnCheckIfExists.UseVisualStyleBackColor = false;
            this.btnCheckIfExists.Click += new System.EventHandler(this.btnCheckIfExists_Click);
            // 
            // panelGuestDetails
            // 
            this.panelGuestDetails.BackColor = System.Drawing.Color.White;
            this.panelGuestDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGuestDetails.Controls.Add(this.label8);
            this.panelGuestDetails.Controls.Add(this.txtID2);
            this.panelGuestDetails.Controls.Add(this.label7);
            this.panelGuestDetails.Controls.Add(this.label5);
            this.panelGuestDetails.Controls.Add(this.label4);
            this.panelGuestDetails.Controls.Add(this.label3);
            this.panelGuestDetails.Controls.Add(this.label2);
            this.panelGuestDetails.Controls.Add(this.txtEmail);
            this.panelGuestDetails.Controls.Add(this.txtAddress);
            this.panelGuestDetails.Controls.Add(this.txtFirstName);
            this.panelGuestDetails.Controls.Add(this.txtLastName);
            this.panelGuestDetails.Location = new System.Drawing.Point(215, 79);
            this.panelGuestDetails.Name = "panelGuestDetails";
            this.panelGuestDetails.Size = new System.Drawing.Size(356, 252);
            this.panelGuestDetails.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Enter Guest Details";
            // 
            // txtID2
            // 
            this.txtID2.BackColor = System.Drawing.Color.White;
            this.txtID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID2.Location = new System.Drawing.Point(183, 49);
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(100, 20);
            this.txtID2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "ID/Passport";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Email address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Last name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "First name";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(183, 205);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 14;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(183, 166);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 13;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(183, 87);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 12;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.White;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(183, 126);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 11;
            // 
            // panelVerification
            // 
            this.panelVerification.BackColor = System.Drawing.Color.White;
            this.panelVerification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVerification.Controls.Add(this.btnCreateGuest);
            this.panelVerification.Controls.Add(this.label6);
            this.panelVerification.Controls.Add(this.label1);
            this.panelVerification.Controls.Add(this.btnCheckIfExists);
            this.panelVerification.Controls.Add(this.txtID);
            this.panelVerification.Location = new System.Drawing.Point(215, 124);
            this.panelVerification.Name = "panelVerification";
            this.panelVerification.Size = new System.Drawing.Size(356, 155);
            this.panelVerification.TabIndex = 15;
            // 
            // btnCreateGuest
            // 
            this.btnCreateGuest.BackColor = System.Drawing.Color.White;
            this.btnCreateGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateGuest.Location = new System.Drawing.Point(182, 103);
            this.btnCreateGuest.Name = "btnCreateGuest";
            this.btnCreateGuest.Size = new System.Drawing.Size(138, 23);
            this.btnCreateGuest.TabIndex = 14;
            this.btnCreateGuest.Text = "Create Guest";
            this.btnCreateGuest.UseVisualStyleBackColor = false;
            this.btnCreateGuest.Click += new System.EventHandler(this.btnCreateGuest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(334, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Enter Guest ID to check if the Guest Exists in the system.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID/Passport";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(195, 51);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 7;
            // 
            // btnSearchAgain
            // 
            this.btnSearchAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAgain.Location = new System.Drawing.Point(540, 402);
            this.btnSearchAgain.Name = "btnSearchAgain";
            this.btnSearchAgain.Size = new System.Drawing.Size(106, 23);
            this.btnSearchAgain.TabIndex = 15;
            this.btnSearchAgain.Text = "Search Again";
            this.btnSearchAgain.UseVisualStyleBackColor = true;
            this.btnSearchAgain.Click += new System.EventHandler(this.btnSearchAgain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::INF2011S_Workshop8_WaS7_PII.Properties.Resources.resteasy;
            this.pictureBox1.Location = new System.Drawing.Point(-126, -133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 206);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 437);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearchAgain);
            this.Controls.Add(this.panelVerification);
            this.Controls.Add(this.panelGuestDetails);
            this.Controls.Add(this.btnConfirmGuest);
            this.Controls.Add(this.btnCancel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(794, 476);
            this.MinimumSize = new System.Drawing.Size(794, 476);
            this.Name = "GuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Guest Details";
            this.Load += new System.EventHandler(this.GuestForm_Load);
            this.panelGuestDetails.ResumeLayout(false);
            this.panelGuestDetails.PerformLayout();
            this.panelVerification.ResumeLayout(false);
            this.panelVerification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirmGuest;
        private System.Windows.Forms.Button btnCheckIfExists;
        private System.Windows.Forms.Panel panelGuestDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Panel panelVerification;
        private System.Windows.Forms.Button btnCreateGuest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearchAgain;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
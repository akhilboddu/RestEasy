namespace INF2011S_Workshop8_WaS7_PII.PresentationLayer
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblAmountPayable = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCVVNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCreditCardNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardHolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPayLater = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.White;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.Location = new System.Drawing.Point(627, 392);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(128, 23);
            this.btnProceed.TabIndex = 0;
            this.btnProceed.Text = "Proceed with Payment";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(271, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(394, 392);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lblDeposit);
            this.panel1.Controls.Add(this.lblAmountPayable);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtOTP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCVVNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCreditCardNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCardHolderName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(228, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 199);
            this.panel1.TabIndex = 4;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.Color.Red;
            this.lblDeposit.Location = new System.Drawing.Point(175, 20);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(98, 13);
            this.lblDeposit.TabIndex = 11;
            this.lblDeposit.Text = "Amount Payable";
            // 
            // lblAmountPayable
            // 
            this.lblAmountPayable.AutoSize = true;
            this.lblAmountPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPayable.Location = new System.Drawing.Point(14, 20);
            this.lblAmountPayable.Name = "lblAmountPayable";
            this.lblAmountPayable.Size = new System.Drawing.Size(128, 13);
            this.lblAmountPayable.TabIndex = 10;
            this.lblAmountPayable.Text = "Deposit Payable Now";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "OTP Pin";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtOTP
            // 
            this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOTP.Location = new System.Drawing.Point(178, 169);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(169, 20);
            this.txtOTP.TabIndex = 8;
            this.txtOTP.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "CVV Number";
            // 
            // txtCVVNumber
            // 
            this.txtCVVNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVVNumber.Location = new System.Drawing.Point(178, 140);
            this.txtCVVNumber.Name = "txtCVVNumber";
            this.txtCVVNumber.Size = new System.Drawing.Size(169, 20);
            this.txtCVVNumber.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Credit Card Number";
            // 
            // txtCreditCardNumber
            // 
            this.txtCreditCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditCardNumber.Location = new System.Drawing.Point(178, 111);
            this.txtCreditCardNumber.Name = "txtCreditCardNumber";
            this.txtCreditCardNumber.Size = new System.Drawing.Size(169, 20);
            this.txtCreditCardNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Card Holder Name";
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardHolderName.Location = new System.Drawing.Point(178, 82);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(169, 20);
            this.txtCardHolderName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit Card Details";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::INF2011S_Workshop8_WaS7_PII.Properties.Resources.resteasy;
            this.pictureBox2.Location = new System.Drawing.Point(-116, -125);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(401, 218);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::INF2011S_Workshop8_WaS7_PII.Properties.Resources.creditcardvendors;
            this.pictureBox1.Location = new System.Drawing.Point(12, 335);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 80);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnPayLater
            // 
            this.btnPayLater.BackColor = System.Drawing.Color.White;
            this.btnPayLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayLater.Location = new System.Drawing.Point(518, 392);
            this.btnPayLater.Name = "btnPayLater";
            this.btnPayLater.Size = new System.Drawing.Size(103, 23);
            this.btnPayLater.TabIndex = 6;
            this.btnPayLater.Text = "Pay Later";
            this.btnPayLater.UseVisualStyleBackColor = false;
            this.btnPayLater.Click += new System.EventHandler(this.button1_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 427);
            this.Controls.Add(this.btnPayLater);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnProceed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(783, 466);
            this.MinimumSize = new System.Drawing.Size(783, 466);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter a Payment Method";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCardHolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCVVNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCreditCardNumber;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblAmountPayable;
        private System.Windows.Forms.Button btnPayLater;
    }
}
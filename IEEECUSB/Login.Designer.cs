namespace IEEECUSB
{
    partial class Login
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
            this.welcomeSentence2_Lbl = new System.Windows.Forms.Label();
            this.welcomeSentence1_Lbl = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.mailAddress = new System.Windows.Forms.TextBox();
            this.mailPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Remember = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeSentence2_Lbl
            // 
            this.welcomeSentence2_Lbl.AutoSize = true;
            this.welcomeSentence2_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.welcomeSentence2_Lbl.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeSentence2_Lbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.welcomeSentence2_Lbl.Location = new System.Drawing.Point(108, 40);
            this.welcomeSentence2_Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeSentence2_Lbl.Name = "welcomeSentence2_Lbl";
            this.welcomeSentence2_Lbl.Size = new System.Drawing.Size(382, 23);
            this.welcomeSentence2_Lbl.TabIndex = 2;
            this.welcomeSentence2_Lbl.Text = "Please put your E-mail and Password to login";
            // 
            // welcomeSentence1_Lbl
            // 
            this.welcomeSentence1_Lbl.AutoSize = true;
            this.welcomeSentence1_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.welcomeSentence1_Lbl.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeSentence1_Lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.welcomeSentence1_Lbl.Location = new System.Drawing.Point(106, 8);
            this.welcomeSentence1_Lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeSentence1_Lbl.Name = "welcomeSentence1_Lbl";
            this.welcomeSentence1_Lbl.Size = new System.Drawing.Size(286, 33);
            this.welcomeSentence1_Lbl.TabIndex = 1;
            this.welcomeSentence1_Lbl.Text = "Welcome to IEEE CUSB";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.Image = global::IEEECUSB.Properties.Resources.logo;
            this.logoPictureBox.Location = new System.Drawing.Point(8, 8);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(90, 118);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.SystemColors.Control;
            this.LoginBtn.Location = new System.Drawing.Point(395, 68);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(116, 38);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // mailAddress
            // 
            this.mailAddress.Location = new System.Drawing.Point(187, 68);
            this.mailAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mailAddress.Name = "mailAddress";
            this.mailAddress.Size = new System.Drawing.Size(205, 20);
            this.mailAddress.TabIndex = 3;
            // 
            // mailPassword
            // 
            this.mailPassword.Location = new System.Drawing.Point(187, 89);
            this.mailPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mailPassword.Name = "mailPassword";
            this.mailPassword.PasswordChar = '*';
            this.mailPassword.Size = new System.Drawing.Size(205, 20);
            this.mailPassword.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(109, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(131, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // Remember
            // 
            this.Remember.AutoSize = true;
            this.Remember.BackColor = System.Drawing.Color.Transparent;
            this.Remember.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Remember.Location = new System.Drawing.Point(187, 110);
            this.Remember.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Remember.Name = "Remember";
            this.Remember.Size = new System.Drawing.Size(138, 17);
            this.Remember.TabIndex = 7;
            this.Remember.Text = "Remember this account";
            this.Remember.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IEEECUSB.Properties.Resources.LoginBkGnd;
            this.ClientSize = new System.Drawing.Size(519, 133);
            this.Controls.Add(this.Remember);
            this.Controls.Add(this.welcomeSentence2_Lbl);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.mailAddress);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.welcomeSentence1_Lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mailPassword);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login to IEEE CUSB Portal";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label welcomeSentence2_Lbl;
        private System.Windows.Forms.Label welcomeSentence1_Lbl;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox mailAddress;
        private System.Windows.Forms.TextBox mailPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Remember;
    }
}
namespace IEEECUSB
{
    partial class ViewRequest
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
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReqDescBox = new System.Windows.Forms.TextBox();
            this.RequestTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RequestComm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RequestEndDate = new System.Windows.Forms.TextBox();
            this.RequestStartDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RecComm = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.SuspendLayout();
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.SteelBlue;
            this.label33.Location = new System.Drawing.Point(60, 34);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(585, 23);
            this.label33.TabIndex = 5;
            this.label33.Text = "Here you can view a sent or received request from another committee";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.SteelBlue;
            this.label34.Location = new System.Drawing.Point(58, 2);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(331, 33);
            this.label34.TabIndex = 4;
            this.label34.Text = "View a Committee Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Request Title";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Request Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Receiving Committee";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Request Start Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReqDescBox);
            this.groupBox1.Controls.Add(this.RequestTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(622, 214);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ReqDescBox
            // 
            this.ReqDescBox.Location = new System.Drawing.Point(8, 57);
            this.ReqDescBox.Margin = new System.Windows.Forms.Padding(2);
            this.ReqDescBox.Multiline = true;
            this.ReqDescBox.Name = "ReqDescBox";
            this.ReqDescBox.ReadOnly = true;
            this.ReqDescBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReqDescBox.Size = new System.Drawing.Size(613, 155);
            this.ReqDescBox.TabIndex = 13;
            this.ReqDescBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // RequestTitle
            // 
            this.RequestTitle.Location = new System.Drawing.Point(77, 16);
            this.RequestTitle.Margin = new System.Windows.Forms.Padding(2);
            this.RequestTitle.Name = "RequestTitle";
            this.RequestTitle.ReadOnly = true;
            this.RequestTitle.Size = new System.Drawing.Size(542, 20);
            this.RequestTitle.TabIndex = 11;
            this.RequestTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RequestComm);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.RequestEndDate);
            this.groupBox2.Controls.Add(this.RequestStartDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.RecComm);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(8, 61);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(622, 80);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request ";
            // 
            // RequestComm
            // 
            this.RequestComm.Location = new System.Drawing.Point(123, 13);
            this.RequestComm.Margin = new System.Windows.Forms.Padding(2);
            this.RequestComm.Name = "RequestComm";
            this.RequestComm.ReadOnly = true;
            this.RequestComm.Size = new System.Drawing.Size(175, 20);
            this.RequestComm.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Requesting Committee";
            // 
            // RequestEndDate
            // 
            this.RequestEndDate.ForeColor = System.Drawing.Color.Red;
            this.RequestEndDate.Location = new System.Drawing.Point(444, 54);
            this.RequestEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.RequestEndDate.Name = "RequestEndDate";
            this.RequestEndDate.ReadOnly = true;
            this.RequestEndDate.Size = new System.Drawing.Size(175, 20);
            this.RequestEndDate.TabIndex = 17;
            this.RequestEndDate.Text = "Monday 12/12/2012";
            // 
            // RequestStartDate
            // 
            this.RequestStartDate.Location = new System.Drawing.Point(123, 54);
            this.RequestStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.RequestStartDate.Name = "RequestStartDate";
            this.RequestStartDate.ReadOnly = true;
            this.RequestStartDate.Size = new System.Drawing.Size(175, 20);
            this.RequestStartDate.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Request Deadline";
            // 
            // RecComm
            // 
            this.RecComm.Location = new System.Drawing.Point(444, 13);
            this.RecComm.Margin = new System.Windows.Forms.Padding(2);
            this.RecComm.Name = "RecComm";
            this.RecComm.ReadOnly = true;
            this.RecComm.Size = new System.Drawing.Size(175, 20);
            this.RecComm.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(528, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(8, 360);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(622, 45);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = global::IEEECUSB.Properties.Resources.Requests_2;
            this.pictureBox20.Location = new System.Drawing.Point(8, 8);
            this.pictureBox20.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(53, 50);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 3;
            this.pictureBox20.TabStop = false;
            // 
            // ViewRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 412);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.pictureBox20);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ViewRequest";
            this.Text = "View Request | IEEE CUSB Portal";
            this.Load += new System.EventHandler(this.ViewRequest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RequestTitle;
        private System.Windows.Forms.TextBox ReqDescBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox RecComm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RequestEndDate;
        private System.Windows.Forms.TextBox RequestStartDate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox RequestComm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
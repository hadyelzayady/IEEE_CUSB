namespace IEEECUSB
{
    partial class SubmitRequest
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
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.RequestTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RequestingComm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RequestEndDate = new System.Windows.Forms.TextBox();
            this.RequestStartDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PriorityLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProgressPerc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.SteelBlue;
            this.label33.Location = new System.Drawing.Point(70, 42);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(728, 29);
            this.label33.TabIndex = 8;
            this.label33.Text = "Here you can submit or update the work progress of a received request";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.SteelBlue;
            this.label34.Location = new System.Drawing.Point(68, 3);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(431, 41);
            this.label34.TabIndex = 7;
            this.label34.Text = "Update or Submit a Request";
            this.label34.Click += new System.EventHandler(this.label34_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = global::IEEECUSB.Properties.Resources.Requests_2;
            this.pictureBox20.Location = new System.Drawing.Point(9, 10);
            this.pictureBox20.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(62, 61);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 6;
            this.pictureBox20.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(9, 398);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(742, 55);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 36);
            this.button1.TabIndex = 19;
            this.button1.Text = "View Request";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(523, 13);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 36);
            this.button6.TabIndex = 18;
            this.button6.Text = "Submit";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.UpdateRequest);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(413, 13);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 36);
            this.button5.TabIndex = 17;
            this.button5.Text = "Save Updates";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(632, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 36);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.RequestTitle);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.RequestingComm);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.RequestEndDate);
            this.groupBox2.Controls.Add(this.RequestStartDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.PriorityLevel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(9, 75);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(742, 99);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request ";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(518, 16);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(220, 24);
            this.textBox8.TabIndex = 21;
            // 
            // RequestTitle
            // 
            this.RequestTitle.Location = new System.Drawing.Point(144, 67);
            this.RequestTitle.Margin = new System.Windows.Forms.Padding(2);
            this.RequestTitle.Name = "RequestTitle";
            this.RequestTitle.ReadOnly = true;
            this.RequestTitle.Size = new System.Drawing.Size(204, 24);
            this.RequestTitle.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Request Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Request Title";
            // 
            // RequestingComm
            // 
            this.RequestingComm.Location = new System.Drawing.Point(144, 16);
            this.RequestingComm.Margin = new System.Windows.Forms.Padding(2);
            this.RequestingComm.Name = "RequestingComm";
            this.RequestingComm.ReadOnly = true;
            this.RequestingComm.Size = new System.Drawing.Size(204, 24);
            this.RequestingComm.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Requesting Committee";
            // 
            // RequestEndDate
            // 
            this.RequestEndDate.ForeColor = System.Drawing.Color.Red;
            this.RequestEndDate.Location = new System.Drawing.Point(518, 67);
            this.RequestEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.RequestEndDate.Name = "RequestEndDate";
            this.RequestEndDate.ReadOnly = true;
            this.RequestEndDate.Size = new System.Drawing.Size(220, 24);
            this.RequestEndDate.TabIndex = 17;
            this.RequestEndDate.Text = "Monday 12/12/2012";
            // 
            // RequestStartDate
            // 
            this.RequestStartDate.Location = new System.Drawing.Point(519, 42);
            this.RequestStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.RequestStartDate.Name = "RequestStartDate";
            this.RequestStartDate.ReadOnly = true;
            this.RequestStartDate.Size = new System.Drawing.Size(220, 24);
            this.RequestStartDate.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Request Deadline";
            // 
            // PriorityLevel
            // 
            this.PriorityLevel.Location = new System.Drawing.Point(144, 42);
            this.PriorityLevel.Margin = new System.Windows.Forms.Padding(2);
            this.PriorityLevel.Name = "PriorityLevel";
            this.PriorityLevel.ReadOnly = true;
            this.PriorityLevel.Size = new System.Drawing.Size(204, 24);
            this.PriorityLevel.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Request Priority Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Request Start Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProgressPerc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.progressTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 179);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(742, 219);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Submission Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ProgressPerc
            // 
            this.ProgressPerc.Location = new System.Drawing.Point(144, 20);
            this.ProgressPerc.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressPerc.Name = "ProgressPerc";
            this.ProgressPerc.Size = new System.Drawing.Size(204, 24);
            this.ProgressPerc.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Progress Percentage";
            // 
            // progressTextBox
            // 
            this.progressTextBox.Location = new System.Drawing.Point(9, 70);
            this.progressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.progressTextBox.Multiline = true;
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.progressTextBox.Size = new System.Drawing.Size(730, 145);
            this.progressTextBox.TabIndex = 13;
            this.progressTextBox.TextChanged += new System.EventHandler(this.progressTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Work Progress Details & Notes";
            // 
            // SubmitRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.pictureBox20);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SubmitRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update / Submit Request | IEEE CUSB Portal";
            this.Load += new System.EventHandler(this.SubmitRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox RequestTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RequestingComm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RequestEndDate;
        private System.Windows.Forms.TextBox RequestStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PriorityLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ProgressPerc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox progressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}
﻿namespace IEEECUSB
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
            this.components = new System.ComponentModel.Container();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RequestDesc = new System.Windows.Forms.TextBox();
            this.RequestTitle = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RequestingComm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EditRequest = new System.Windows.Forms.Button();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.RequestStartDate = new System.Windows.Forms.DateTimePicker();
            this.RequestEndDate = new System.Windows.Forms.DateTimePicker();
            this.SaveEdit = new System.Windows.Forms.Button();
            this.Committees = new System.Windows.Forms.ComboBox();
            this.mahmoudMorsyDataSet = new IEEECUSB.MahmoudMorsyDataSet();
            this.committeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.committeeTableAdapter = new IEEECUSB.MahmoudMorsyDataSetTableAdapters.CommitteeTableAdapter();
            this.committeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mahmoudMorsyDataSet1 = new IEEECUSB.MahmoudMorsyDataSet();
            this.mahmoudMorsyDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.committeeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mahmoudMorsyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.committeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.committeeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mahmoudMorsyDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mahmoudMorsyDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.committeeBindingSource2)).BeginInit();
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
            this.label33.Size = new System.Drawing.Size(720, 29);
            this.label33.TabIndex = 5;
            this.label33.Text = "Here you can view a sent or received request from another committee";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.SteelBlue;
            this.label34.Location = new System.Drawing.Point(68, 3);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(412, 41);
            this.label34.TabIndex = 4;
            this.label34.Text = "View a Committee Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Request Title";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Request Priority Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Request Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Receiving Committee";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Request Start Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RequestDesc);
            this.groupBox1.Controls.Add(this.RequestTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 179);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(726, 264);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // RequestDesc
            // 
            this.RequestDesc.Location = new System.Drawing.Point(9, 70);
            this.RequestDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RequestDesc.Multiline = true;
            this.RequestDesc.Name = "RequestDesc";
            this.RequestDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RequestDesc.Size = new System.Drawing.Size(714, 190);
            this.RequestDesc.TabIndex = 13;
            this.RequestDesc.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // RequestTitle
            // 
            this.RequestTitle.Location = new System.Drawing.Point(90, 20);
            this.RequestTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RequestTitle.Name = "RequestTitle";
            this.RequestTitle.Size = new System.Drawing.Size(632, 24);
            this.RequestTitle.TabIndex = 11;
            this.RequestTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(518, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 24);
            this.textBox2.TabIndex = 12;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Committees);
            this.groupBox2.Controls.Add(this.RequestEndDate);
            this.groupBox2.Controls.Add(this.RequestStartDate);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.RequestingComm);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(9, 75);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(726, 99);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request ";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(144, 42);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(204, 24);
            this.textBox8.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Request Type";
            // 
            // RequestingComm
            // 
            this.RequestingComm.Location = new System.Drawing.Point(144, 16);
            this.RequestingComm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RequestingComm.Name = "RequestingComm";
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(616, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 36);
            this.button2.TabIndex = 14;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SaveEdit);
            this.groupBox3.Controls.Add(this.EditRequest);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(9, 443);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(726, 55);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // EditRequest
            // 
            this.EditRequest.Location = new System.Drawing.Point(506, 13);
            this.EditRequest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EditRequest.Name = "EditRequest";
            this.EditRequest.Size = new System.Drawing.Size(105, 36);
            this.EditRequest.TabIndex = 18;
            this.EditRequest.Text = "Edit Request";
            this.EditRequest.UseVisualStyleBackColor = true;
            this.EditRequest.Click += new System.EventHandler(this.EditRequest_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = global::IEEECUSB.Properties.Resources.Requests_2;
            this.pictureBox20.Location = new System.Drawing.Point(9, 10);
            this.pictureBox20.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(62, 61);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 3;
            this.pictureBox20.TabStop = false;
            // 
            // RequestStartDate
            // 
            this.RequestStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RequestStartDate.Location = new System.Drawing.Point(144, 70);
            this.RequestStartDate.Name = "RequestStartDate";
            this.RequestStartDate.Size = new System.Drawing.Size(204, 24);
            this.RequestStartDate.TabIndex = 22;
            // 
            // RequestEndDate
            // 
            this.RequestEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RequestEndDate.Location = new System.Drawing.Point(518, 70);
            this.RequestEndDate.Name = "RequestEndDate";
            this.RequestEndDate.Size = new System.Drawing.Size(204, 24);
            this.RequestEndDate.TabIndex = 23;
            // 
            // SaveEdit
            // 
            this.SaveEdit.Location = new System.Drawing.Point(377, 15);
            this.SaveEdit.Margin = new System.Windows.Forms.Padding(2);
            this.SaveEdit.Name = "SaveEdit";
            this.SaveEdit.Size = new System.Drawing.Size(105, 36);
            this.SaveEdit.TabIndex = 19;
            this.SaveEdit.Text = "Save";
            this.SaveEdit.UseVisualStyleBackColor = true;
            this.SaveEdit.Visible = false;
            // 
            // Committees
            // 
            this.Committees.FormattingEnabled = true;
            this.Committees.Location = new System.Drawing.Point(518, 15);
            this.Committees.Name = "Committees";
            this.Committees.Size = new System.Drawing.Size(208, 24);
            this.Committees.TabIndex = 24;
            this.Committees.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // mahmoudMorsyDataSet
            // 
            this.mahmoudMorsyDataSet.DataSetName = "MahmoudMorsyDataSet";
            this.mahmoudMorsyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // committeeBindingSource
            // 
            this.committeeBindingSource.DataMember = "Committee";
            this.committeeBindingSource.DataSource = this.mahmoudMorsyDataSet;
            // 
            // committeeTableAdapter
            // 
            this.committeeTableAdapter.ClearBeforeFill = true;
            // 
            // committeeBindingSource1
            // 
            this.committeeBindingSource1.DataMember = "Committee";
            this.committeeBindingSource1.DataSource = this.mahmoudMorsyDataSet;
            // 
            // mahmoudMorsyDataSet1
            // 
            this.mahmoudMorsyDataSet1.DataSetName = "MahmoudMorsyDataSet";
            this.mahmoudMorsyDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mahmoudMorsyDataSetBindingSource
            // 
            this.mahmoudMorsyDataSetBindingSource.DataSource = this.mahmoudMorsyDataSet;
            this.mahmoudMorsyDataSetBindingSource.Position = 0;
            // 
            // committeeBindingSource2
            // 
            this.committeeBindingSource2.DataMember = "Committee";
            this.committeeBindingSource2.DataSource = this.mahmoudMorsyDataSet;
            // 
            // ViewRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 507);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.pictureBox20);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            ((System.ComponentModel.ISupportInitialize)(this.mahmoudMorsyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.committeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.committeeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mahmoudMorsyDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mahmoudMorsyDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.committeeBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox RequestTitle;
        private System.Windows.Forms.TextBox RequestDesc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox RequestingComm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button EditRequest;
        private System.Windows.Forms.DateTimePicker RequestEndDate;
        private System.Windows.Forms.DateTimePicker RequestStartDate;
        private System.Windows.Forms.Button SaveEdit;
        private System.Windows.Forms.ComboBox Committees;
        private MahmoudMorsyDataSet mahmoudMorsyDataSet;
        private System.Windows.Forms.BindingSource committeeBindingSource;
        private MahmoudMorsyDataSetTableAdapters.CommitteeTableAdapter committeeTableAdapter;
        private System.Windows.Forms.BindingSource committeeBindingSource1;
        private MahmoudMorsyDataSet mahmoudMorsyDataSet1;
        private System.Windows.Forms.BindingSource mahmoudMorsyDataSetBindingSource;
        private System.Windows.Forms.BindingSource committeeBindingSource2;
    }
}
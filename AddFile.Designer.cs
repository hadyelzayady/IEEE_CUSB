namespace IEEECUSB
{
    partial class AddFile
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
            this.UploadFile = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FileTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            this.SuspendLayout();
            // 
            // UploadFile
            // 
            this.UploadFile.Location = new System.Drawing.Point(304, 88);
            this.UploadFile.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.UploadFile.Name = "UploadFile";
            this.UploadFile.Size = new System.Drawing.Size(90, 29);
            this.UploadFile.TabIndex = 20;
            this.UploadFile.Text = "Upload";
            this.UploadFile.UseVisualStyleBackColor = true;
            this.UploadFile.Click += new System.EventHandler(this.UploadFile_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(210, 88);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(90, 29);
            this.Cancel.TabIndex = 21;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.SteelBlue;
            this.label34.Location = new System.Drawing.Point(57, 2);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(131, 33);
            this.label34.TabIndex = 21;
            this.label34.Text = "Add a File";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.SteelBlue;
            this.label33.Location = new System.Drawing.Point(59, 34);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(198, 23);
            this.label33.TabIndex = 22;
            this.label33.Text = "Here you can add a file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose a File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UploadFile);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.FileDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FileTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BrowseFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(399, 123);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Details";
            // 
            // FileDescription
            // 
            this.FileDescription.Location = new System.Drawing.Point(7, 60);
            this.FileDescription.Margin = new System.Windows.Forms.Padding(2);
            this.FileDescription.Multiline = true;
            this.FileDescription.Name = "FileDescription";
            this.FileDescription.Size = new System.Drawing.Size(187, 59);
            this.FileDescription.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "File Description";
            // 
            // FileTitle
            // 
            this.FileTitle.Location = new System.Drawing.Point(53, 21);
            this.FileTitle.Margin = new System.Windows.Forms.Padding(2);
            this.FileTitle.Name = "FileTitle";
            this.FileTitle.Size = new System.Drawing.Size(141, 20);
            this.FileTitle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "File Title";
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(210, 38);
            this.BrowseFile.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(90, 29);
            this.BrowseFile.TabIndex = 7;
            this.BrowseFile.Text = "Browse";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = global::IEEECUSB.Properties.Resources.Requests_2;
            this.pictureBox20.Location = new System.Drawing.Point(7, 8);
            this.pictureBox20.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(53, 49);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox20.TabIndex = 20;
            this.pictureBox20.TabStop = false;
            // 
            // AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 188);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddFile";
            this.Text = "AddFile";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UploadFile;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox FileDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseFile;
    }
}
namespace IEEECUSB
{
    partial class AdminPanel
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
            this.label10 = new System.Windows.Forms.Label();
            this.CommSeason = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddCommittee = new System.Windows.Forms.Button();
            this.CommHeadID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CommViceID = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.AddSection = new System.Windows.Forms.Button();
            this.SecSuperID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SecDescription = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SecSeason = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SecName = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.AddSeason = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SeasonSecretaryID = new System.Windows.Forms.TextBox();
            this.SeasonTreasurerID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NewSeasonName = new System.Windows.Forms.TextBox();
            this.SeasonChairID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SeasonViceID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.CommSection = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CommName = new System.Windows.Forms.TextBox();
            this.View = new System.Windows.Forms.TabPage();
            this.TableGrid = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ChooseTableBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.TablesList = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Add.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Name";
            // 
            // CommSeason
            // 
            this.CommSeason.FormattingEnabled = true;
            this.CommSeason.Location = new System.Drawing.Point(8, 40);
            this.CommSeason.Name = "CommSeason";
            this.CommSeason.Size = new System.Drawing.Size(235, 28);
            this.CommSeason.TabIndex = 11;
            this.CommSeason.SelectionChangeCommitted += new System.EventHandler(this.CommSeason_SelectionChangeCommitted);
            this.CommSeason.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CommSeason_MouseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Season";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Belonging Section";
            // 
            // AddCommittee
            // 
            this.AddCommittee.Location = new System.Drawing.Point(424, 75);
            this.AddCommittee.Name = "AddCommittee";
            this.AddCommittee.Size = new System.Drawing.Size(135, 45);
            this.AddCommittee.TabIndex = 1;
            this.AddCommittee.Text = "Add Committee";
            this.AddCommittee.UseVisualStyleBackColor = true;
            this.AddCommittee.Click += new System.EventHandler(this.AddCommittee_Click);
            // 
            // CommHeadID
            // 
            this.CommHeadID.Location = new System.Drawing.Point(122, 42);
            this.CommHeadID.Name = "CommHeadID";
            this.CommHeadID.Size = new System.Drawing.Size(218, 26);
            this.CommHeadID.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Vice Head ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Head ID";
            // 
            // CommViceID
            // 
            this.CommViceID.Location = new System.Drawing.Point(122, 74);
            this.CommViceID.Name = "CommViceID";
            this.CommViceID.Size = new System.Drawing.Size(218, 26);
            this.CommViceID.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1216, 118);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Section";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.AddSection);
            this.panel4.Controls.Add(this.SecSuperID);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(796, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(417, 93);
            this.panel4.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Supervisor ID";
            // 
            // AddSection
            // 
            this.AddSection.Location = new System.Drawing.Point(260, 40);
            this.AddSection.Name = "AddSection";
            this.AddSection.Size = new System.Drawing.Size(135, 45);
            this.AddSection.TabIndex = 1;
            this.AddSection.Text = "Add Section";
            this.AddSection.UseVisualStyleBackColor = true;
            this.AddSection.Click += new System.EventHandler(this.AddSection_Click);
            // 
            // SecSuperID
            // 
            this.SecSuperID.Location = new System.Drawing.Point(177, 8);
            this.SecSuperID.Name = "SecSuperID";
            this.SecSuperID.Size = new System.Drawing.Size(218, 26);
            this.SecSuperID.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SecDescription);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.SecSeason);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.SecName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 93);
            this.panel3.TabIndex = 5;
            // 
            // SecDescription
            // 
            this.SecDescription.Location = new System.Drawing.Point(372, 42);
            this.SecDescription.Name = "SecDescription";
            this.SecDescription.Size = new System.Drawing.Size(294, 26);
            this.SecDescription.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(368, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 20);
            this.label17.TabIndex = 14;
            this.label17.Text = "Description";
            // 
            // SecSeason
            // 
            this.SecSeason.FormattingEnabled = true;
            this.SecSeason.Location = new System.Drawing.Point(122, 42);
            this.SecSeason.Name = "SecSeason";
            this.SecSeason.Size = new System.Drawing.Size(218, 28);
            this.SecSeason.TabIndex = 13;
            this.SecSeason.SelectionChangeCommitted += new System.EventHandler(this.SecSeason_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "Season";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Name";
            // 
            // SecName
            // 
            this.SecName.Location = new System.Drawing.Point(122, 9);
            this.SecName.Name = "SecName";
            this.SecName.Size = new System.Drawing.Size(218, 26);
            this.SecName.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Controls.Add(this.groupBox1);
            this.Add.Controls.Add(this.groupBox3);
            this.Add.Controls.Add(this.groupBox2);
            this.Add.Location = new System.Drawing.Point(4, 29);
            this.Add.Name = "Add";
            this.Add.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Add.Size = new System.Drawing.Size(1222, 466);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1216, 149);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Season";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.AddSeason);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.SeasonSecretaryID);
            this.panel2.Controls.Add(this.SeasonTreasurerID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(855, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 124);
            this.panel2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Secretary ID";
            // 
            // AddSeason
            // 
            this.AddSeason.Location = new System.Drawing.Point(202, 74);
            this.AddSeason.Name = "AddSeason";
            this.AddSeason.Size = new System.Drawing.Size(135, 45);
            this.AddSeason.TabIndex = 1;
            this.AddSeason.Text = "Add Season";
            this.AddSeason.UseVisualStyleBackColor = true;
            this.AddSeason.Click += new System.EventHandler(this.AddSeason_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Treasurer ID";
            // 
            // SeasonSecretaryID
            // 
            this.SeasonSecretaryID.Location = new System.Drawing.Point(118, 9);
            this.SeasonSecretaryID.Name = "SeasonSecretaryID";
            this.SeasonSecretaryID.Size = new System.Drawing.Size(218, 26);
            this.SeasonSecretaryID.TabIndex = 7;
            // 
            // SeasonTreasurerID
            // 
            this.SeasonTreasurerID.Location = new System.Drawing.Point(118, 42);
            this.SeasonTreasurerID.Name = "SeasonTreasurerID";
            this.SeasonTreasurerID.Size = new System.Drawing.Size(218, 26);
            this.SeasonTreasurerID.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NewSeasonName);
            this.panel1.Controls.Add(this.SeasonChairID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SeasonViceID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 124);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Season";
            // 
            // NewSeasonName
            // 
            this.NewSeasonName.Location = new System.Drawing.Point(122, 9);
            this.NewSeasonName.Name = "NewSeasonName";
            this.NewSeasonName.Size = new System.Drawing.Size(218, 26);
            this.NewSeasonName.TabIndex = 0;
            // 
            // SeasonChairID
            // 
            this.SeasonChairID.Location = new System.Drawing.Point(122, 42);
            this.SeasonChairID.Name = "SeasonChairID";
            this.SeasonChairID.Size = new System.Drawing.Size(218, 26);
            this.SeasonChairID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chair ID";
            // 
            // SeasonViceID
            // 
            this.SeasonViceID.Location = new System.Drawing.Point(122, 74);
            this.SeasonViceID.Name = "SeasonViceID";
            this.SeasonViceID.Size = new System.Drawing.Size(218, 26);
            this.SeasonViceID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vice Chair ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1216, 149);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Committee";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.CommSeason);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.AddCommittee);
            this.panel6.Controls.Add(this.CommSection);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(631, 22);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(582, 124);
            this.panel6.TabIndex = 11;
            // 
            // CommSection
            // 
            this.CommSection.FormattingEnabled = true;
            this.CommSection.Location = new System.Drawing.Point(248, 40);
            this.CommSection.Name = "CommSection";
            this.CommSection.Size = new System.Drawing.Size(312, 28);
            this.CommSection.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.CommName);
            this.panel5.Controls.Add(this.CommHeadID);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.CommViceID);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(3, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(354, 124);
            this.panel5.TabIndex = 10;
            // 
            // CommName
            // 
            this.CommName.Location = new System.Drawing.Point(122, 9);
            this.CommName.Name = "CommName";
            this.CommName.Size = new System.Drawing.Size(218, 26);
            this.CommName.TabIndex = 0;
            // 
            // View
            // 
            this.View.Controls.Add(this.TableGrid);
            this.View.Controls.Add(this.panel7);
            this.View.Location = new System.Drawing.Point(4, 29);
            this.View.Name = "View";
            this.View.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.View.Size = new System.Drawing.Size(1222, 427);
            this.View.TabIndex = 1;
            this.View.Text = "View Tables";
            this.View.UseVisualStyleBackColor = true;
            // 
            // TableGrid
            // 
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableGrid.Location = new System.Drawing.Point(3, 58);
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.RowTemplate.Height = 28;
            this.TableGrid.Size = new System.Drawing.Size(1216, 366);
            this.TableGrid.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ChooseTableBtn);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.TablesList);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1216, 55);
            this.panel7.TabIndex = 4;
            // 
            // ChooseTableBtn
            // 
            this.ChooseTableBtn.Location = new System.Drawing.Point(752, 3);
            this.ChooseTableBtn.Name = "ChooseTableBtn";
            this.ChooseTableBtn.Size = new System.Drawing.Size(152, 45);
            this.ChooseTableBtn.TabIndex = 2;
            this.ChooseTableBtn.Text = "Choose";
            this.ChooseTableBtn.UseVisualStyleBackColor = true;
            this.ChooseTableBtn.Click += new System.EventHandler(this.ChooseTableBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Choose a Table";
            // 
            // TablesList
            // 
            this.TablesList.FormattingEnabled = true;
            this.TablesList.Location = new System.Drawing.Point(136, 12);
            this.TablesList.Name = "TablesList";
            this.TablesList.Size = new System.Drawing.Size(608, 28);
            this.TablesList.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Add);
            this.tabControl1.Controls.Add(this.View);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1230, 499);
            this.tabControl1.TabIndex = 15;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.button1);
            this.panel19.Controls.Add(this.RefreshBtn);
            this.panel19.Controls.Add(this.label15);
            this.panel19.Controls.Add(this.label16);
            this.panel19.Controls.Add(this.pictureBox5);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(1230, 95);
            this.panel19.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Corbel", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.SteelBlue;
            this.label15.Location = new System.Drawing.Point(88, 55);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(653, 35);
            this.label15.TabIndex = 2;
            this.label15.Text = "Here you can add and view any committee or section";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Corbel", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SteelBlue;
            this.label16.Location = new System.Drawing.Point(88, 6);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(242, 49);
            this.label16.TabIndex = 1;
            this.label16.Text = "Admin Panel";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.RefreshBtn.Image = global::IEEECUSB.Properties.Resources.Refresh_S;
            this.RefreshBtn.Location = new System.Drawing.Point(1136, 0);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(94, 95);
            this.RefreshBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RefreshBtn.TabIndex = 9;
            this.RefreshBtn.TabStop = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::IEEECUSB.Properties.Resources.Docs_icon1;
            this.pictureBox5.Location = new System.Drawing.Point(12, 8);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(74, 77);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(953, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 95);
            this.button1.TabIndex = 10;
            this.button1.Text = "Change Password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 594);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel19);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Add.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.View.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CommSeason;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddCommittee;
        private System.Windows.Forms.TextBox CommHeadID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CommViceID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AddSection;
        private System.Windows.Forms.TextBox SecSuperID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox SecDescription;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox SecSeason;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SecName;
        private System.Windows.Forms.TabPage Add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddSeason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SeasonSecretaryID;
        private System.Windows.Forms.TextBox SeasonTreasurerID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewSeasonName;
        private System.Windows.Forms.TextBox SeasonChairID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SeasonViceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox CommSection;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox CommName;
        private System.Windows.Forms.TabPage View;
        private System.Windows.Forms.DataGridView TableGrid;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button ChooseTableBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox TablesList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.PictureBox RefreshBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button button1;
    }
}
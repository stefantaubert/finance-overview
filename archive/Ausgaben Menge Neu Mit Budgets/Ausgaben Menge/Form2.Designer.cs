namespace WindowsFormsApplication1
{
    partial class Form2
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "12.32.12",
            "TEST",
            "+12,32 EUR"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ändernToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbBudgets = new System.Windows.Forms.ToolStripComboBox();
            this.budgetToolB = new System.Windows.Forms.ToolStripMenuItem();
            this.ändernToolB = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolB = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolB = new System.Windows.Forms.ToolStripMenuItem();
            this.zurücksetzenToolB = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPresets = new System.Windows.Forms.ToolStripComboBox();
            this.presetsToolP = new System.Windows.Forms.ToolStripMenuItem();
            this.ändernToolP = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolP = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbMonate = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userControlStatistik1 = new WindowsFormsApplication1.UserControlStatistik();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userControlStatistik2 = new WindowsFormsApplication1.UserControlStatistik();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.userControlStatistik3 = new WindowsFormsApplication1.UserControlStatistik();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.userControlStatistik4 = new WindowsFormsApplication1.UserControlStatistik();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(76, 12);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 20);
            this.textBox1.TabIndex = 22;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bezeichnung";
            this.columnHeader1.Width = 144;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tag";
            this.columnHeader4.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Betrag";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 116;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "dddd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(330, 33);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.MaxDate = new System.DateTime(9988, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(79, 20);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem1.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(10, 90);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(474, 264);
            this.listView1.TabIndex = 29;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ändernToolStripMenuItem1,
            this.löschenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 48);
            // 
            // ändernToolStripMenuItem1
            // 
            this.ändernToolStripMenuItem1.Name = "ändernToolStripMenuItem1";
            this.ändernToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.ändernToolStripMenuItem1.Text = "Ändern";
            this.ändernToolStripMenuItem1.Click += new System.EventHandler(this.ändernToolStripMenuItem1_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Bezeichnung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Betrag";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(114, 33);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(196, 20);
            this.textBox2.TabIndex = 24;
            // 
            // cbBudgets
            // 
            this.cbBudgets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBudgets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBudgets.ForeColor = System.Drawing.Color.Blue;
            this.cbBudgets.Name = "cbBudgets";
            this.cbBudgets.Size = new System.Drawing.Size(121, 23);
            this.cbBudgets.SelectedIndexChanged += new System.EventHandler(this.comboBoxBudgetSIC);
            // 
            // budgetToolB
            // 
            this.budgetToolB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ändernToolB,
            this.neuToolB,
            this.löschenToolB,
            this.zurücksetzenToolB});
            this.budgetToolB.Name = "budgetToolB";
            this.budgetToolB.Size = new System.Drawing.Size(53, 23);
            this.budgetToolB.Text = "Rubrik";
            // 
            // ändernToolB
            // 
            this.ändernToolB.Name = "ändernToolB";
            this.ändernToolB.Size = new System.Drawing.Size(152, 22);
            this.ändernToolB.Text = "Ändern";
            this.ändernToolB.Click += new System.EventHandler(this.ändern_Click);
            // 
            // neuToolB
            // 
            this.neuToolB.Name = "neuToolB";
            this.neuToolB.Size = new System.Drawing.Size(152, 22);
            this.neuToolB.Text = "Hinzufügen";
            this.neuToolB.Click += new System.EventHandler(this.neu_Click);
            // 
            // löschenToolB
            // 
            this.löschenToolB.Name = "löschenToolB";
            this.löschenToolB.Size = new System.Drawing.Size(152, 22);
            this.löschenToolB.Text = "Löschen";
            this.löschenToolB.Click += new System.EventHandler(this.löschen_Click);
            // 
            // zurücksetzenToolB
            // 
            this.zurücksetzenToolB.Name = "zurücksetzenToolB";
            this.zurücksetzenToolB.Size = new System.Drawing.Size(152, 22);
            this.zurücksetzenToolB.Text = "Zurücksetzen";
            this.zurücksetzenToolB.Click += new System.EventHandler(this.zurücksetzen_Click);
            // 
            // cbPresets
            // 
            this.cbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPresets.Name = "cbPresets";
            this.cbPresets.Size = new System.Drawing.Size(121, 23);
            this.cbPresets.SelectedIndexChanged += new System.EventHandler(this.comboBoxPresets_SelectedIndexChanged);
            // 
            // presetsToolP
            // 
            this.presetsToolP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.presetsToolP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.presetsToolP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ändernToolP,
            this.neuToolStripMenuItem,
            this.löschenToolP,
            this.clearToolP});
            this.presetsToolP.Name = "presetsToolP";
            this.presetsToolP.Size = new System.Drawing.Size(51, 23);
            this.presetsToolP.Text = "Preset";
            this.presetsToolP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.presetsToolP.DropDownOpening += new System.EventHandler(this.presetsTSMI_DDO);
            // 
            // ändernToolP
            // 
            this.ändernToolP.Name = "ändernToolP";
            this.ändernToolP.Size = new System.Drawing.Size(118, 22);
            this.ändernToolP.Text = "Ändern";
            this.ändernToolP.Click += new System.EventHandler(this.ändernToolP_Click);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // löschenToolP
            // 
            this.löschenToolP.Name = "löschenToolP";
            this.löschenToolP.Size = new System.Drawing.Size(118, 22);
            this.löschenToolP.Text = "Löschen";
            this.löschenToolP.Click += new System.EventHandler(this.löschenToolStripMenuItem2_Click);
            // 
            // clearToolP
            // 
            this.clearToolP.Name = "clearToolP";
            this.clearToolP.Size = new System.Drawing.Size(118, 22);
            this.clearToolP.Text = "Clear";
            this.clearToolP.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.budgetToolB,
            this.cbBudgets,
            this.cbMonate,
            this.presetsToolP,
            this.cbPresets});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(491, 27);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cbMonate
            // 
            this.cbMonate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonate.ForeColor = System.Drawing.Color.Blue;
            this.cbMonate.Name = "cbMonate";
            this.cbMonate.Size = new System.Drawing.Size(121, 23);
            this.cbMonate.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonate_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(474, 58);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eintrag";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(314, 33);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(17, 19);
            this.button2.TabIndex = 30;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-",
            "+"});
            this.comboBox1.Location = new System.Drawing.Point(76, 33);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(34, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.PaperMoney;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(413, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 41);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(10, 358);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 78);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userControlStatistik1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(465, 52);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Aktueller Monat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // userControlStatistik1
            // 
            this.userControlStatistik1.Bezeichnung = "Aktueller Monat";
            this.userControlStatistik1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlStatistik1.Location = new System.Drawing.Point(2, 2);
            this.userControlStatistik1.Margin = new System.Windows.Forms.Padding(4);
            this.userControlStatistik1.Name = "userControlStatistik1";
            this.userControlStatistik1.Size = new System.Drawing.Size(461, 48);
            this.userControlStatistik1.TabIndex = 34;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.userControlStatistik2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(465, 52);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alle Monate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // userControlStatistik2
            // 
            this.userControlStatistik2.Bezeichnung = "Alle Monate";
            this.userControlStatistik2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlStatistik2.Location = new System.Drawing.Point(2, 2);
            this.userControlStatistik2.Margin = new System.Windows.Forms.Padding(4);
            this.userControlStatistik2.Name = "userControlStatistik2";
            this.userControlStatistik2.Size = new System.Drawing.Size(461, 48);
            this.userControlStatistik2.TabIndex = 35;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.userControlStatistik3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(465, 52);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Auswahl";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // userControlStatistik3
            // 
            this.userControlStatistik3.Bezeichnung = "Auswahl";
            this.userControlStatistik3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlStatistik3.Location = new System.Drawing.Point(2, 2);
            this.userControlStatistik3.Margin = new System.Windows.Forms.Padding(4);
            this.userControlStatistik3.Name = "userControlStatistik3";
            this.userControlStatistik3.Size = new System.Drawing.Size(461, 48);
            this.userControlStatistik3.TabIndex = 36;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.userControlStatistik4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(465, 52);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Aktuelle Woche";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // userControlStatistik4
            // 
            this.userControlStatistik4.Bezeichnung = "Überblick";
            this.userControlStatistik4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlStatistik4.Location = new System.Drawing.Point(2, 2);
            this.userControlStatistik4.Name = "userControlStatistik4";
            this.userControlStatistik4.Size = new System.Drawing.Size(461, 48);
            this.userControlStatistik4.TabIndex = 0;
            // 
            // Form2
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ausgaben Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripComboBox cbBudgets;
        private System.Windows.Forms.ToolStripMenuItem budgetToolB;
        private System.Windows.Forms.ToolStripMenuItem neuToolB;
        private System.Windows.Forms.ToolStripMenuItem löschenToolB;
        private System.Windows.Forms.ToolStripMenuItem zurücksetzenToolB;
        private System.Windows.Forms.ToolStripComboBox cbPresets;
        private System.Windows.Forms.ToolStripMenuItem presetsToolP;
        private System.Windows.Forms.ToolStripMenuItem löschenToolP;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox cbMonate;
        private UserControlStatistik userControlStatistik1;
        private UserControlStatistik userControlStatistik3;
        private UserControlStatistik userControlStatistik2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ändernToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem clearToolP;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem ändernToolB;
        private System.Windows.Forms.ToolStripMenuItem ändernToolP;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private UserControlStatistik userControlStatistik4;
        private System.Windows.Forms.Button button2;
    }
}
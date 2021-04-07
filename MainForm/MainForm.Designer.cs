namespace MainForm
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewIP = new System.Windows.Forms.DataGridView();
            this.ColumnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonImport = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxComboBoxCountries = new PresentationControls.CheckBoxComboBox();
            this.buttonWriteToTxt = new System.Windows.Forms.Button();
            this.TextBoxSearch = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.checkBoxIPv4 = new System.Windows.Forms.CheckBox();
            this.checkBoxIPv6 = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.textBoxImport = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.buttonFlat2 = new System.Windows.Forms.Button();
            this.radioButtonAscending = new System.Windows.Forms.RadioButton();
            this.radioButtonDescending = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIP)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewIP
            // 
            this.dataGridViewIP.AllowUserToAddRows = false;
            this.dataGridViewIP.AllowUserToDeleteRows = false;
            this.dataGridViewIP.AllowUserToResizeColumns = false;
            this.dataGridViewIP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dataGridViewIP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewIP.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewIP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridViewIP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewIP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewIP.ColumnHeadersHeight = 35;
            this.dataGridViewIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIP,
            this.ColumnType,
            this.ColumnCountry,
            this.ColumnCity,
            this.ColumnISP});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewIP.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewIP.EnableHeadersVisualStyles = false;
            this.dataGridViewIP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewIP.Location = new System.Drawing.Point(12, 116);
            this.dataGridViewIP.Name = "dataGridViewIP";
            this.dataGridViewIP.ReadOnly = true;
            this.dataGridViewIP.RowHeadersVisible = false;
            this.dataGridViewIP.RowHeadersWidth = 51;
            this.dataGridViewIP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewIP.RowTemplate.Height = 24;
            this.dataGridViewIP.Size = new System.Drawing.Size(1258, 455);
            this.dataGridViewIP.TabIndex = 0;
            this.dataGridViewIP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIP_CellClick);
            this.dataGridViewIP.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewIP_ColumnHeaderMouseClick);
            // 
            // ColumnIP
            // 
            this.ColumnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnIP.DataPropertyName = "ip";
            this.ColumnIP.HeaderText = "IP Address";
            this.ColumnIP.MinimumWidth = 6;
            this.ColumnIP.Name = "ColumnIP";
            this.ColumnIP.ReadOnly = true;
            this.ColumnIP.Width = 150;
            // 
            // ColumnType
            // 
            this.ColumnType.DataPropertyName = "type";
            this.ColumnType.FillWeight = 205.4054F;
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.MinimumWidth = 6;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 60;
            // 
            // ColumnCountry
            // 
            this.ColumnCountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCountry.DataPropertyName = "country";
            this.ColumnCountry.FillWeight = 64.86486F;
            this.ColumnCountry.HeaderText = "Country";
            this.ColumnCountry.MinimumWidth = 6;
            this.ColumnCountry.Name = "ColumnCountry";
            this.ColumnCountry.ReadOnly = true;
            // 
            // ColumnCity
            // 
            this.ColumnCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCity.DataPropertyName = "city";
            this.ColumnCity.FillWeight = 64.86486F;
            this.ColumnCity.HeaderText = "City";
            this.ColumnCity.MinimumWidth = 6;
            this.ColumnCity.Name = "ColumnCity";
            this.ColumnCity.ReadOnly = true;
            // 
            // ColumnISP
            // 
            this.ColumnISP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnISP.DataPropertyName = "isp";
            this.ColumnISP.FillWeight = 64.86486F;
            this.ColumnISP.HeaderText = "Internet Service Provider";
            this.ColumnISP.MinimumWidth = 280;
            this.ColumnISP.Name = "ColumnISP";
            this.ColumnISP.ReadOnly = true;
            // 
            // buttonImport
            // 
            this.buttonImport.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonImport.FlatAppearance.BorderSize = 0;
            this.buttonImport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImport.Location = new System.Drawing.Point(1142, 7);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(101, 43);
            this.buttonImport.TabIndex = 1;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(120, 25);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1258, 98);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.checkBoxComboBoxCountries);
            this.tabPage2.Controls.Add(this.buttonWriteToTxt);
            this.tabPage2.Controls.Add(this.TextBoxSearch);
            this.tabPage2.Controls.Add(this.checkBoxIPv4);
            this.tabPage2.Controls.Add(this.checkBoxIPv6);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1250, 65);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxComboBoxCountries
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBoxCountries.CheckBoxProperties = checkBoxProperties1;
            this.checkBoxComboBoxCountries.DisplayMemberSingleItem = "";
            this.checkBoxComboBoxCountries.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxComboBoxCountries.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBoxComboBoxCountries.FormattingEnabled = true;
            this.checkBoxComboBoxCountries.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "o",
            "n",
            "s"});
            this.checkBoxComboBoxCountries.Location = new System.Drawing.Point(759, 7);
            this.checkBoxComboBoxCountries.Name = "checkBoxComboBoxCountries";
            this.checkBoxComboBoxCountries.Size = new System.Drawing.Size(263, 44);
            this.checkBoxComboBoxCountries.TabIndex = 9;
            this.checkBoxComboBoxCountries.TextChanged += new System.EventHandler(this.checkBoxComboBoxCountries_TextChanged);
            this.checkBoxComboBoxCountries.Click += new System.EventHandler(this.checkBoxComboBoxCountries_Click);
            // 
            // buttonWriteToTxt
            // 
            this.buttonWriteToTxt.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonWriteToTxt.FlatAppearance.BorderSize = 0;
            this.buttonWriteToTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWriteToTxt.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteToTxt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonWriteToTxt.Image = global::MainForm.Properties.Resources.log2;
            this.buttonWriteToTxt.Location = new System.Drawing.Point(6, 7);
            this.buttonWriteToTxt.Name = "buttonWriteToTxt";
            this.buttonWriteToTxt.Size = new System.Drawing.Size(43, 43);
            this.buttonWriteToTxt.TabIndex = 7;
            this.buttonWriteToTxt.UseVisualStyleBackColor = false;
            this.buttonWriteToTxt.Click += new System.EventHandler(this.buttonWriteToTxt_Click);
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxSearch.Location = new System.Drawing.Point(58, 7);
            this.TextBoxSearch.Margin = new System.Windows.Forms.Padding(6);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(692, 43);
            this.TextBoxSearch.TabIndex = 6;
            this.TextBoxSearch.WaterMark = "Search based on attribute";
            this.TextBoxSearch.WaterMarkActiveForeColor = System.Drawing.Color.Silver;
            this.TextBoxSearch.WaterMarkFont = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxSearch.WaterMarkForeColor = System.Drawing.Color.LightGray;
            this.TextBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // checkBoxIPv4
            // 
            this.checkBoxIPv4.AutoSize = true;
            this.checkBoxIPv4.Checked = true;
            this.checkBoxIPv4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIPv4.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIPv4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBoxIPv4.Location = new System.Drawing.Point(1030, 9);
            this.checkBoxIPv4.Name = "checkBoxIPv4";
            this.checkBoxIPv4.Size = new System.Drawing.Size(101, 40);
            this.checkBoxIPv4.TabIndex = 5;
            this.checkBoxIPv4.Text = "IPv4";
            this.checkBoxIPv4.UseVisualStyleBackColor = true;
            this.checkBoxIPv4.CheckedChanged += new System.EventHandler(this.checkBoxIPv4_CheckedChanged);
            // 
            // checkBoxIPv6
            // 
            this.checkBoxIPv6.AutoSize = true;
            this.checkBoxIPv6.Checked = true;
            this.checkBoxIPv6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIPv6.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIPv6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBoxIPv6.Location = new System.Drawing.Point(1143, 9);
            this.checkBoxIPv6.Name = "checkBoxIPv6";
            this.checkBoxIPv6.Size = new System.Drawing.Size(101, 40);
            this.checkBoxIPv6.TabIndex = 4;
            this.checkBoxIPv6.Text = "IPv6";
            this.checkBoxIPv6.UseVisualStyleBackColor = true;
            this.checkBoxIPv6.CheckedChanged += new System.EventHandler(this.checkBoxIPv6_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonRandom);
            this.tabPage1.Controls.Add(this.textBoxImport);
            this.tabPage1.Controls.Add(this.buttonImport);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1250, 65);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonRandom
            // 
            this.buttonRandom.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonRandom.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRandom.FlatAppearance.BorderSize = 0;
            this.buttonRandom.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandom.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRandom.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandom.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRandom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRandom.Location = new System.Drawing.Point(6, 7);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(94, 43);
            this.buttonRandom.TabIndex = 8;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = false;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // textBoxImport
            // 
            this.textBoxImport.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxImport.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImport.Location = new System.Drawing.Point(109, 7);
            this.textBoxImport.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxImport.Name = "textBoxImport";
            this.textBoxImport.Size = new System.Drawing.Size(1024, 43);
            this.textBoxImport.TabIndex = 5;
            this.textBoxImport.WaterMark = "Input IP address";
            this.textBoxImport.WaterMarkActiveForeColor = System.Drawing.Color.Silver;
            this.textBoxImport.WaterMarkFont = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImport.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.White;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "IP",
            "Country",
            "City",
            "Internet Service Provider"});
            this.comboBox.Location = new System.Drawing.Point(163, 581);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(400, 30);
            this.comboBox.TabIndex = 1;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonFlat2
            // 
            this.buttonFlat2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonFlat2.FlatAppearance.BorderSize = 0;
            this.buttonFlat2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonFlat2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonFlat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFlat2.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFlat2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonFlat2.Location = new System.Drawing.Point(12, 577);
            this.buttonFlat2.Name = "buttonFlat2";
            this.buttonFlat2.Size = new System.Drawing.Size(824, 40);
            this.buttonFlat2.TabIndex = 10;
            this.buttonFlat2.Text = "Order by";
            this.buttonFlat2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFlat2.UseVisualStyleBackColor = false;
            // 
            // radioButtonAscending
            // 
            this.radioButtonAscending.AutoSize = true;
            this.radioButtonAscending.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radioButtonAscending.Checked = true;
            this.radioButtonAscending.FlatAppearance.BorderSize = 0;
            this.radioButtonAscending.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.radioButtonAscending.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAscending.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.radioButtonAscending.Image = global::MainForm.Properties.Resources.arrow_up;
            this.radioButtonAscending.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonAscending.Location = new System.Drawing.Point(842, 577);
            this.radioButtonAscending.Name = "radioButtonAscending";
            this.radioButtonAscending.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.radioButtonAscending.Size = new System.Drawing.Size(196, 39);
            this.radioButtonAscending.TabIndex = 11;
            this.radioButtonAscending.TabStop = true;
            this.radioButtonAscending.Text = "Ascending ";
            this.radioButtonAscending.UseVisualStyleBackColor = false;
            this.radioButtonAscending.CheckedChanged += new System.EventHandler(this.radioButtonAscending_CheckedChanged);
            // 
            // radioButtonDescending
            // 
            this.radioButtonDescending.AutoSize = true;
            this.radioButtonDescending.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radioButtonDescending.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDescending.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.radioButtonDescending.Image = global::MainForm.Properties.Resources.arrow_down;
            this.radioButtonDescending.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonDescending.Location = new System.Drawing.Point(1060, 577);
            this.radioButtonDescending.Name = "radioButtonDescending";
            this.radioButtonDescending.Padding = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.radioButtonDescending.Size = new System.Drawing.Size(196, 39);
            this.radioButtonDescending.TabIndex = 7;
            this.radioButtonDescending.Text = "Descening ";
            this.radioButtonDescending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonDescending.UseVisualStyleBackColor = false;
            this.radioButtonDescending.CheckedChanged += new System.EventHandler(this.radioButtonDescending_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1282, 629);
            this.Controls.Add(this.radioButtonAscending);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.radioButtonDescending);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.dataGridViewIP);
            this.Controls.Add(this.buttonFlat2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.MinimumSize = new System.Drawing.Size(1300, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "IP WHOis";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIP)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ChreneLib.Controls.TextBoxes.CTextBox textBoxImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnISP;
        public System.Windows.Forms.DataGridView dataGridViewIP;
        private System.Windows.Forms.Button buttonFlat2;
        public System.Windows.Forms.CheckBox checkBoxIPv6;
        public System.Windows.Forms.CheckBox checkBoxIPv4;
        public ChreneLib.Controls.TextBoxes.CTextBox TextBoxSearch;
        public System.Windows.Forms.RadioButton radioButtonDescending;
        public System.Windows.Forms.ComboBox comboBox;
        public System.Windows.Forms.RadioButton radioButtonAscending;
        private System.Windows.Forms.Button buttonWriteToTxt;
        private System.Windows.Forms.Button buttonRandom;
        private PresentationControls.CheckBoxComboBox checkBoxComboBoxCountries;
    }
}


namespace LightingCalculator
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MaintenanceFactorTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TargetLuxTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WorkingPlaneHeightTxtBox = new System.Windows.Forms.TextBox();
            this.LightHeightTxtBox = new System.Windows.Forms.TextBox();
            this.CeilingHeightTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FloorFactorCombo = new System.Windows.Forms.ComboBox();
            this.CeilingFactorCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WallFactorCombo = new System.Windows.Forms.ComboBox();
            this.CADBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 644);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RemoveBtn);
            this.tabPage1.Controls.Add(this.AddBtn);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Light Choices";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(474, 585);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(133, 23);
            this.RemoveBtn.TabIndex = 5;
            this.RemoveBtn.Text = "Remove From Selected";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(119, 585);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(98, 23);
            this.AddBtn.TabIndex = 3;
            this.AddBtn.Text = "Add to Selected";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(359, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(345, 576);
            this.listBox2.TabIndex = 4;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(345, 576);
            this.listBox1.TabIndex = 3;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lighting Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MaintenanceFactorTxtBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TargetLuxTxtBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(493, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 109);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Illuminance";
            // 
            // MaintenanceFactorTxtBox
            // 
            this.MaintenanceFactorTxtBox.Location = new System.Drawing.Point(116, 51);
            this.MaintenanceFactorTxtBox.Name = "MaintenanceFactorTxtBox";
            this.MaintenanceFactorTxtBox.Size = new System.Drawing.Size(86, 20);
            this.MaintenanceFactorTxtBox.TabIndex = 17;
            this.MaintenanceFactorTxtBox.Text = "0.8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Maintenace Factor";
            // 
            // TargetLuxTxtBox
            // 
            this.TargetLuxTxtBox.Location = new System.Drawing.Point(116, 24);
            this.TargetLuxTxtBox.Name = "TargetLuxTxtBox";
            this.TargetLuxTxtBox.Size = new System.Drawing.Size(86, 20);
            this.TargetLuxTxtBox.TabIndex = 15;
            this.TargetLuxTxtBox.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Target Lux";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.WorkingPlaneHeightTxtBox);
            this.groupBox2.Controls.Add(this.LightHeightTxtBox);
            this.groupBox2.Controls.Add(this.CeilingHeightTxtBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(229, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 109);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Room Index";
            // 
            // WorkingPlaneHeightTxtBox
            // 
            this.WorkingPlaneHeightTxtBox.Location = new System.Drawing.Point(146, 75);
            this.WorkingPlaneHeightTxtBox.Name = "WorkingPlaneHeightTxtBox";
            this.WorkingPlaneHeightTxtBox.Size = new System.Drawing.Size(100, 20);
            this.WorkingPlaneHeightTxtBox.TabIndex = 17;
            this.WorkingPlaneHeightTxtBox.Text = "0.9";
            // 
            // LightHeightTxtBox
            // 
            this.LightHeightTxtBox.Location = new System.Drawing.Point(146, 49);
            this.LightHeightTxtBox.Name = "LightHeightTxtBox";
            this.LightHeightTxtBox.Size = new System.Drawing.Size(100, 20);
            this.LightHeightTxtBox.TabIndex = 16;
            this.LightHeightTxtBox.Text = "2.7";
            // 
            // CeilingHeightTxtBox
            // 
            this.CeilingHeightTxtBox.Location = new System.Drawing.Point(146, 23);
            this.CeilingHeightTxtBox.Name = "CeilingHeightTxtBox";
            this.CeilingHeightTxtBox.Size = new System.Drawing.Size(100, 20);
            this.CeilingHeightTxtBox.TabIndex = 15;
            this.CeilingHeightTxtBox.Text = "2.7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Working Plane Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ceiling Height";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Light Height";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FloorFactorCombo);
            this.groupBox1.Controls.Add(this.CeilingFactorCombo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.WallFactorCombo);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 109);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reflectance/Reluctance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Floor Factor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ceiling Factor";
            // 
            // FloorFactorCombo
            // 
            this.FloorFactorCombo.FormattingEnabled = true;
            this.FloorFactorCombo.Items.AddRange(new object[] {
            "0.2",
            "0.0"});
            this.FloorFactorCombo.Location = new System.Drawing.Point(85, 77);
            this.FloorFactorCombo.Name = "FloorFactorCombo";
            this.FloorFactorCombo.Size = new System.Drawing.Size(121, 21);
            this.FloorFactorCombo.TabIndex = 11;
            this.FloorFactorCombo.Text = "0.2";
            // 
            // CeilingFactorCombo
            // 
            this.CeilingFactorCombo.FormattingEnabled = true;
            this.CeilingFactorCombo.Items.AddRange(new object[] {
            "0.7",
            "0.5",
            "0.3",
            "0.0"});
            this.CeilingFactorCombo.Location = new System.Drawing.Point(85, 23);
            this.CeilingFactorCombo.Name = "CeilingFactorCombo";
            this.CeilingFactorCombo.Size = new System.Drawing.Size(121, 21);
            this.CeilingFactorCombo.TabIndex = 7;
            this.CeilingFactorCombo.Text = "0.7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Wall Factor";
            // 
            // WallFactorCombo
            // 
            this.WallFactorCombo.FormattingEnabled = true;
            this.WallFactorCombo.Items.AddRange(new object[] {
            "0.5",
            "0.3",
            "0.1",
            "0.0"});
            this.WallFactorCombo.Location = new System.Drawing.Point(85, 50);
            this.WallFactorCombo.Name = "WallFactorCombo";
            this.WallFactorCombo.Size = new System.Drawing.Size(121, 21);
            this.WallFactorCombo.TabIndex = 9;
            this.WallFactorCombo.Text = "0.5";
            // 
            // CADBtn
            // 
            this.CADBtn.Location = new System.Drawing.Point(629, 662);
            this.CADBtn.Name = "CADBtn";
            this.CADBtn.Size = new System.Drawing.Size(98, 23);
            this.CADBtn.TabIndex = 2;
            this.CADBtn.Text = "Pick Polylines";
            this.CADBtn.UseVisualStyleBackColor = true;
            this.CADBtn.Click += new System.EventHandler(this.CADBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 697);
            this.Controls.Add(this.CADBtn);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lighting Calculator";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox WorkingPlaneHeightTxtBox;
        private System.Windows.Forms.TextBox LightHeightTxtBox;
        private System.Windows.Forms.TextBox CeilingHeightTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FloorFactorCombo;
        private System.Windows.Forms.ComboBox CeilingFactorCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WallFactorCombo;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button CADBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TargetLuxTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MaintenanceFactorTxtBox;
        private System.Windows.Forms.Label label4;
    }
}
namespace LightingCalculator
{
    partial class LightingOptions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AllCADBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ceilingObjId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CeilingNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FittingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumFittings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointLux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgLux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AllCADBtn);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 849);
            this.panel1.TabIndex = 3;
            // 
            // AllCADBtn
            // 
            this.AllCADBtn.AutoSize = true;
            this.AllCADBtn.Location = new System.Drawing.Point(15, 814);
            this.AllCADBtn.Name = "AllCADBtn";
            this.AllCADBtn.Size = new System.Drawing.Size(119, 23);
            this.AllCADBtn.TabIndex = 4;
            this.AllCADBtn.Text = "Add Selected to CAD";
            this.AllCADBtn.UseVisualStyleBackColor = true;
            this.AllCADBtn.Click += new System.EventHandler(this.AllCADBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 796);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculated Results";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ceilingObjId,
            this.CeilingNum,
            this.FittingName,
            this.NumFittings,
            this.PointLux,
            this.AvgLux,
            this.OptionSelected});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(755, 777);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ceilingObjId
            // 
            this.ceilingObjId.DataPropertyName = "ceilingObjId";
            this.ceilingObjId.HeaderText = "Object ID";
            this.ceilingObjId.Name = "ceilingObjId";
            this.ceilingObjId.ReadOnly = true;
            // 
            // CeilingNum
            // 
            this.CeilingNum.DataPropertyName = "CeilingNum";
            this.CeilingNum.HeaderText = "Ceiling Number";
            this.CeilingNum.Name = "CeilingNum";
            this.CeilingNum.ReadOnly = true;
            // 
            // FittingName
            // 
            this.FittingName.DataPropertyName = "FittingName";
            this.FittingName.HeaderText = "Fitting Name";
            this.FittingName.Name = "FittingName";
            this.FittingName.ReadOnly = true;
            // 
            // NumFittings
            // 
            this.NumFittings.DataPropertyName = "NumFittings";
            this.NumFittings.HeaderText = "# of Fittings";
            this.NumFittings.Name = "NumFittings";
            this.NumFittings.ReadOnly = true;
            // 
            // PointLux
            // 
            this.PointLux.DataPropertyName = "PointLux";
            this.PointLux.HeaderText = "Maximum Lux(at point)";
            this.PointLux.Name = "PointLux";
            this.PointLux.ReadOnly = true;
            // 
            // AvgLux
            // 
            this.AvgLux.DataPropertyName = "AvgLux";
            this.AvgLux.HeaderText = "Average Lux";
            this.AvgLux.Name = "AvgLux";
            this.AvgLux.ReadOnly = true;
            // 
            // OptionSelected
            // 
            this.OptionSelected.DataPropertyName = "OptionSelected";
            this.OptionSelected.HeaderText = "Selected";
            this.OptionSelected.Name = "OptionSelected";
            // 
            // LightingOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 849);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LightingOptions";
            this.Text = "Light Options";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AllCADBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ceilingObjId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CeilingNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn FittingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFittings;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointLux;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgLux;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OptionSelected;
    }
}
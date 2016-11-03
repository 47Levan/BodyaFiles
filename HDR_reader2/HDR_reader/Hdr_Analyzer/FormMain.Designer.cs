namespace Hdr_Analyzer
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.ButtonDir = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAnalogs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCounters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLimits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChange = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SaveNameToTxt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SaveCurrentRow = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select HDR Folder:";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Enabled = false;
            this.textBoxDir.Location = new System.Drawing.Point(10, 35);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(502, 20);
            this.textBoxDir.TabIndex = 1;
            // 
            // ButtonDir
            // 
            this.ButtonDir.Location = new System.Drawing.Point(513, 35);
            this.ButtonDir.Name = "ButtonDir";
            this.ButtonDir.Size = new System.Drawing.Size(24, 20);
            this.ButtonDir.TabIndex = 2;
            this.ButtonDir.Text = "...";
            this.ButtonDir.UseVisualStyleBackColor = true;
            this.ButtonDir.Click += new System.EventHandler(this.ButtonDir_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.dat";
            this.openFileDialog.Filter = "\"HDR files|*.dat|All files|*.*\"";
            this.openFileDialog.InitialDirectory = "D:\\Areva\\habdata50\\hdr\\recon";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFile,
            this.ColumnFrom,
            this.ColumnTo,
            this.ColumnAnalogs,
            this.ColumnPoints,
            this.ColumnCounters,
            this.ColumnLimits,
            this.ColumnChange,
            this.SaveNameToTxt,
            this.SaveCurrentRow});
            this.dataGridView.Location = new System.Drawing.Point(13, 76);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1180, 387);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // ColumnFile
            // 
            this.ColumnFile.HeaderText = "File Name";
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.Width = 220;
            // 
            // ColumnFrom
            // 
            this.ColumnFrom.HeaderText = "Date From";
            this.ColumnFrom.Name = "ColumnFrom";
            this.ColumnFrom.ReadOnly = true;
            this.ColumnFrom.Width = 140;
            // 
            // ColumnTo
            // 
            this.ColumnTo.HeaderText = "Date To";
            this.ColumnTo.Name = "ColumnTo";
            this.ColumnTo.ReadOnly = true;
            this.ColumnTo.Width = 140;
            // 
            // ColumnAnalogs
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnAnalogs.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnAnalogs.HeaderText = "Analogs";
            this.ColumnAnalogs.Name = "ColumnAnalogs";
            this.ColumnAnalogs.Width = 90;
            // 
            // ColumnPoints
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnPoints.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPoints.HeaderText = "Points";
            this.ColumnPoints.Name = "ColumnPoints";
            this.ColumnPoints.Width = 90;
            // 
            // ColumnCounters
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnCounters.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnCounters.HeaderText = "Counters";
            this.ColumnCounters.Name = "ColumnCounters";
            this.ColumnCounters.Width = 90;
            // 
            // ColumnLimits
            // 
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnLimits.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnLimits.HeaderText = "Limits";
            this.ColumnLimits.Name = "ColumnLimits";
            this.ColumnLimits.Width = 90;
            // 
            // ColumnChange
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.ColumnChange.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnChange.HeaderText = "Update";
            this.ColumnChange.Name = "ColumnChange";
            this.ColumnChange.ReadOnly = true;
            this.ColumnChange.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnChange.Text = "Change...";
            this.ColumnChange.Width = 80;
            // 
            // SaveNameToTxt
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.SaveNameToTxt.DefaultCellStyle = dataGridViewCellStyle6;
            this.SaveNameToTxt.HeaderText = "Save name to txt";
            this.SaveNameToTxt.Name = "SaveNameToTxt";
            this.SaveNameToTxt.Text = "Save...";
            this.SaveNameToTxt.ToolTipText = "Save name to txt";
            // 
            // SaveCurrentRow
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.SaveCurrentRow.DefaultCellStyle = dataGridViewCellStyle7;
            this.SaveCurrentRow.HeaderText = "Save current row";
            this.SaveCurrentRow.Name = "SaveCurrentRow";
            this.SaveCurrentRow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SaveCurrentRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SaveCurrentRow.Text = "Save...";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 475);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ButtonDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "HDR Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button ButtonDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAnalogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCounters;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLimits;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnChange;
        private System.Windows.Forms.DataGridViewButtonColumn SaveNameToTxt;
        private System.Windows.Forms.DataGridViewButtonColumn SaveCurrentRow;
    }
}


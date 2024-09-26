namespace ManagingHolidays
{
    partial class FormManagingHolidays
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManagingHolidays));
            tableLayoutPanel1 = new TableLayoutPanel();
            cb_Ano = new ComboBox();
            bt_NewYear = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(cb_Ano, 0, 0);
            tableLayoutPanel1.Controls.Add(bt_NewYear, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 32);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // cb_Ano
            // 
            cb_Ano.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_Ano.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Ano.FlatStyle = FlatStyle.Flat;
            cb_Ano.FormattingEnabled = true;
            cb_Ano.Location = new Point(3, 3);
            cb_Ano.Name = "cb_Ano";
            cb_Ano.Size = new Size(394, 23);
            cb_Ano.TabIndex = 1;
            cb_Ano.SelectedValueChanged += cb_Ano_SelectedValueChanged;
            // 
            // bt_NewYear
            // 
            bt_NewYear.Dock = DockStyle.Fill;
            bt_NewYear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt_NewYear.Location = new Point(403, 3);
            bt_NewYear.Name = "bt_NewYear";
            bt_NewYear.Size = new Size(394, 26);
            bt_NewYear.TabIndex = 2;
            bt_NewYear.Text = "+";
            bt_NewYear.UseVisualStyleBackColor = true;
            bt_NewYear.Click += bt_NewYear_Click;
            // 
            // FormManagingHolidays
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormManagingHolidays";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerir Calendario";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cb_Ano;
        private Button bt_NewYear;
    }
}
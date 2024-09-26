namespace ManagingHolidays
{
    partial class FormBuildNewYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuildNewYear));
            tableLayoutPanel1 = new TableLayoutPanel();
            bt_Aplicar = new Button();
            txt_year = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(bt_Aplicar, 2, 0);
            tableLayoutPanel1.Controls.Add(txt_year, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 21);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(444, 35);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // bt_Aplicar
            // 
            bt_Aplicar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bt_Aplicar.Location = new Point(357, 3);
            bt_Aplicar.Name = "bt_Aplicar";
            bt_Aplicar.Size = new Size(84, 29);
            bt_Aplicar.TabIndex = 1;
            bt_Aplicar.Text = "Aplicar";
            bt_Aplicar.UseVisualStyleBackColor = true;
            bt_Aplicar.Click += button1_Click;
            // 
            // txt_year
            // 
            txt_year.Dock = DockStyle.Fill;
            txt_year.Location = new Point(91, 3);
            txt_year.Multiline = true;
            txt_year.Name = "txt_year";
            txt_year.Size = new Size(260, 29);
            txt_year.TabIndex = 0;
            txt_year.KeyPress += txt_year_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 35);
            label1.TabIndex = 1;
            label1.Text = "Ano:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormBuildNewYear
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 82);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormBuildNewYear";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adicionar Ano";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txt_year;
        private Label label1;
        private Button bt_Aplicar;
    }
}
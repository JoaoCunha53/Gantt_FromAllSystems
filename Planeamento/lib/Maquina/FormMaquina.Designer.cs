namespace Maquina
{
    partial class FormMaquina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaquina));
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            txt_maquina = new TextBox();
            txt_caderno = new TextBox();
            bt_ok = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.89518F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.10481F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_maquina, 1, 1);
            tableLayoutPanel1.Controls.Add(txt_caderno, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(353, 61);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 30);
            label1.TabIndex = 1;
            label1.Text = "Caderno:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(95, 31);
            label2.TabIndex = 2;
            label2.Text = "Maquina:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_maquina
            // 
            txt_maquina.Dock = DockStyle.Fill;
            txt_maquina.Location = new Point(104, 33);
            txt_maquina.Multiline = true;
            txt_maquina.Name = "txt_maquina";
            txt_maquina.Size = new Size(246, 25);
            txt_maquina.TabIndex = 3;
            txt_maquina.KeyPress += txt_maquina_KeyPress;
            // 
            // txt_caderno
            // 
            txt_caderno.Location = new Point(104, 3);
            txt_caderno.Multiline = true;
            txt_caderno.Name = "txt_caderno";
            txt_caderno.ReadOnly = true;
            txt_caderno.Size = new Size(246, 24);
            txt_caderno.TabIndex = 4;
            txt_caderno.TextAlign = HorizontalAlignment.Center;
            // 
            // bt_ok
            // 
            bt_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_ok.Location = new Point(290, 79);
            bt_ok.Name = "bt_ok";
            bt_ok.Size = new Size(75, 23);
            bt_ok.TabIndex = 1;
            bt_ok.Text = "Aplicar";
            bt_ok.UseVisualStyleBackColor = true;
            bt_ok.Click += bt_ok_Click;
            // 
            // FormMaquina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 111);
            Controls.Add(bt_ok);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(393, 150);
            MinimizeBox = false;
            MinimumSize = new Size(393, 150);
            Name = "FormMaquina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMaquina";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TextBox txt_maquina;
        private Button bt_ok;
        private TextBox txt_caderno;
    }
}
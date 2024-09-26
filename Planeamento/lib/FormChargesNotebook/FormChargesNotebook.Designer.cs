namespace Planeamento.lib.FormChargesNotebook
{
    partial class FormChargesNotebook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChargesNotebook));
            cb_ChargesNotebook = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            bt_ok = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cb_ChargesNotebook
            // 
            cb_ChargesNotebook.Dock = DockStyle.Fill;
            cb_ChargesNotebook.FormattingEnabled = true;
            cb_ChargesNotebook.Location = new Point(85, 3);
            cb_ChargesNotebook.Name = "cb_ChargesNotebook";
            cb_ChargesNotebook.Size = new Size(229, 23);
            cb_ChargesNotebook.TabIndex = 0;
            cb_ChargesNotebook.KeyPress += cb_ChargesNotebook_KeyPress;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.17801F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.82199F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cb_ChargesNotebook, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 11);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(317, 31);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 31);
            label1.TabIndex = 0;
            label1.Text = "Caderno:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bt_ok
            // 
            bt_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_ok.Location = new Point(254, 51);
            bt_ok.Name = "bt_ok";
            bt_ok.Size = new Size(75, 23);
            bt_ok.TabIndex = 2;
            bt_ok.Text = "OK";
            bt_ok.UseVisualStyleBackColor = true;
            bt_ok.Click += bt_ok_Click;
            // 
            // FormChargesNotebook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 86);
            Controls.Add(bt_ok);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(357, 125);
            MinimizeBox = false;
            MinimumSize = new Size(357, 125);
            Name = "FormChargesNotebook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selecionar Caderno";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cb_ChargesNotebook;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button bt_ok;
    }
}
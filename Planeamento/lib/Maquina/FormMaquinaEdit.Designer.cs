namespace Maquina
{
    partial class FormMaquinaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaquinaEdit));
            tableLayoutPanel1 = new TableLayoutPanel();
            txt_desc = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txt_maquina = new TextBox();
            bt_ok = new Button();
            bt_Eliminar = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.89518F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.10482F));
            tableLayoutPanel1.Controls.Add(txt_desc, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_maquina, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.36232F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74.63768F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(353, 175);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_desc
            // 
            txt_desc.Dock = DockStyle.Fill;
            txt_desc.Location = new Point(104, 47);
            txt_desc.Multiline = true;
            txt_desc.Name = "txt_desc";
            txt_desc.Size = new Size(246, 125);
            txt_desc.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 44);
            label3.Name = "label3";
            label3.Size = new Size(95, 131);
            label3.TabIndex = 5;
            label3.Text = "Descrição:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 44);
            label2.TabIndex = 2;
            label2.Text = "Maquina:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_maquina
            // 
            txt_maquina.Dock = DockStyle.Fill;
            txt_maquina.Location = new Point(104, 3);
            txt_maquina.Multiline = true;
            txt_maquina.Name = "txt_maquina";
            txt_maquina.Size = new Size(246, 38);
            txt_maquina.TabIndex = 3;
            txt_maquina.KeyPress += txt_maquina_KeyPress;
            // 
            // bt_ok
            // 
            bt_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_ok.Location = new Point(290, 193);
            bt_ok.Name = "bt_ok";
            bt_ok.Size = new Size(75, 23);
            bt_ok.TabIndex = 1;
            bt_ok.Text = "Aplicar";
            bt_ok.UseVisualStyleBackColor = true;
            bt_ok.Click += bt_ok_Click;
            // 
            // bt_Eliminar
            // 
            bt_Eliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_Eliminar.Location = new Point(12, 193);
            bt_Eliminar.Name = "bt_Eliminar";
            bt_Eliminar.Size = new Size(75, 23);
            bt_Eliminar.TabIndex = 2;
            bt_Eliminar.Text = "Eliminar";
            bt_Eliminar.UseVisualStyleBackColor = true;
            bt_Eliminar.Click += bt_Eliminar_Click;
            // 
            // FormMaquinaEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 225);
            Controls.Add(bt_Eliminar);
            Controls.Add(bt_ok);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(393, 217);
            Name = "FormMaquinaEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private TextBox txt_maquina;
        private Button bt_ok;
        private Button bt_Eliminar;
        private TextBox txt_desc;
        private Label label3;
    }
}
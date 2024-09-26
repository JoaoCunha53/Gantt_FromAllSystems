namespace ManagingHolidays
{
    partial class FormEditHolidays
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditHolidays));
            tableLayoutPanel1 = new TableLayoutPanel();
            txt_mes = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label2 = new Label();
            txt_Name = new TextBox();
            txt_Descricao = new TextBox();
            lb_decricao = new Label();
            dt_date = new DateTimePicker();
            label6 = new Label();
            bt_cor = new Button();
            lb_cor = new Label();
            bt_Editar = new Button();
            bt_eliminar = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.96721F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.03279F));
            tableLayoutPanel1.Controls.Add(txt_mes, 1, 0);
            tableLayoutPanel1.Controls.Add(label7, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_Name, 1, 1);
            tableLayoutPanel1.Controls.Add(txt_Descricao, 1, 3);
            tableLayoutPanel1.Controls.Add(lb_decricao, 0, 3);
            tableLayoutPanel1.Controls.Add(dt_date, 1, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(bt_cor, 2, 4);
            tableLayoutPanel1.Controls.Add(lb_cor, 1, 4);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.5970316F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.2582779F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.2649F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.6423836F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.7617035F));
            tableLayoutPanel1.Size = new Size(342, 302);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_mes
            // 
            tableLayoutPanel1.SetColumnSpan(txt_mes, 2);
            txt_mes.Dock = DockStyle.Fill;
            txt_mes.Location = new Point(97, 3);
            txt_mes.Multiline = true;
            txt_mes.Name = "txt_mes";
            txt_mes.ReadOnly = true;
            txt_mes.Size = new Size(242, 29);
            txt_mes.TabIndex = 22;
            txt_mes.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(88, 35);
            label7.TabIndex = 12;
            label7.Text = "Mês:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 69);
            label4.Name = "label4";
            label4.Size = new Size(88, 31);
            label4.TabIndex = 3;
            label4.Text = "Data:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(88, 34);
            label2.TabIndex = 1;
            label2.Text = "Nome:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_Name
            // 
            tableLayoutPanel1.SetColumnSpan(txt_Name, 2);
            txt_Name.Dock = DockStyle.Fill;
            txt_Name.Location = new Point(97, 38);
            txt_Name.Multiline = true;
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(242, 28);
            txt_Name.TabIndex = 7;
            // 
            // txt_Descricao
            // 
            tableLayoutPanel1.SetColumnSpan(txt_Descricao, 2);
            txt_Descricao.Dock = DockStyle.Fill;
            txt_Descricao.Location = new Point(97, 103);
            txt_Descricao.Multiline = true;
            txt_Descricao.Name = "txt_Descricao";
            txt_Descricao.Size = new Size(242, 156);
            txt_Descricao.TabIndex = 11;
            // 
            // lb_decricao
            // 
            lb_decricao.AutoSize = true;
            lb_decricao.Dock = DockStyle.Fill;
            lb_decricao.Location = new Point(3, 100);
            lb_decricao.Name = "lb_decricao";
            lb_decricao.Size = new Size(88, 162);
            lb_decricao.TabIndex = 5;
            lb_decricao.Text = "Descrição:";
            lb_decricao.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dt_date
            // 
            tableLayoutPanel1.SetColumnSpan(dt_date, 2);
            dt_date.Dock = DockStyle.Bottom;
            dt_date.Enabled = false;
            dt_date.Location = new Point(97, 74);
            dt_date.Name = "dt_date";
            dt_date.Size = new Size(242, 23);
            dt_date.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 262);
            label6.Name = "label6";
            label6.Size = new Size(88, 40);
            label6.TabIndex = 19;
            label6.Text = "Cor:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bt_cor
            // 
            bt_cor.Location = new Point(143, 265);
            bt_cor.Name = "bt_cor";
            bt_cor.Size = new Size(75, 23);
            bt_cor.TabIndex = 20;
            bt_cor.Text = "Selecionar  Cor";
            bt_cor.UseVisualStyleBackColor = true;
            bt_cor.Click += bt_cor_Click;
            // 
            // lb_cor
            // 
            lb_cor.AutoSize = true;
            lb_cor.BorderStyle = BorderStyle.FixedSingle;
            lb_cor.Dock = DockStyle.Fill;
            lb_cor.Location = new Point(97, 262);
            lb_cor.Name = "lb_cor";
            lb_cor.Size = new Size(40, 40);
            lb_cor.TabIndex = 21;
            // 
            // bt_Editar
            // 
            bt_Editar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_Editar.Location = new Point(253, 320);
            bt_Editar.Name = "bt_Editar";
            bt_Editar.Size = new Size(101, 25);
            bt_Editar.TabIndex = 18;
            bt_Editar.Text = "Aplicar";
            bt_Editar.UseVisualStyleBackColor = true;
            bt_Editar.Click += button1_Click;
            // 
            // bt_eliminar
            // 
            bt_eliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_eliminar.Location = new Point(12, 321);
            bt_eliminar.Name = "bt_eliminar";
            bt_eliminar.Size = new Size(101, 25);
            bt_eliminar.TabIndex = 19;
            bt_eliminar.Text = "Eliminar";
            bt_eliminar.UseVisualStyleBackColor = true;
            bt_eliminar.Click += bt_eliminar_Click;
            // 
            // FormEditHolidays
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 357);
            Controls.Add(bt_eliminar);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(bt_Editar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(382, 396);
            MinimizeBox = false;
            MinimumSize = new Size(382, 396);
            Name = "FormEditHolidays";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar";
            KeyDown += OnKeyDownHandler;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lb_decricao;
        private Label label4;
        private Label label2;
        private TextBox txt_Name;
        private TextBox txt_Descricao;
        private Label label7;
        private DateTimePicker dt_date;
        private Button bt_Editar;
        private Label label6;
        private Button bt_cor;
        private Label lb_cor;
        private Button bt_eliminar;
        private TextBox txt_mes;
    }
}
namespace Planeamento.lib.FromProcess
{
    partial class FormNewTimeBlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTimeBlock));
            bt_Concluir = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txt_Name = new TextBox();
            txt_Descricao = new TextBox();
            lb_decricao = new Label();
            label1 = new Label();
            dt_StartDate = new DateTimePicker();
            dt_EndDate = new DateTimePicker();
            dt_StartHours = new DateTimePicker();
            dt_EndHours = new DateTimePicker();
            cb_maquina = new ComboBox();
            label6 = new Label();
            bt_cor = new Button();
            lb_cor = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // bt_Concluir
            // 
            bt_Concluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_Concluir.Location = new Point(253, 371);
            bt_Concluir.Name = "bt_Concluir";
            bt_Concluir.Size = new Size(101, 25);
            bt_Concluir.TabIndex = 18;
            bt_Concluir.Text = "Aplicar";
            bt_Concluir.UseVisualStyleBackColor = true;
            bt_Concluir.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.96721F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.03279F));
            tableLayoutPanel1.Controls.Add(label7, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_Name, 1, 1);
            tableLayoutPanel1.Controls.Add(txt_Descricao, 1, 6);
            tableLayoutPanel1.Controls.Add(lb_decricao, 0, 6);
            tableLayoutPanel1.Controls.Add(label1, 0, 5);
            tableLayoutPanel1.Controls.Add(dt_StartDate, 1, 2);
            tableLayoutPanel1.Controls.Add(dt_EndDate, 1, 3);
            tableLayoutPanel1.Controls.Add(dt_StartHours, 1, 4);
            tableLayoutPanel1.Controls.Add(dt_EndHours, 1, 5);
            tableLayoutPanel1.Controls.Add(cb_maquina, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 7);
            tableLayoutPanel1.Controls.Add(bt_cor, 2, 7);
            tableLayoutPanel1.Controls.Add(lb_cor, 1, 7);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.546802F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.546793F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.546793F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.546793F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.546796F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.548508F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40.1709023F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.546613F));
            tableLayoutPanel1.Size = new Size(342, 349);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(88, 29);
            label7.TabIndex = 12;
            label7.Text = "Maquina:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 116);
            label5.Name = "label5";
            label5.Size = new Size(88, 29);
            label5.TabIndex = 4;
            label5.Text = "Hora de Inicio:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 87);
            label4.Name = "label4";
            label4.Size = new Size(88, 29);
            label4.TabIndex = 3;
            label4.Text = "Data de Fim:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 58);
            label3.Name = "label3";
            label3.Size = new Size(88, 29);
            label3.TabIndex = 2;
            label3.Text = "Data de Inicio:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(88, 29);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_Name
            // 
            tableLayoutPanel1.SetColumnSpan(txt_Name, 2);
            txt_Name.Dock = DockStyle.Fill;
            txt_Name.Location = new Point(97, 32);
            txt_Name.Multiline = true;
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(242, 23);
            txt_Name.TabIndex = 7;
            // 
            // txt_Descricao
            // 
            txt_Descricao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txt_Descricao, 2);
            txt_Descricao.Location = new Point(97, 177);
            txt_Descricao.Multiline = true;
            txt_Descricao.Name = "txt_Descricao";
            txt_Descricao.Size = new Size(242, 134);
            txt_Descricao.TabIndex = 11;
            // 
            // lb_decricao
            // 
            lb_decricao.AutoSize = true;
            lb_decricao.Dock = DockStyle.Fill;
            lb_decricao.Location = new Point(3, 174);
            lb_decricao.Name = "lb_decricao";
            lb_decricao.Size = new Size(88, 140);
            lb_decricao.TabIndex = 5;
            lb_decricao.Text = "Descrição:";
            lb_decricao.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 145);
            label1.Name = "label1";
            label1.Size = new Size(88, 29);
            label1.TabIndex = 0;
            label1.Text = "Hora de Fim:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dt_StartDate
            // 
            tableLayoutPanel1.SetColumnSpan(dt_StartDate, 2);
            dt_StartDate.Dock = DockStyle.Fill;
            dt_StartDate.Location = new Point(97, 61);
            dt_StartDate.Name = "dt_StartDate";
            dt_StartDate.Size = new Size(242, 23);
            dt_StartDate.TabIndex = 14;
            // 
            // dt_EndDate
            // 
            tableLayoutPanel1.SetColumnSpan(dt_EndDate, 2);
            dt_EndDate.Dock = DockStyle.Fill;
            dt_EndDate.Location = new Point(97, 90);
            dt_EndDate.Name = "dt_EndDate";
            dt_EndDate.Size = new Size(242, 23);
            dt_EndDate.TabIndex = 15;
            // 
            // dt_StartHours
            // 
            dt_StartHours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(dt_StartHours, 2);
            dt_StartHours.Format = DateTimePickerFormat.Time;
            dt_StartHours.Location = new Point(97, 119);
            dt_StartHours.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            dt_StartHours.Name = "dt_StartHours";
            dt_StartHours.ShowUpDown = true;
            dt_StartHours.Size = new Size(242, 23);
            dt_StartHours.TabIndex = 16;
            dt_StartHours.Value = new DateTime(2024, 9, 13, 0, 0, 0, 0);
            // 
            // dt_EndHours
            // 
            dt_EndHours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(dt_EndHours, 2);
            dt_EndHours.Format = DateTimePickerFormat.Time;
            dt_EndHours.Location = new Point(97, 148);
            dt_EndHours.Name = "dt_EndHours";
            dt_EndHours.ShowUpDown = true;
            dt_EndHours.Size = new Size(242, 23);
            dt_EndHours.TabIndex = 17;
            dt_EndHours.Value = new DateTime(2024, 9, 13, 1, 0, 0, 0);
            // 
            // cb_maquina
            // 
            tableLayoutPanel1.SetColumnSpan(cb_maquina, 2);
            cb_maquina.Dock = DockStyle.Fill;
            cb_maquina.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_maquina.FormattingEnabled = true;
            cb_maquina.Location = new Point(97, 3);
            cb_maquina.Name = "cb_maquina";
            cb_maquina.Size = new Size(242, 23);
            cb_maquina.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 314);
            label6.Name = "label6";
            label6.Size = new Size(88, 35);
            label6.TabIndex = 19;
            label6.Text = "Cor:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bt_cor
            // 
            bt_cor.Dock = DockStyle.Fill;
            bt_cor.Location = new Point(143, 317);
            bt_cor.Name = "bt_cor";
            bt_cor.Size = new Size(196, 29);
            bt_cor.TabIndex = 20;
            bt_cor.Text = "Selecionar  Cor";
            bt_cor.UseVisualStyleBackColor = true;
            bt_cor.Click += bt_cor_Click_1;
            // 
            // lb_cor
            // 
            lb_cor.AutoSize = true;
            lb_cor.BorderStyle = BorderStyle.FixedSingle;
            lb_cor.Dock = DockStyle.Fill;
            lb_cor.Location = new Point(97, 314);
            lb_cor.Name = "lb_cor";
            lb_cor.Size = new Size(40, 35);
            lb_cor.TabIndex = 21;
            // 
            // FormNewTimeBlock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 408);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(bt_Concluir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(382, 447);
            MinimumSize = new Size(382, 447);
            Name = "FormNewTimeBlock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novo Processo";
            KeyDown += OnKeyDownHandler;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button bt_Concluir;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txt_Name;
        private TextBox txt_Descricao;
        private Label lb_decricao;
        private Label label1;
        private DateTimePicker dt_StartDate;
        private DateTimePicker dt_EndDate;
        private DateTimePicker dt_StartHours;
        private DateTimePicker dt_EndHours;
        private ComboBox cb_maquina;
        private Label label6;
        private Button bt_cor;
        private Label lb_cor;
    }
}
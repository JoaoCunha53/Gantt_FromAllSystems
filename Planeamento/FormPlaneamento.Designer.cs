using Calendar;
using System.Security.Cryptography;

namespace Planeamento
{
    partial class FormPlaneamento
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlaneamento));
            tableLayoutPanel1 = new TableLayoutPanel();
            cb_Ano = new ComboBox();
            cb_Semana = new ComboBox();
            menuStrip1 = new MenuStrip();
            setorToolStripMenuItem = new ToolStripMenuItem();
            novoSetorToolStripMenuItem = new ToolStripMenuItem();
            selecionarSetorToolStripMenuItem = new ToolStripMenuItem();
            adicionarMaquinaToolStripMenuItem = new ToolStripMenuItem();
            adicionarProcessoToolStripMenuItem = new ToolStripMenuItem();
            ferramentasToolStripMenuItem = new ToolStripMenuItem();
            gerirCalToolStripMenuItem = new ToolStripMenuItem();
            lb_ChargesNotebook = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlDark;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(cb_Ano, 0, 0);
            tableLayoutPanel1.Controls.Add(cb_Semana, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 32);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // cb_Ano
            // 
            cb_Ano.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_Ano.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Ano.FlatStyle = FlatStyle.Flat;
            cb_Ano.FormattingEnabled = true;
            cb_Ano.Location = new Point(3, 3);
            cb_Ano.Name = "cb_Ano";
            cb_Ano.Size = new Size(194, 23);
            cb_Ano.TabIndex = 1;
            // 
            // cb_Semana
            // 
            cb_Semana.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_Semana.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Semana.FlatStyle = FlatStyle.Flat;
            cb_Semana.FormattingEnabled = true;
            cb_Semana.Location = new Point(203, 3);
            cb_Semana.Name = "cb_Semana";
            cb_Semana.Size = new Size(594, 23);
            cb_Semana.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { setorToolStripMenuItem, ferramentasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // setorToolStripMenuItem
            // 
            setorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoSetorToolStripMenuItem, selecionarSetorToolStripMenuItem, adicionarMaquinaToolStripMenuItem, adicionarProcessoToolStripMenuItem });
            setorToolStripMenuItem.Name = "setorToolStripMenuItem";
            setorToolStripMenuItem.Size = new Size(50, 20);
            setorToolStripMenuItem.Text = "Menu";
            setorToolStripMenuItem.Click += setorToolStripMenuItem_Click;
            // 
            // novoSetorToolStripMenuItem
            // 
            novoSetorToolStripMenuItem.Name = "novoSetorToolStripMenuItem";
            novoSetorToolStripMenuItem.ShortcutKeys = Keys.F1;
            novoSetorToolStripMenuItem.Size = new Size(194, 22);
            novoSetorToolStripMenuItem.Text = "Novo Setor";
            // 
            // selecionarSetorToolStripMenuItem
            // 
            selecionarSetorToolStripMenuItem.Name = "selecionarSetorToolStripMenuItem";
            selecionarSetorToolStripMenuItem.ShortcutKeys = Keys.F2;
            selecionarSetorToolStripMenuItem.Size = new Size(194, 22);
            selecionarSetorToolStripMenuItem.Text = "Selecionar Setor";
            selecionarSetorToolStripMenuItem.Click += selecionarSetorToolStripMenuItem_Click;
            // 
            // adicionarMaquinaToolStripMenuItem
            // 
            adicionarMaquinaToolStripMenuItem.Enabled = false;
            adicionarMaquinaToolStripMenuItem.Name = "adicionarMaquinaToolStripMenuItem";
            adicionarMaquinaToolStripMenuItem.ShortcutKeys = Keys.F3;
            adicionarMaquinaToolStripMenuItem.Size = new Size(194, 22);
            adicionarMaquinaToolStripMenuItem.Text = "Adicionar Maquina";
            adicionarMaquinaToolStripMenuItem.Click += adicionarMaquinaToolStripMenuItem_Click;
            // 
            // adicionarProcessoToolStripMenuItem
            // 
            adicionarProcessoToolStripMenuItem.Enabled = false;
            adicionarProcessoToolStripMenuItem.Name = "adicionarProcessoToolStripMenuItem";
            adicionarProcessoToolStripMenuItem.ShortcutKeys = Keys.F4;
            adicionarProcessoToolStripMenuItem.Size = new Size(194, 22);
            adicionarProcessoToolStripMenuItem.Text = "Adicionar Processo";
            adicionarProcessoToolStripMenuItem.Click += adicionarProcessoToolStripMenuItem_Click;
            // 
            // ferramentasToolStripMenuItem
            // 
            ferramentasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gerirCalToolStripMenuItem });
            ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            ferramentasToolStripMenuItem.Size = new Size(84, 20);
            ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // gerirCalToolStripMenuItem
            // 
            gerirCalToolStripMenuItem.Name = "gerirCalToolStripMenuItem";
            gerirCalToolStripMenuItem.ShortcutKeys = Keys.F5;
            gerirCalToolStripMenuItem.Size = new Size(180, 22);
            gerirCalToolStripMenuItem.Text = "Gerir Calendario";
            gerirCalToolStripMenuItem.Click += gerirFolgasToolStripMenuItem_Click;
            // 
            // lb_ChargesNotebook
            // 
            lb_ChargesNotebook.AutoSize = true;
            lb_ChargesNotebook.Dock = DockStyle.Fill;
            lb_ChargesNotebook.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_ChargesNotebook.ForeColor = Color.Black;
            lb_ChargesNotebook.Location = new Point(3, 0);
            lb_ChargesNotebook.Name = "lb_ChargesNotebook";
            lb_ChargesNotebook.Size = new Size(794, 28);
            lb_ChargesNotebook.TabIndex = 1;
            lb_ChargesNotebook.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.ControlDark;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(lb_ChargesNotebook, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 56);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(800, 28);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // FormPlaneamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "FormPlaneamento";
            Text = "Gestão de Planeamento";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddAno()
        {
            cb_Ano.Items.Clear();
            SQL sql = new SQL();
            foreach (int year in sql.GetYear())
            {
                cb_Ano.Items.Add(year);
                cb_Ano.SelectedIndex = 0;
            }
        }

        private void AdicionarDiasUteisNaComboBox(int anoSelecionado)
        {
            // Limpa a ComboBox antes de adicionar novos itens
            cb_Semana.Items.Clear();
            string dayMF = "";
            DateTime dateMonday = new DateTime(0001, 01, 01);
            DateTime dateFriday = new DateTime(9999, 12, 31);
            int index = 0; 
            // Loop para percorrer todos os dias do ano
            for (int mes = 1; mes <= 12; mes++)
            {
                // Obtém o número de dias no mês (leva em conta anos bissextos)
                int diasNoMes = DateTime.DaysInMonth(anoSelecionado, mes);


                for (int dia = 1; dia <= diasNoMes; dia++)
                {
                    try
                    {
                        DateTime data = new DateTime(anoSelecionado, mes, dia);
                        DateTime dataAtual = DateTime.Now;

                        if (data.DayOfWeek == DayOfWeek.Monday)
                        {
                             dayMF = data.ToString("dd/MM/yyyy") + " - ";
                             dateMonday = data;
                        }

                        if (data.DayOfWeek == DayOfWeek.Friday)
                        {
                                dayMF = dayMF + data.ToString("dd/MM/yyyy");
                                cb_Semana.Items.Add(dayMF);
                                dateFriday = data;
                        }

                        // Adicionar a primeira semana do ano
                        if (dia == 1 && mes == 1 && data.DayOfWeek != DayOfWeek.Monday)
                        {
                            do
                            {
                                data = data.AddDays(-1);
                            } while (data.DayOfWeek != DayOfWeek.Monday);
                            dayMF = data.ToString("dd/MM/yyyy") + " - ";
                            dateMonday = data;
                        }

                        // Adicionar a ultima semana do ano
                        if (dia == diasNoMes && mes == 12 && data.DayOfWeek != DayOfWeek.Friday)
                        {
                            do
                            {
                                data = data.AddDays(1);
                            } while (data.DayOfWeek != DayOfWeek.Friday);
                            dayMF = dayMF + data.ToString("dd/MM/yyyy");
                            cb_Semana.Items.Add(dayMF);
                            dateFriday = data;
                        }

                        if (dataAtual.Date >= dateMonday.Date && dataAtual.Date <= dateFriday.Date)
                        {
                            index = cb_Semana.Items.Count;
                        }


                    }
                    catch { }
                }
            }

            // Define o primeiro item como o item selecionado (opcional)
            if (cb_Semana.Items.Count > 0)
            {
                cb_Semana.SelectedIndex = index;
                if (index > 0)
                {
                    cb_Semana.SelectedIndex = index - 1;
                }
            }

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cb_Ano;
        private ComboBox cb_Semana;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem setorToolStripMenuItem;
        private ToolStripMenuItem novoSetorToolStripMenuItem;
        private ToolStripMenuItem selecionarSetorToolStripMenuItem;
        private ToolStripMenuItem adicionarMaquinaToolStripMenuItem;
        private ToolStripMenuItem adicionarProcessoToolStripMenuItem;
        private Label lb_ChargesNotebook;
        private TableLayoutPanel tableLayoutPanel2;
        private ToolStripMenuItem ferramentasToolStripMenuItem;
        private ToolStripMenuItem gerirCalToolStripMenuItem;
    }
}

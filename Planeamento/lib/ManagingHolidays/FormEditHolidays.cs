using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ManagingHolidays
{
    public partial class FormEditHolidays : Form
    {
        private Row row;
        private TimeBlock timeBlock;
        private ColorDialog colorDialog;
        public FormEditHolidays(Row row, TimeBlock timeBlock)
        {
            InitializeComponent();
            this.row = row;
            this.timeBlock = timeBlock;
           
            txt_mes.Text = row.Text;
            txt_Name.Text = timeBlock.Text;
            txt_Descricao.Text = timeBlock.Description;
            dt_date.Value = timeBlock.Date;

            this.colorDialog = new ColorDialog();
            colorDialog.Color = timeBlock.Color;
            lb_cor.BackColor = timeBlock.Color;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Exibe a caixa de mensagem com botões "OK" e "Cancelar"
                DialogResult result = MessageBox.Show("Deseja concluir a operação?", "Confirmação", MessageBoxButtons.OKCancel);

                // Verifica qual botão foi clicado
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Você clicou em Concluir (OK)");
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Você clicou em Cancelar");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (VerificarDados())
            {
                // Exibe a caixa de mensagem com botões "OK" e "Cancelar"
                DialogResult result = MessageBox.Show("Deseja concluir a operação?", "Confirmação", MessageBoxButtons.OKCancel);

                // Verifica qual botão foi clicado
                if (result == DialogResult.OK)
                {
                    timeBlock.Text = txt_Name.Text;
                    timeBlock.Description = txt_Descricao.Text;
                    timeBlock.Color = colorDialog.Color;
                    string color = timeBlock.Color.R + "," + timeBlock.Color.G + "," + timeBlock.Color.B;   

                    timeBlock.Description = txt_Descricao.Text;

                    SQL sql = new SQL();
                    sql.UpdateTimeBlock(timeBlock.Id, timeBlock.Text, timeBlock.Description, timeBlock.Date, true, timeBlock.Clickable, timeBlock.IsVisible, color);

                    this.Hide();
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Você clicou em Cancelar");
                }

            }
        }

        private void bt_cor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            lb_cor.BackColor = colorDialog.Color;
        }

        private bool VerificarDados()
        {
            if (txt_Name.Text == "")
            {
                MessageBox.Show("É necessario inserir o nome!", "Aviso");
                return false;
            }
            return true;
        }

        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Deseja eliminar o processo {timeBlock.Text}?", "Confirmação", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                SQL sql = new SQL();
                sql.UpdateTimeBlock(timeBlock.Id, "", timeBlock.Description, timeBlock.Date, false, timeBlock.Clickable, timeBlock.IsVisible, "255,255,255");
                timeBlock.Text = "";
                timeBlock.Description = "";
                timeBlock.Color = Color.White;
                this.Hide();
            }

        }

      
    }
}

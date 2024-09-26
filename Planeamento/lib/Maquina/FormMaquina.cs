using GanttChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maquina
{
    public partial class FormMaquina : Form
    {
        private Chart ganttChart;
        public FormMaquina(Chart ganttChart)
        {
            InitializeComponent();
            this.ganttChart = ganttChart;
            txt_caderno.Text = ganttChart.Text;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (VerificarDados())
            {
                // Exibe a caixa de mensagem com botões "OK" e "Cancelar"
                DialogResult result = MessageBox.Show("Deseja concluir a operação?", "Confirmação", MessageBoxButtons.OKCancel);

                // Verifica qual botão foi clicado
                if (result == DialogResult.OK)
                {
                    SQL sql = new SQL();
                    sql.InsertRow(true, txt_maquina.Text, ganttChart.Id);
                    this.Hide();

                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Você clicou em Cancelar");
                }

            }
        }

        private bool VerificarDados()
        {
            if (txt_caderno.Text == "")
            {
                MessageBox.Show("É necessário inserir o Caderno Encargos! Não foi possível criar um registo.", "Aviso");
                return false;
            }
            if (txt_maquina.Text == "")
            {
                MessageBox.Show("É necessário inserir a maquina! Não foi possível criar um registo.", "Aviso");
                return false;
            }

            foreach (Row row in ganttChart.Rows)
            {
                if (row.Text == txt_maquina.Text)
                {
                    MessageBox.Show("A maquina existe! Não foi possível criar um registo.", "Aviso");
                    return false;
                }
            }

            return true;
        }

        private void txt_maquina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveData();
            }
        }
    }
}

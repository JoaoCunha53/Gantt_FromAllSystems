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
    public partial class FormMaquinaEdit : Form
    {
        List<ChargesNotebook> listChargesNotebook;
        private Row row;
        public FormMaquinaEdit(Row row)
        {
            InitializeComponent();
            this.row = row;
            txt_maquina.Text = row.Text;
            txt_desc.Text = "";
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
                    sql.UpdateRow(true, txt_maquina.Text, row.idChargesBook, row.id, txt_desc.Text);
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
            if (txt_maquina.Text == "")
            {
                MessageBox.Show("É necessário inserir a maquina! Não foi possível criar um registo.", "Aviso");
                return false;
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

        private void bt_Eliminar_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            sql.UpdateRow(false, txt_maquina.Text, row.idChargesBook, row.id, txt_desc.Text);
            row.IsVisible = false;
            this.Close();
        }
    }
}

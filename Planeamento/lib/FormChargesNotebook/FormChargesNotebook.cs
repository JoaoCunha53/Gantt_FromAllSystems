using GanttChart;
using Planeamento.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planeamento.lib.FormChargesNotebook
{
    public partial class FormChargesNotebook : Form
    {
        List<ChargesNotebook> listChargesNotebook;
        private FormPlaneamento _formPlaneamento;
        public FormChargesNotebook(FormPlaneamento formPlaneamento)
        {
            _formPlaneamento = formPlaneamento;
            InitializeComponent();
            SQL database = new SQL();
            listChargesNotebook = database.GetChargesNotebook();

            foreach (ChargesNotebook cN in listChargesNotebook)
            {
                cb_ChargesNotebook.Items.Add(cN.Name);
            }

        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            int id = listChargesNotebook.FindIndex(c => c.Name.Equals(cb_ChargesNotebook.Text));

            if (id != -1) // If a valid index is found
            {
                // Set the ganttChart properties
                _formPlaneamento.ganttChart.Id = listChargesNotebook[id].id;
                _formPlaneamento.ganttChart.Text = listChargesNotebook[id].Name;

                // Hide the current form
                this.Hide();
            }
            else
            {
                // Handle the case when the selected item does not exist
                MessageBox.Show("O item selecionado não existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_ChargesNotebook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveData();
            }
        }
    }
}

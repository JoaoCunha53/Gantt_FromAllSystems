
using GanttChart;
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

namespace Planeamento.lib.FromProcess
{
    public partial class FormNewTimeBlock : Form
    {
        private List<Row> rows;
        public ColorDialog colorDialog;
        public FormNewTimeBlock(List<Row> rows)
        {
            InitializeComponent();

            this.Name = "Novo Processo";
            this.rows = rows;
            RandomColor();

            foreach (Row row in rows)
            {
                cb_maquina.Items.Add(row.Text);
            }

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
                    DateTime startTime = DateTime.Parse(dt_StartDate.Text).AddHours(dt_StartHours.Value.Hour).AddMinutes(dt_StartHours.Value.Minute);
                    DateTime endTime = DateTime.Parse(dt_EndDate.Text).AddHours(dt_EndHours.Value.Hour).AddMinutes(dt_EndHours.Value.Minute);

                    int rowIndex = rows.FindIndex(r => r.Text.Equals(cb_maquina.Text));
                    int rowId = rows[rowIndex].id;
                    string rowName = cb_maquina.Text;
                    int r = colorDialog.Color.R;
                    int g = colorDialog.Color.G;
                    int b = colorDialog.Color.B;
                    string TimeBlockText = txt_Name.Text;
                    string rgbConcat = Convert.ToString(r) + "," + Convert.ToString(g) + "," + Convert.ToString(b);
                    string description = txt_Descricao.Text;

                    SQL sql = new SQL();
                    int idTimeBlock = sql.InsertTimeBlock(TimeBlockText, description, startTime, endTime, false, true, true, rowId, rgbConcat);
                    rows[rowIndex].TimeBlocks.Add(new TimeBlock(idTimeBlock, TimeBlockText, description, startTime, endTime) { Color = Color.FromArgb(r,g,b)});

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
            DateTime startTime = DateTime.Parse(dt_StartDate.Text).AddHours(dt_StartHours.Value.Hour).AddMinutes(dt_StartHours.Value.Minute);
            DateTime endTime = DateTime.Parse(dt_EndDate.Text).AddHours(dt_EndHours.Value.Hour).AddMinutes(dt_EndHours.Value.Minute);

            if (cb_maquina.SelectedIndex == -1)
            {
                MessageBox.Show("É necessario inserir a maquina!", "Aviso");
                return false;
            }
            if (txt_Name.Text == "")
            {
                MessageBox.Show("É necessario inserir o nome!", "Aviso");
                return false;
            }

            int index = rows.FindIndex(r => r.Text.Equals(cb_maquina.Text));
            foreach (TimeBlock timeBlock in rows[index].TimeBlocks)
                {
                    if (startTime >= timeBlock.StartTime && startTime <= timeBlock.EndTime || endTime >= timeBlock.StartTime && endTime <= timeBlock.EndTime)
                    {
                        MessageBox.Show($"Já existe uma operação entre as datas selecionados!\n\nMaquina:{rows[index].Text}\nProcesso: {timeBlock.Text}\nTempo: {timeBlock.StartTime} - {timeBlock.EndTime}", "Aviso");
                        return false;
                    }
                }

            return true;
        }

        private void bt_cor_Click_1(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            lb_cor.BackColor = colorDialog.Color;
        }

        private void RandomColor()
        {
            // Criar um gerador de números aleatórios
            Random random = new Random();

            // Gerar valores aleatórios para os componentes RGB
            int r = random.Next(0, 256); // Vermelho (0-255)
            int g = random.Next(0, 256); // Verde (0-255)
            int b = random.Next(0, 256); // Azul (0-255)

            // Atribuir a cor aleatória ao colorDialog
            colorDialog = new ColorDialog();
            colorDialog.Color = Color.FromArgb(r, g, b);

            // Definir o fundo do lb_cor com a cor gerada
            lb_cor.BackColor = colorDialog.Color;
        }
    }
}

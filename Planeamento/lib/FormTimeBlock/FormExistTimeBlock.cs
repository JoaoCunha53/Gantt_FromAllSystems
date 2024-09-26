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
using static System.Net.Mime.MediaTypeNames;

namespace Planeamento.lib.FromProcess
{
    public partial class FormExistTimeBlock : Form
    {
        private List<Row> rows;
        private TimeBlock timeBlock;
        private ColorDialog colorDialog;
        private int rowIndex;
        private int timeBlockIndex;
        public FormExistTimeBlock(List<Row> rows, TimeBlock timeBlock, string maquina,int rowIndex)
        {
            InitializeComponent();

            foreach (Row row in rows)
            {
                cb_maquina.Items.Add(row.Text);
            }

            this.rowIndex = rowIndex;
            this.Name = $"Processo {timeBlock.Text}";
            this.timeBlock = timeBlock;
            this.rows = rows;
            timeBlockIndex = rows[rowIndex].TimeBlocks.FindIndex(t => t.id.Equals(timeBlock.id));
            cb_maquina.Text = maquina;
            txt_Name.Text = timeBlock.Text;
            dt_StartDate.Text = timeBlock.StartTime.ToString("dd/MM/yyyy");
            dt_EndDate.Text = timeBlock.EndTime.ToString("dd/MM/yyyy");
            dt_StartHours.Text = timeBlock.StartTime.ToString("HH:mm");
            dt_EndHours.Text = timeBlock.EndTime.ToString("HH:mm");
            txt_Descricao.Text = timeBlock.description;
            
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
                    rows[rowIndex].TimeBlocks.Remove(timeBlock);
                    timeBlock.Text = txt_Name.Text;
                    timeBlock.description = txt_Descricao.Text;
                    timeBlock.StartTime = DateTime.Parse(dt_StartDate.Text).AddHours(dt_StartHours.Value.Hour).AddMinutes(dt_StartHours.Value.Minute);
                    timeBlock.EndTime = DateTime.Parse(dt_EndDate.Text).AddHours(dt_EndHours.Value.Hour).AddMinutes(dt_EndHours.Value.Minute);
                    timeBlock.Color = colorDialog.Color;
                    string color = timeBlock.Color.R + "," + timeBlock.Color.G + "," + timeBlock.Color.B;
                    rows[rowIndex].TimeBlocks[timeBlockIndex] = timeBlock;

                    SQL sql = new SQL();
                    sql.UpdateTimeBlock(timeBlock.id,timeBlock.Text,timeBlock.description,timeBlock.StartTime,timeBlock.EndTime,timeBlock.Hatch,timeBlock.Clickable,timeBlock.IsVisible, rows[rowIndex].id, color);

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

                foreach (TimeBlock _timeBlock in rows[index].TimeBlocks)
                {
                    if (timeBlock.id != _timeBlock.id && startTime >= _timeBlock.StartTime && startTime <= _timeBlock.EndTime || timeBlock.id != _timeBlock.id && endTime >= _timeBlock.StartTime && endTime <= _timeBlock.EndTime)
                    {
                        MessageBox.Show($"Já existe uma operação entre as datas selecionados!\n\nMaquina:{rows[index].Text}\nProcesso: {_timeBlock.Text}\nTempo: {_timeBlock.StartTime} - {_timeBlock.EndTime}", "Aviso");
                        return false;
                    }
                }

            return true;
        }

        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Deseja eliminar o processo {timeBlock.Text}?", "Confirmação", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                SQL sql = new SQL();
                sql.DeleteTimeBlock(timeBlock.id);
                rows[rowIndex].TimeBlocks.Remove(timeBlock);
                this.Hide();
            }
            
        }
    }
}

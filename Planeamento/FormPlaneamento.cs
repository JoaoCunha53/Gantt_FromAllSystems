using GanttChart;
using Maquina;
using Planeamento.lib.FormChargesNotebook;
using ManagingHolidays;
using Planeamento.lib.FromProcess;
using System.Drawing;


namespace Planeamento
{
    public partial class FormPlaneamento : Form
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Chart ganttChart { get; set; } //Can also be added via the designer

        public FormPlaneamento()
        {
            ganttChart = new Chart();
            
            InitializeComponent();
            AddAno();
            AdicionarDiasUteisNaComboBox(int.Parse(cb_Ano.Text));

            string[] splitDate = cb_Semana.Text.ToString().Trim().Split('-');
            StartDate = Convert.ToDateTime(splitDate[0]);
            EndDate = Convert.ToDateTime(splitDate[1]);
            DrawHolidaysOnChart();

            cb_Ano.SelectedValueChanged += cb_Ano_SelectedValueChanged;
            cb_Semana.SelectedValueChanged += cb_Semana_SelectedValueChanged;
            StartTimer();
        }

        public void BuilChart(DateTime StartDate, DateTime EndDate)
        {
            Control findGanttChart = this.Controls.Find("Gantt", true).FirstOrDefault();
            if (this.Controls.Contains(findGanttChart))
            {
                this.Controls.Remove(findGanttChart);
            }

            ganttChart.StartDate = StartDate;
            ganttChart.EndDate = EndDate;
            ganttChart.StartHourInDay = 0;
            ganttChart.EndHourInDay = 24;
            ganttChart.Name = "Gantt";

            this.Controls.Add(ganttChart); //Add the chart to the form
            ganttChart.Dock = DockStyle.Fill; //Expand the chart to fill the form
            
            ganttChart.UpdateView();
        }


        private void cb_Semana_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] splitDate = cb_Semana.Text.ToString().Trim().Split('-');
            StartDate = Convert.ToDateTime(splitDate[0]);
            EndDate = Convert.ToDateTime(splitDate[1]);
            BuilChart(StartDate, EndDate.AddDays(1));
        }

        private void AddContent(Chart ganttChart, string rowName, string shiftName, DateTime startHour, DateTime startEnd, Color color)
        {

        }

        private void selecionarSetorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChargesNotebook formchargesNotebook = new FormChargesNotebook(this);
            formchargesNotebook.ShowDialog();
            lb_ChargesNotebook.Text = ganttChart.Text;
            ganttChart.Rows.Clear();
            SQL sql = new SQL();
            sql.GetRowsByChargesNotebookId(ganttChart);

            BuilChart(StartDate, EndDate.AddDays(1));
            adicionarMaquinaToolStripMenuItem.Enabled = true;
            adicionarProcessoToolStripMenuItem.Enabled = true;

        }

        private void setorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adicionarMaquinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaquina formMaquina = new FormMaquina(ganttChart);
            formMaquina.ShowDialog();
            SQL sql = new SQL();
            //sql.GetRowsByChargesNotebookId(ganttChart);

            BuilChart(StartDate, EndDate.AddDays(1));
        }

        private void adicionarProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewTimeBlock fromProcess = new FormNewTimeBlock(ganttChart.Rows);
            fromProcess.ShowDialog();
            BuilChart(StartDate, EndDate.AddDays(1));
        }

        private void cb_Ano_SelectedValueChanged(object sender, EventArgs e)
        {
            AdicionarDiasUteisNaComboBox(int.Parse(cb_Ano.Text));
        }

        private void gerirFolgasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagingHolidays formManagingHolidays = new FormManagingHolidays();
            formManagingHolidays.ShowDialog();
            DrawHolidaysOnChart();
        }

        private void DrawHolidaysOnChart()
        {
            ganttChart.Holidays.Clear();
            Calendar.SQL sql = new Calendar.SQL();
            List<Calendar.TimeBlock> listHoliCalendar = sql.GetCalendarByHatchTrue();
            foreach(Calendar.TimeBlock holiday in listHoliCalendar)
            {
                ganttChart.Holidays.Add(holiday.Date, holiday.Text);
            }
            BuilChart(StartDate, EndDate.AddDays(1));
        }

        private void ReloadData()
        {
            if(ganttChart.Id != 0)
            {
                ganttChart.Rows.Clear();
                SQL sql = new SQL();
                sql.GetRowsByChargesNotebookId(ganttChart);

                BuilChart(StartDate, EndDate.AddDays(1));
            }
        }

        private async Task StartTimer()
        {
            // Loop infinito para repetir a cada 30 segundos
            while (true)
            {

                // Define o tempo total de execução (30 segundos)
                TimeSpan duration = TimeSpan.FromSeconds(30);
                DateTime endTime = DateTime.Now.Add(duration);

                // Executa a ação repetidamente até atingir 30 segundos
                while (DateTime.Now < endTime)
                {
                    // Chame sua função ou ação aqui
                    ReloadData();

                    // Aguarda 1 segundo antes da próxima execução
                    await Task.Delay(5000);
                }

            }
        }

    }
}

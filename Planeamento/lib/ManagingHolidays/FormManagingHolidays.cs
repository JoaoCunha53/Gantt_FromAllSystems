using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManagingHolidays
{
    public partial class FormManagingHolidays : Form
    {
        private CalendarChart calendarChart { get; set; }

        public FormManagingHolidays()
        {
            this.calendarChart = new CalendarChart();
            InitializeComponent();
            AddAno();
        }

        private void BuilCalendarChart()
        {
            Control findGanttChart = this.Controls.Find("Gantt", true).FirstOrDefault();
            if (this.Controls.Contains(findGanttChart))
            {
                this.Controls.Remove(findGanttChart);
            }

            int count = 1;
            calendarChart.StartDate = new DateTime(calendarChart.Id, 1, 1);
            while (calendarChart.StartDate.DayOfWeek != DayOfWeek.Sunday)
            {
                calendarChart.StartDate = new DateTime(calendarChart.Id, 1, 1).AddDays(-count);
                count++;
            }

            count = 1;
            calendarChart.EndDate = new DateTime(calendarChart.Id, 12, 31);
            while (calendarChart.EndDate.DayOfWeek != DayOfWeek.Monday)
            {
                calendarChart.EndDate = new DateTime(calendarChart.Id, 12, 31).AddDays(count);
                count++;
            }
            calendarChart.EndDate = new DateTime(calendarChart.Id, 1, 31).AddDays(count -1);

            calendarChart.Name = "Gantt";

            this.Controls.Add(calendarChart); //Add the chart to the form
            calendarChart.Dock = DockStyle.Fill; //Expand the chart to fill the form

            calendarChart.UpdateView();
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

        private void bt_NewYear_Click(object sender, EventArgs e)
        {
            FormBuildNewYear fromBuildNewYear = new FormBuildNewYear();
            fromBuildNewYear.ShowDialog();
            AddAno();
        }

        private void cb_Ano_SelectedValueChanged(object sender, EventArgs e)
        {
            calendarChart.Rows.Clear();
            if (cb_Ano.Items.Count != 0)
            {
                calendarChart.Id = int.Parse(cb_Ano.Text);
                SQL sql = new SQL();
                sql.GetRowsByChargesNotebookId(calendarChart);
                BuilCalendarChart();
            }
        }
    }
}

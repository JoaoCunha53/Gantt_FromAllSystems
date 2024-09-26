using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingHolidays
{
    public partial class FormBuildNewYear : Form
    {
        public FormBuildNewYear()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = int.Parse(txt_year.Text.Trim());
            SQL sql = new SQL();
            sql.InsertBuildNewCalendarByYear(year);
            this.Hide();
        }

        private void txt_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveData();
            }
        }

        private void SaveData()
        {
            int year = int.Parse(txt_year.Text.Trim());
            SQL sql = new SQL();
            sql.InsertBuildNewCalendarByYear(year);
            this.Hide();
        }
    }
}

using GanttChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GanttChart
{
    public class ChargesNotebook
    {
        public ChargesNotebook()
        {
            IsVisible = true;
            Row = new List<Row>();
        }

        public virtual int id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsVisible { get; set; }
        public virtual List<Row> Row { get; set; }
    }
}

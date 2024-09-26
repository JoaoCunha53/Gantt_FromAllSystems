using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;

namespace Calendar
{
    public class Row
    {
        public Row()
        {
            IsVisible = true;
            TimeBlocks = new List<TimeBlock>();
        }

        public Row(int month, string text)
        {
            this.Month = month;
            this.Text = text;
            IsVisible = true;
            TimeBlocks = new List<TimeBlock>();
        }

        public virtual int Month { get; set; }
        public virtual string Text { get; set; }
        public virtual List<TimeBlock> TimeBlocks { get; set; }
        public virtual Image Icon { get; set; }
        public virtual bool IsVisible { get; set; }
        public virtual Rectangle Rect { get; set; }
        public virtual Rectangle IconRect { get; set; }
    }
}
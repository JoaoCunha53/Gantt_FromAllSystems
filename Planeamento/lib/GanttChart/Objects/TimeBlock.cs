using System;
using System.Drawing;
using System.Xml.Serialization;

namespace GanttChart
{
    public class TimeBlock
    {
        public TimeBlock()
        {
            this.Hatch = false;
            this.Clickable = true;
            this.IsVisible = true;
        }

        public TimeBlock(string text)
        {
            this.Text = text;
            this.Hatch = false;
            this.Clickable = true;
            this.IsVisible = true;
        }

        public TimeBlock(int id, string text,string description, DateTime startTime, DateTime endTime)
        {
            this.id = id;
            this.Text = text;
            this.description = description;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Hatch = false;
            this.Clickable = true;
            this.IsVisible = true;
        }

        public virtual int id { get; set; }
        public virtual string Text { get; set; }
        public virtual string description { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual Color Color { get; set; }
        public virtual bool Hatch { get; set; }
        public virtual bool Clickable { get; set; }
        public virtual RectangleF Rect { get; set; }
        public virtual bool IsVisible { get; set; }

    }
}
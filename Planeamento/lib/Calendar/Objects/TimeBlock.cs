using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Calendar
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

        public TimeBlock(int idTimeBlock, string text, DateTime date, string description,bool hatch)
        {
            this.Id = idTimeBlock;
            this.Text = text;
            this.Description = description;
            this.Date = date;
            this.Hatch = hatch;
            this.Clickable = true;
            this.IsVisible = true;
        }

        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Color Color { get; set; }
        public virtual bool Hatch { get; set; }
        public virtual bool Clickable { get; set; }
        public virtual Rectangle Rect { get; set; }
        public virtual bool IsVisible { get; set; }
    }
}
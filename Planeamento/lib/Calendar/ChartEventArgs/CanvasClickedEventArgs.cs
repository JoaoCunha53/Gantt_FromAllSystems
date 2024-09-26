using System;
using System.Drawing;

namespace Calendar
{
    public class CanvasClickedEventArgs
    {
        public DateTime? ClickedLocation { get; set; }
        public Row RelatedRow { get; set; }
        public Point CursorLocation { get; set; }
    }
}
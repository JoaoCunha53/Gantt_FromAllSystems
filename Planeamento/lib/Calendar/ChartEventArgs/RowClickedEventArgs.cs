using System;
using System.Drawing;

namespace Calendar
{
    public class RowClickedEventArgs
    {
        public Row ClickedRow { get; set; }
        public Point CursorLocation { get; set; }
    }
}
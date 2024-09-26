using GanttChart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static Calendar.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Calendar
{
    public class Renderer
    {
        #region Private Properties
        private Graphics graphics;
        private Point autoScrollPosition;
        private Size autoScrollMinSize;
        private StringFormat alignAllCenter = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        private StringFormat alignVertCenter = new StringFormat() { LineAlignment = StringAlignment.Center };
        private Font font;
        #endregion Private Properties

        #region Constructor
        public Renderer()
        {
            InitDefaultValues();
        }
        #endregion Constructor

        #region Public Methods
        public void Render(Graphics g, Point autoScrollPosition, Size autoScrollSize, Font font)
        {
            this.graphics = g;
            this.autoScrollPosition = autoScrollPosition;
            this.autoScrollMinSize = autoScrollSize;
            this.font = font;

            DrawChart();
        }

        public Size CalculateAutoScrollSize(Size autoScrollMinSize, Size size, VScrollProperties verticalScroll)
        {
            Size autoScrollSize = this.autoScrollMinSize;

            //Dynamically adjust width
            if (verticalScroll.Visible)
                autoScrollSize.Width = size.Width - SystemInformation.VerticalScrollBarWidth;
            else
                autoScrollSize.Width = size.Width;

            int timeDivisions = (EndHourInDay - StartHourInDay) * (EndDate - StartDate).Days;
            int pixelsPerDivision = autoScrollSize.Width / timeDivisions;
            if (pixelsPerDivision < MinTimeIntervalWidth)
            {
                if (verticalScroll.Visible)
                    autoScrollSize.Width = timeDivisions * MinTimeIntervalWidth - SystemInformation.VerticalScrollBarWidth;
                else
                    autoScrollSize.Width = timeDivisions * MinTimeIntervalWidth;
            }

            //Dynamically adjust height
            if (Rows.Count > 0 && Rows.All(p => p.Rect != null))
            {
                int highestYValue = Rows.Select(p => { return p.Rect.Bottom; }).Max();
                autoScrollSize.Height = highestYValue + 1;
            }
            else
                autoScrollSize.Height = size.Height;

            if (autoScrollMinSize != autoScrollSize)
                autoScrollMinSize = autoScrollSize;

            return autoScrollMinSize;
        }
        #endregion Public Methods

        #region Private Methods
        private void InitDefaultValues()
        {
            TextColor = Color.Black;
            HeaderBackgroundColor = Color.LightBlue;
            BackgroundColor = Color.LightGray;
            TopHeaderHeight = 40;
            DefaultTimeLabelFormat = "htt";
            DefaultDayLabelFormat = "dddd";
            StartHourInDay = 0;
            EndHourInDay = 24;
            RowIconSize = new Size(15, 15);
            RowIconLocation = Corner.SW;
            HorizontalGridLinesVisible = false;
            VerticalGridLinesVisible = true;
            ShowNowIndicator = false;
            NowIndicatorHourOffset = 0;
            MinTimeIntervalWidth = 0;

            DayXLocations = new List<Tuple<DateTime, int, int>>();
            TimeXLocations = new List<Tuple<DateTime, int, StringFormat>>();
            TimeLabelFormats = new Dictionary<DateTime, string>();
            DayLabelFormats = new Dictionary<DateTime, string>();
            Rows = new List<Row>();
            Holidays = new Dictionary<DateTime, string>();
        }

        private void PopulateDateTimeXLocs(int startX, int endX)
        {
            int dayDivision = (int)Math.Round((double)(endX - startX) / (EndDate - StartDate).Days);
            int dayXLoc = startX;
            DateTime curDay = StartDate;
            while (curDay < EndDate)
            {
                int dayStart = dayXLoc;
                int dayEnd = dayXLoc + dayDivision;

                int timeDivision = (int)Math.Round((double)(dayEnd - dayStart) / (EndHourInDay - StartHourInDay));
                int xLoc = dayStart;
                int curHour = StartHourInDay;
                while (curHour <= EndHourInDay)
                {
                    DateTime dateWithHour = curDay.AddHours(curHour);

                    if (curHour == StartHourInDay)
                    {
                        StringFormat startFormat = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far };
                        TimeXLocations.Add(new Tuple<DateTime, int, StringFormat>(dateWithHour, dayStart, startFormat));
                    }
                    else if (curHour == EndHourInDay)
                    {
                        StringFormat endFormat = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far };
                        TimeXLocations.Add(new Tuple<DateTime, int, StringFormat>(dateWithHour, dayEnd, endFormat));
                    }
                    else
                    {
                        xLoc += timeDivision;
                        StringFormat otherFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
                        TimeXLocations.Add(new Tuple<DateTime, int, StringFormat>(dateWithHour, xLoc, otherFormat));
                    }

                    curHour++;
                }

                DayXLocations.Add(new Tuple<DateTime, int, int>(curDay, dayStart, dayEnd));
                dayXLoc = dayEnd;

                curDay = curDay.AddDays(1);
            }
        }

        private void DrawChart()
        {
            int topPading = 100;
            ResetGraphics();

            if (AreHoursValid() && AreDatesValid())
            {
                RecaculateFormatDictionaries();

                PopulateDateTimeXLocs(100, autoScrollMinSize.Width);

                Rectangle topRect = DrawTopHeaders(100, topPading, autoScrollMinSize.Width, TopHeaderHeight + 1 + topPading);

                DrawLeftHeaders(0, TopHeaderHeight + topPading, topRect.Width);

            }

            graphics.Flush();
        }

        private void ResetGraphics()
        {
            graphics.Clear(BackgroundColor);
            graphics.TranslateTransform(this.autoScrollPosition.X, this.autoScrollPosition.Y);

            DayXLocations.Clear();
            TimeXLocations.Clear();
        }

        private Rectangle DrawLeftHeaders(int startX, int startY,int width)
        {
            Pen pen = new Pen(Color.Black, 2);
            Brush brush;

            int headerWidth = 100;
            int headerHeight = 50;

            if (Rows.Count == 0)
                return new Rectangle(startX, startY, 0, 0);

            //Increase width if it will not fit the largest string
            int maxStringWidth = Rows.Select(p => { return (int)Math.Round(graphics.MeasureString(p.Text, this.font).Width); }).Max();
            if (maxStringWidth > headerWidth)
                headerWidth = maxStringWidth + 10; //10 for a "margin"

            int x = startX;
            int y = startY;
            foreach (Row row in Rows.Where(p => p.IsVisible))
            {
                Rectangle headerRect = new Rectangle(x, y, headerWidth, headerHeight);
                DrawRect(headerRect, HeaderBackgroundColor, Color.Black);
                DrawTextCenter(headerRect, row.Text);

                if (row.Icon != null)
                {
                    Rectangle iconRect = GetIconRect(headerRect);
                    graphics.DrawImage(row.Icon, iconRect);
                    row.IconRect = iconRect;
                }

                row.Rect = headerRect;

                //Draw Days
                startX = headerWidth + 1;
                brush = new SolidBrush(Color.White);
                int count = 0;
                while (row.TimeBlocks[0].Date.DayOfWeek != DayXLocations[count].Item1.DayOfWeek)
                {
                    startX = DrawDateBlocks(startX, startY, width, row.Rect.Height, count, 0,"", Color.White, false);
                    count++;
                }
                foreach (TimeBlock timeBlock in row.TimeBlocks)
                {
                    startX = DrawDateBlocks(startX, startY, width, row.Rect.Height, count, timeBlock.Date.Day , timeBlock.Date.Day.ToString(), timeBlock.Color,timeBlock.Hatch);
                    timeBlock.Rect = new Rectangle(startX - width, startY + 1, width - 1, row.Rect.Height - 1);
                    count++;
                }
                for (int i = count; i < DayXLocations.Count(); i++)
                {
                    startX = DrawDateBlocks(startX, startY, width, row.Rect.Height, count,0, "",Color.White, false);
                    count++;
                }
                startY = startY + 50;
                //End Draw Days

                y += headerRect.Height;
                //Increase AutoScrollMinSize (chart total area) if we overflow the end of the current area
                if (y > autoScrollMinSize.Height)
                    autoScrollMinSize = new Size(autoScrollMinSize.Width, y + 1); //Add 1 for pen width
            }

            return new Rectangle(startX, startY, headerWidth - startX, y - startY); //Return the total rect that the rows take up
        }

        private int DrawDateBlocks(int startX, int startY, int width, int height,int count,int day,string text,Color color,bool hatch)
        {
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(color);
            
            if (DayXLocations[count].Item1.DayOfWeek == DayOfWeek.Sunday || DayXLocations[count].Item1.DayOfWeek == DayOfWeek.Saturday)
            {
                if (hatch != true)
                {
                    brush = new SolidBrush(Color.LightBlue);
                }
            }
            RectangleF rect = new RectangleF(startX, startY + 1, width - 1, height - 1);
            // Desenhar o contorno do retângulo
            graphics.DrawRectangle(pen, rect);
            // (Opcional) Preencher o retângulo com uma cor
            graphics.FillRectangle(brush, rect);
            graphics.DrawString(text, this.font, new SolidBrush(Color.Black), new PointF(startX + 15, startY + 15));
            
            return startX + width;  
        }



        private Rectangle GetIconRect(Rectangle headerRect)
        {
            int x, y;

            switch (RowIconLocation)
            {
                case Corner.NW:
                    x = headerRect.Left;
                    y = headerRect.Top;
                    break;
                case Corner.NE:
                    x = headerRect.Right - RowIconSize.Width;
                    y = headerRect.Top;
                    break;
                case Corner.SE:
                    x = headerRect.Right - RowIconSize.Width;
                    y = headerRect.Bottom - RowIconSize.Height;
                    break;
                default:
                case Corner.SW:
                    x = headerRect.Left;
                    y = headerRect.Bottom - RowIconSize.Height;
                    break;
            }

            Rectangle iconRect = new Rectangle(x, y,
                                   RowIconSize.Width,
                                   RowIconSize.Height);

            return iconRect;
        }

        private Rectangle DrawTopHeaders(int startX, int startY, int endX, int endY)
        {
            Pen outlinePen = new Pen(Color.Black, 1);
            int width = 0;
            foreach (Tuple<DateTime, int, int> day in DayXLocations)
            {
                //Draw day rect
                Rectangle dayRect = new Rectangle(day.Item2, startY, day.Item3 - day.Item2, endY - startY);
                dayRect.Height -= (int)outlinePen.Width;
                graphics.DrawRectangle(outlinePen, dayRect);

                //Draw day header
                Point dayCenter = new Point(day.Item2 + dayRect.Width / 2, startY + dayRect.Height / 4);
                
                graphics.DrawString(GetAbbreviationDayWeek(day.Item1), this.font, TextBrush, dayCenter, alignAllCenter);
                width = (int)dayRect.Width;
            }

            //Adjust rect for return
            //Rectangle topRect = new Rectangle(startX, startY, endX - startX, endY - startY);
            Rectangle topRect = new Rectangle(startX, startY, width, endY - startY);
            topRect.Height -= (int)outlinePen.Width;

            return topRect;
        }

        private string GetAbbreviationDayWeek(DateTime data)
        {
            // Mapeamento dos dias da semana para suas abreviações
            switch (data.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "S-F"; // Segunda-feira
                case DayOfWeek.Tuesday:
                    return "T-F";  // Terça-feira
                case DayOfWeek.Wednesday:
                    return "Q-F";  // Quarta-feira
                case DayOfWeek.Thursday:
                    return "QI-F"; // Quinta-feira
                case DayOfWeek.Friday:
                    return "S-F";  // Sexta-feira
                case DayOfWeek.Saturday:
                    return "SAB"; // Sábado
                case DayOfWeek.Sunday:
                    return "DOM";  // Domingo
                default:
                    return "";   // Caso de erro
            }
        }


        private bool AreHoursValid()
        {
            if (StartHourInDay < 0 ||
                StartHourInDay > 23)
            {
                throw new Exception("StartHourInDay is not valid");
            }
            else if (EndHourInDay < 0 ||
                    EndHourInDay > 24 ||
                    EndHourInDay <= StartHourInDay)
            {
                throw new Exception("EndHourInDay is not valid");
            }
            else
                return true;
        }

        private bool AreDatesValid()
        {
            if (EndDate <= StartDate)
                throw new Exception("EndDate cannot be before or the same as StartDate");
            else
                return true;
        }

        private void DrawVerticalGridLines(int startX, int startY, int endX, int endY)
        {
            foreach (Tuple<DateTime, int, StringFormat> time in TimeXLocations)
            {
                Point p1 = new Point(time.Item2, startY);
                Point p2 = new Point(time.Item2, endY - 1);
                graphics.DrawLine(new Pen(Color.Black), p1, p2);
            }
        }

        private void DrawHorizontalGridLines(int endX)
        {
            foreach (Row row in Rows)
            {
                //Draw a line from the bottom of each row rect (except for the last one)
                if (Rows.IndexOf(row) != Rows.Count - 1)
                {
                    Rectangle rowRect = row.Rect;

                    Point p1 = new Point(rowRect.Right, rowRect.Bottom);
                    Point p2 = new Point(endX, rowRect.Bottom);
                    graphics.DrawLine(new Pen(Color.Black), p1, p2);
                }
            }
        }

        private void DrawRect(Rectangle rect, Color insideColor, Color borderColor, bool offsetForPen = false, bool hatch = false)
        {
            Brush fillBrush = new SolidBrush(insideColor);
            if (hatch)
                fillBrush = new HatchBrush(HatchStyle.ForwardDiagonal, Color.White, insideColor);

            Pen outlinePen = new Pen(borderColor);

            graphics.FillRectangle(fillBrush, rect);

            if (offsetForPen)
                graphics.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width - outlinePen.Width, rect.Height - outlinePen.Width);
            else
                graphics.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void DrawTextCenter(Rectangle rect, string text, Color? textColor = null)
        {
            int stringLengthPixels = (int)Math.Round(graphics.MeasureString(text, this.font).Width);
            if (stringLengthPixels > rect.Width - 3) //"3" leaves room for margin on both sides
            {
                int convertedLength = (int)((double)(rect.Width - 5) / stringLengthPixels * text.Length);
                if (convertedLength < 0)
                    text = "";
                else
                    text = text.Substring(0, convertedLength) + "..";
            }

            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);

            if (textColor.HasValue)
                graphics.DrawString(text, this.font, new SolidBrush(textColor.Value), center.X, center.Y, alignAllCenter);
            else
                graphics.DrawString(text, this.font, TextBrush, center.X, center.Y, alignAllCenter);
        }

        private void RecaculateFormatDictionaries(bool overwrite = false)
        {
            if (overwrite)
            {
                DayLabelFormats.Clear();
                TimeLabelFormats.Clear();
            }

            DateTime curDay = StartDate;
            while (curDay < EndDate)
            {
                int curHour = StartHourInDay;
                while (curHour <= EndHourInDay)
                {
                    DateTime dateWithHour = curDay.AddHours(curHour);

                    if (!TimeLabelFormats.ContainsKey(dateWithHour))
                        TimeLabelFormats.Add(dateWithHour, DefaultTimeLabelFormat);

                    curHour++;
                }

                if (!DayLabelFormats.ContainsKey(curDay))
                    DayLabelFormats.Add(curDay, DefaultDayLabelFormat);

                curDay = curDay.AddDays(1);
            }
        }
        #endregion Private Methods

        #region Public Properties
        public Rectangle MainCanvas;
        public SolidBrush TextBrush { get { return new SolidBrush(TextColor); } }
        public Color TextColor { get; set; }
        public Color HeaderBackgroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartHourInDay { get; set; }
        public int EndHourInDay { get; set; }
        public List<Tuple<DateTime, int, int>> DayXLocations { get; set; } //Format is "Date (without hour), xStartLocation, xEndLocation"
        public List<Tuple<DateTime, int, StringFormat>> TimeXLocations { get; set; } //Format is "Date (with hour), xLocation, alignment"
        public Dictionary<DateTime, string> TimeLabelFormats { get; set; }
        public Dictionary<DateTime, string> DayLabelFormats { get; set; }
        public Dictionary<DateTime, string> Holidays { get; set; }
        public List<Row> Rows { get; set; }
        public int TopHeaderHeight { get; set; }
        public string DefaultTimeLabelFormat { get; set; }
        public string DefaultDayLabelFormat { get; set; }
        public Size RowIconSize { get; set; }
        public Corner RowIconLocation { get; set; }
        public bool HorizontalGridLinesVisible { get; set; }
        public bool VerticalGridLinesVisible { get; set; }
        public bool ShowNowIndicator { get; set; }
        public int NowIndicatorHourOffset { get; set; }
        public int MinTimeIntervalWidth { get; set; }
        #endregion Public Properties
    }
}
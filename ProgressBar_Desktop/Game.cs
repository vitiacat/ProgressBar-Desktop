using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ProgressBar_Desktop
{
    public partial class Game : Form
    {
        private Point oldMousePoint = MousePosition;
        private Point progressBarPosition = MousePosition;

        private int oldPointRemoveTime = 0;
        private int newPointTime = 0;
        private int newSegmentTime = 0;
        private int newPopupTime = 0;
        private int invulnerableTime = 0;
        private bool isLose = false;
        private int maxDistance = 150;

        private readonly List<Type> popupTypes = new List<Type>() { typeof(TextPopup), typeof(MovementPopup), typeof(ButtonsPopup), typeof(MinePopup) };
        private readonly Size PROGRESSBAR_SIZE = new Size(250, 50);
        private const int INVULNERABLE_TIME = 120;
        private readonly List<Segment> segments = new List<Segment>();
        private readonly List<SegmentType> collectedSegments = new List<SegmentType>();
        private readonly List<Form> popups = new List<Form>();
        private readonly Random random = new Random();
        private readonly ResultsObj resultsObj = new ResultsObj(0, 0, 0);
        private readonly BufferedPanel canvas;
        private readonly List<Point> points = new List<Point>();

        private readonly float SEGMENT_WIDTH = 245 * Config.SegmentValue / 100f;

        public Game()
        {
            InitializeComponent();
            AllowTransparency = true;
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            Location = Point.Empty;
            StartPosition = FormStartPosition.Manual;
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            canvas = new BufferedPanel
            {
                Dock = DockStyle.Fill,
                Location = Point.Empty
            };
            canvas.Paint += canvas_paint;
            Controls.Add(canvas);

            uint initialStyle = Program.GetWindowLong(Handle, -20);
            Program.SetWindowLong(Handle, -20, (IntPtr) (initialStyle | 0x80000 | 0x20));
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            var rect = new RectangleF(progressBarPosition, PROGRESSBAR_SIZE);
            oldPointRemoveTime++;
            newPointTime++;
            newSegmentTime++;
            newPopupTime++;
            if(Config.IsInvulnerable) invulnerableTime++;
            if (invulnerableTime >= 0)
            {
                Config.IsInvulnerable = false;
            }

            if (oldPointRemoveTime > 5 && points.Count > 0)
            {
                points.RemoveRange(0, Math.Min(points.Count, points.Count > 10 ? 2 : 1));
                oldPointRemoveTime = 0;
            }

            if(newSegmentTime > Config.SegmentTime && !isLose)
            {
                var segment = new Segment(new Point(random.Next(0, ClientSize.Width), 0),
                    Config.Segments[random.Next(Config.Segments.Count)],
                    Config.SegmentSpeed);
                segments.Add(segment);
                newSegmentTime = 0;
            }

            if(newPopupTime > Config.PopupTime && !isLose && popups.Count < Config.PopupsMaxCount && Config.IsPopupsEnabled)
            {
                var popup = (Form) Activator.CreateInstance(popupTypes[random.Next(popupTypes.Count)]);
                popup.Show(); 
                popup.Location = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
                popups.Add(popup);
                newPopupTime = 0;
            }

            foreach (Segment segment in segments.ToArray())
            {
                segment.DoTick();
                if(rect.Contains(segment.Position) && !isLose)
                {
                    switch(segment.Type)
                    {
                        case SegmentType.FATAL:
                            Lose();
                            break;
                        case SegmentType.DOUBLE:
                        case SegmentType.TRIABLE:
                            var count = segment.Type == SegmentType.DOUBLE ? 2 : 3;
                            collectedSegments.RemoveAll(s => s == SegmentType.MINUS || s == SegmentType.EMPTY);
                            collectedSegments.AddRange(Enumerable.Repeat(SegmentType.GOOD, count));
                            break;
                        case SegmentType.MINUS:
                            if(collectedSegments.Count(s => s != SegmentType.MINUS) == 0)
                            {
                                collectedSegments.Add(segment.Type);
                                break;
                            }
                            collectedSegments.RemoveRange(0, Math.Min(5 / Config.SegmentValue, collectedSegments.Count));
                            break;
                        case SegmentType.EMPTY:
                            if (collectedSegments.Count(s => s != SegmentType.EMPTY) == 0)
                            {
                                collectedSegments.Add(segment.Type);
                                break;
                            }
                            break;
                        case SegmentType.RM_POPOUTS:
                            popups.GetRange(0, Math.Min(popups.Count, 5)).ForEach(f => f.Close());
                            collectedSegments.RemoveRange(0, Math.Min(10 / Config.SegmentValue, collectedSegments.Count));
                            break;
                        case SegmentType.INVULNERABLE:
                            Config.IsInvulnerable = true;
                            invulnerableTime -= INVULNERABLE_TIME;
                            break;
                        default:
                            collectedSegments.Add(segment.Type);
                            collectedSegments.RemoveAll(s => s == SegmentType.MINUS || s == SegmentType.EMPTY);
                            break;
                    }

                    segments.Remove(segment);
                }
            }

            if(isLose && Keyboard.IsKeyDown(Key.Space))
            {
                mainTimer.Stop();
                Close();
                Dispose();
                new Game().ShowDialog();   
                return;
            }

            if(Keyboard.IsKeyDown(Key.Escape))
            {
                mainTimer.Stop();
                if (MessageBox.Show("Вы точно хотите выйти?", "ProgressBar: Desktop", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Close();
                else mainTimer.Start();
            }

            bool isContains = false;

            foreach (Form popup in popups.ToArray())
            {
                if(!popup.IsHandleCreated)
                {
                    popups.Remove(popup);
                    resultsObj.ClosedPopupsCount++;
                    continue;
                }

                if (new RectangleF(popup.Location, popup.Size).IntersectsWith(rect))
                {
                    isContains = true;
                    if(popup.GetType() == typeof(MinePopup))
                    {
                        Lose();
                    }
                }
            }

            if (!isContains && GetDistance(MousePosition, progressBarPosition) < maxDistance) 
                progressBarPosition = MousePosition;

            if (MousePosition != oldMousePoint && newPointTime > 2 && !isContains && GetDistance(MousePosition, progressBarPosition) < maxDistance)
            {
                points.Add(oldMousePoint);
                oldMousePoint = MousePosition;
                newPointTime = 0;
            }

            canvas.Refresh();

            if (Config.SegmentValue * collectedSegments.Count >= 100 && !isLose)
            {
                mainTimer.Stop();
                segments.Clear();
                resultsObj.BlueSegments = collectedSegments.Count(s => s == SegmentType.GOOD);
                resultsObj.OrangeSegments = collectedSegments.Count(s => s == SegmentType.BAD);
                resultsObj.IsMinusSegments = collectedSegments.Count(s => s == SegmentType.MINUS) > 0;
                resultsObj.IsEmptySegments = collectedSegments.Count(s => s == SegmentType.EMPTY) > 0;
                var results = new Results(resultsObj);
                results.ShowDialog();
                Close();
            }

        }

        private void canvas_paint(object sender, PaintEventArgs e)
        {
            foreach(Point p in points)
            {
                DrawProgressBar(e.Graphics, p);
            }

            DrawProgressBar(e.Graphics, progressBarPosition);

            foreach (Segment segment in segments)
            {
                segment.Draw(e.Graphics);
            }

            if (isLose)
            {
                e.Graphics.FillRectangle(Brushes.DarkGray, 0, 0, 275, 25);
                e.Graphics.DrawString("Нажмите Space для продолжения", 
                    new Font(FontFamily.GenericSansSerif, 13), Brushes.White, 0, 0);
            }

        }

        private void DrawProgressBar(Graphics g, Point pos, bool renderProgress = true)
        {
            var rect = new Rectangle(pos, PROGRESSBAR_SIZE);
            g.DrawRectangle(Config.IsInvulnerable ? Pens.LightGoldenrodYellow : Pens.Gray, rect);

            float pos2 = 0;

            foreach (SegmentType segment in collectedSegments)
            {
                g.FillRectangle(isLose ? Brushes.Red : new SolidBrush(Segment.SegmentsColors[segment]), new RectangleF((PointF) pos + new SizeF(3 + pos2, 3), new SizeF(SEGMENT_WIDTH, 45)));
                pos2 += SEGMENT_WIDTH;
            }
            
            g.DrawString(isLose ? "ОШИБКА" :
                collectedSegments.Count(s => s == SegmentType.EMPTY) > 0 ? $"NULL{Config.SegmentValue * collectedSegments.Count}" :
                collectedSegments.Count(s => s == SegmentType.MINUS) > 0 ? $"-{Config.SegmentValue * collectedSegments.Count}%" :
                $"{Config.SegmentValue * collectedSegments.Count}%", new Font(FontFamily.GenericSansSerif, 13), Brushes.White, Utils.CenterRectangle(rect), Utils.CenteredStringFormat);
        }

        private static double GetDistance(PointF first, PointF second)
        {
            float x1 = first.X, x2 = second.X, y1 = first.Y, y2 = second.Y;
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            popups.ForEach(f => f.Close());
        }

        private void Lose()
        {
            if (Config.IsInvulnerable)
                return;
            isLose = true;
            collectedSegments.Clear();
            collectedSegments.AddRange(Enumerable.Repeat(SegmentType.FATAL, 100 / Config.SegmentValue));
            popups.ForEach(f => f.Close());
        }
    }
}

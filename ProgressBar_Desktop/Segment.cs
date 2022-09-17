using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar_Desktop
{
    public class Segment
    {
        public PointF Position { get; set; }
        public float Speed { get; set; }
        public SegmentType Type { get; private set; }
        public float FluctuationX { get; private set; }
        public float Fluctuation { get; private set; }

        public static int SegmentsCount = Enum.GetValues(typeof(SegmentType)).Length;
        public static Dictionary<SegmentType, Color> SegmentsColors = new Dictionary<SegmentType, Color>()
        {
            { SegmentType.GOOD, Color.Blue },
            { SegmentType.BAD, Color.Orange },
            { SegmentType.FATAL, Color.Red },
            { SegmentType.DOUBLE, Color.LightSkyBlue },
            { SegmentType.TRIABLE, Color.LightSkyBlue },
            { SegmentType.MINUS, Color.HotPink },
            { SegmentType.EMPTY, Color.Gray },
            { SegmentType.RM_POPOUTS, Color.Gold },
            { SegmentType.INVULNERABLE, Color.SpringGreen }
        };
        public static Dictionary<SegmentType, string> SegmentsChars = new Dictionary<SegmentType, string>()
        {
            { SegmentType.GOOD, "" },
            { SegmentType.BAD, "" },
            { SegmentType.FATAL, "!" },
            { SegmentType.DOUBLE, "2" },
            { SegmentType.TRIABLE, "3" },
            { SegmentType.MINUS, "-" },
            { SegmentType.EMPTY, "" },
            { SegmentType.RM_POPOUTS, "X" },
            { SegmentType.INVULNERABLE, "~" }
        };
        public static Size size = new Size(17, 27);

        public Segment(PointF position, SegmentType type, float speed)
        {
            Position = position;
            Type = type;
            Speed = speed;
            Fluctuation = (float)Utils.NextDouble((double)-Config.SegmentFluctuation / 4f, (double)Config.SegmentFluctuation / 4f);
        }

        public void Draw(Graphics g)
        {
            var rect = new RectangleF(Position, size);
            g.FillRectangle(new SolidBrush(SegmentsColors[Type]), rect);

            g.DrawString(SegmentsChars[Type], new Font(FontFamily.GenericSerif, 12, FontStyle.Bold), Brushes.White, Utils.CenterRectangle(rect), Utils.CenteredStringFormat);
        }

        public void DoTick()
        {
            Position += new SizeF(Fluctuation, Speed);
            FluctuationX += Fluctuation;
            if (FluctuationX > Config.SegmentFluctuation || FluctuationX < -Config.SegmentFluctuation)
                Fluctuation = -Fluctuation;

        }

    }

    public enum SegmentType
    {
        GOOD,
        BAD,
        FATAL,
        DOUBLE,
        TRIABLE,
        MINUS,
        EMPTY,
        RM_POPOUTS,
        INVULNERABLE
    }
}

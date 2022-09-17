using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar_Desktop
{
    public static class Utils
    {
        public static StringFormat CenteredStringFormat { get {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                return sf;
            } }

        public static PointF CenterRectangle(RectangleF rect)
        {
            return new PointF(rect.Left + rect.Width / 2,
                             rect.Top + rect.Height / 2);
        }

        public static double NextDouble(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}

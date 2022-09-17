using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar_Desktop
{
    public partial class MovementPopout : Form
    {
        private Point velocity = Point.Empty;

        public MovementPopout()
        {
            InitializeComponent();
            GenerateVelocity();
        }

        private void GenerateVelocity()
        {
            var random = new Random();
            velocity = new Point(random.Next(-10, 10), random.Next(-10, 10));
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            Location += ((Size)velocity);
            var formRectangle = new Rectangle(Location, ClientSize);
            if(!Screen.PrimaryScreen.WorkingArea.Contains(formRectangle))
            {
                velocity = new Point(-velocity.X, -velocity.Y);
            }
        }
    }
}

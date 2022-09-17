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
    public partial class ButtonsPopup : Form
    {

        public ButtonsPopup()
        {
            InitializeComponent();
            Button[] buttons = new Button[4];
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;

            var correctBtn = new Random().Next(buttons.Length);

            for (int i = 0; i < buttons.Length; i++)
            {
                if(correctBtn == i)
                    buttons[i].Click += (a, b) => Close();
                else
                    buttons[i].Click += (a, b) => ((Button)a).Text = "Не та!";
            }
        }
    }
}

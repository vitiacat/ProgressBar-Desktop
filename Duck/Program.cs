using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar_Desktop
{
    internal static class Program
    {
        [DllImport("user32.dll", SetLastError = true)]

        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]

        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        public static Levels Levels = new Levels();
       
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //uint initialStyle = GetWindowLong(form.Handle, -20);
            //SetWindowLong(form.Handle, -20, (IntPtr) (initialStyle | 0x80000 | 0x20));
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}

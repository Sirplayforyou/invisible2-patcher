using System;
using System.Windows.Forms;

namespace Patcher.ListCreator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new lForm());
        }
    }
}

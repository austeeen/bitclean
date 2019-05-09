using System;
using Gtk;

namespace bitclean
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            UI.MainWindow win = new UI.MainWindow();
            win.Show();
            Application.Run();
        }
    }
}

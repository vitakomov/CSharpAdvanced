using System;
using System.Drawing;
using System.Windows.Forms;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            SplashScreen.Init(form);
            form.Show();
            SplashScreen.Draw();
            SplashScreen.Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Application.Run(form);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
           SplashScreen.Draw();
           SplashScreen.Update();
        }
    }
}

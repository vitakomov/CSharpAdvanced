using System;
using System.Drawing;
using System.Windows.Forms;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Game.Load();
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Application.Run(form);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
           Game.Draw();
           Game.Update();
        }
    }
}

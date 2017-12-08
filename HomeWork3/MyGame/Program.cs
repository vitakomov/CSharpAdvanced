using System;
using System.Windows.Forms;
namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            //Timer timer = new Timer { Interval = 50 };
            Game.timer.Start();
            Game.timer.Tick += Timer_Tick;
            Application.Run(form);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Game.Draw();
            Game.Update();
        }
    }
}


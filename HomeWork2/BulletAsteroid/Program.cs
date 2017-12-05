using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BulletAsteroid
{
    class Program
    {
        static void Main(string[] args)
        {
                Form form = new Form();
                form.Width = 800;
                form.Height = 600;
                Start.Init(form);
                form.Show();
                Start.Draw();
                Start.Load();
                Timer timer = new Timer { Interval = 50 };
                timer.Start();
                timer.Tick += Timer_Tick;
                Application.Run(form);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Start.Draw();
            Start.Update();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 800,
                Height = 800
            };
            form.Show();
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Application.Run(form);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.WriteLine("\nPress a key to display; press the 'x' key to quit.");

                // Your code could perform some useful task in the following loop. However, 
                // for the sake of this example we'll merely pause for a quarter second.
                while (Console.KeyAvailable == false)
                    Console.WriteLine("1");   // Loop until input is entered.

                cki = Console.ReadKey(true);
                Console.WriteLine($"You pressed the {cki.Key} key.");
            } while (cki.Key != ConsoleKey.X);
            Application.Exit();
        }
    }
}

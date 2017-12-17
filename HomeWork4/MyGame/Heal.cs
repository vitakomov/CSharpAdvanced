using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Heal : BaseObject
    {
        public Heal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Green, new Rectangle(Pos.X, Pos.Y, 20, 20));
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Random rnd = new Random();
            if (Pos.X < 0) { Pos.X = Game.Width + Size.Width; Pos.Y = rnd.Next(1, Game.Height); }
        }
    }
}

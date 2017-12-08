using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Red, new Rectangle(Pos.X, Pos.Y, 5, 1));
            // Game.Buffer.Graphics.DrawLine(Pens.Red, Pos.X, Pos.Y, Pos.X - Size.Width, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            //if (Pos.X > Game.Width) Pos.X = 0;
        }
    }
}

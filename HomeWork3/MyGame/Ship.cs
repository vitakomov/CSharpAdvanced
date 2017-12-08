using System.Drawing;
namespace MyGame
{
    class Ship : BaseObject
    {
        private int energy = 100;
        public int Energy => energy;
        public static event Message MessageDie;
        Bitmap Plane = new Bitmap("Plane.jpg");
        public void EnergyLow(int n)
        {
            energy -= n;
        }
        public void EnergyHeal(int n)
        {
            energy += n;
        }
        public void EnergyClear()
        {
            energy = 100;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
            Plane.MakeTransparent(Color.FromArgb(0, 0, 0));
            Game.Buffer.Graphics.DrawImage(Plane, Pos.X, Pos.Y);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}

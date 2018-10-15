using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mygame
{
    class Ship : BaseObject
    {
        private readonly Image ship;
        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public void EnergyUp(int n)
        {
            _energy += n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            ship = Image.FromFile("ship.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(ship, Pos.X, Pos.Y, Size.Width + 30, Size.Height+30);
        }
        public override void Update()
        {
        }

        public static event Message MessageDie;

       

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

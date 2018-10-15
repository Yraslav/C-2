using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Mygame
{
    class Heal : BaseObject, ICloneable, IComparable
    {
        Image heal;
        public int Power { get; set; } = 1;
        public Heal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            heal = Image.FromFile("heal.png");
            Power = 1;
        }

        public object Clone()
        {
           
            Heal heal = new Heal(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
           
            heal.Power = Power;
            return heal;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(heal, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Heal temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }



        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;

        }
    }
}

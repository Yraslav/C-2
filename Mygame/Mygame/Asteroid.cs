using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mygame
{
    class Asteroid : BaseObject , ICloneable , IComparable
    {
        Image asteroid;
        public int Power { get; set; } = 1;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            asteroid = Image.FromFile("meteor.png");
            Power = 1;
        }

        public object Clone()
        {
            // Создаем копию нашего робота
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            // Не забываем скопировать новому астероиду Power нашего астероида
            asteroid.Power = Power;
            return asteroid;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
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



            //Pos.X = Pos.X - Dir.X;
            //Pos.Y = Pos.Y - Dir.Y;
            //if (Pos.X < 0) Pos.X = Game.Width + Size.Width ;
            //if (Pos.Y < 0) Pos.Y = Game.Width + Size.Width ;
        }

       

    }
}
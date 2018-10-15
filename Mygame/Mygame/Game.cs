using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Mygame
{
    class Game
    {
        
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static List<Bullet> _bullet = new List<Bullet>();
        private static Asteroid[] _asteroids;
        private static Heal[] _heal;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
            
        }
        public static void Init(Form form)
        {
            
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ fgbnfgb gfbк главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер  памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            form.KeyDown += Form_KeyDown;

            Ship.MessageDie += Finish;

            Load();

            
            timer.Start();
            timer.Tick += Timer_Tick;



        }
        private static Timer timer = new Timer { Interval = 100 };


        public static Random Rnd = new Random();
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        


        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 100, _ship.Rect.Y + 40), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Space) _bullet.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), 
                new Point(4, 0), new Size(4, 1)));
        }

        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));


        public static BaseObject[] _objs;
        public static void Load()
        {

            _objs = new BaseObject[9];
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[9];
            _heal = new Heal[1];
            var rnd = new Random();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(500, rnd.Next(0, Game.Height)), new Point(r, r), new Size(r, r));

            }

            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(300, rnd.Next(0, Game.Height)), new Point(r, r), new Size(r, r));
            }

            for (var i = 0; i < _heal.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _heal[i] = new Heal(new Point(300, rnd.Next(0, Game.Height)), new Point(r, r), new Size(r, r));
            }


        }
      
        public static void Draw()
        {
           
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(40, 40, 40, 40));

            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Bullet b in _bullet) b.Draw();

            foreach (Heal obj in _heal)
            {
                obj?.Draw();
            }
            //_bullet?.Draw();
            _ship?.Draw();

            Buffer.Render();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);


            foreach (Asteroid obj in _asteroids)
            {
                obj?.Draw();
            }
            //_bullet?.Draw();
            _ship?.Draw();

            Buffer.Render();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
         

          

        }

        public static void Update()
        {




            foreach (BaseObject obj in _objs) obj.Update();
            //_bullet?.Update();
        

            for (var i = 0; i < _heal.Length; i++)
            {
                if (_heal[i] == null) continue;
                _heal[i].Update();
                for (int j = 0; j < _bullet.Count; j++)
                    if (_bullet != null && _bullet[j].Collision(_asteroids[i]))

                {
                    System.Media.SystemSounds.Hand.Play();
                    _heal[i] = null;
                    _bullet = null;
                    continue;

                }

                if (!_ship.Collision(_heal[i])) continue;

                var rnd = new Random();
                _ship?.EnergyUp(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();

                //if (_ship.Energy <= 0) _ship?.Die();
                }
            foreach (Bullet b in _bullet) b.Update();
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                for (int j = 0; j < _bullet.Count; j++)
                    if (_asteroids[i] != null && _bullet[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        _bullet.RemoveAt(j);
                        
                        j--;
                        //continue;

                    }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                _ship.EnergyLow(Rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }
        }


    }



}


            







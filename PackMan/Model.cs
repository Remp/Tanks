using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PackMan
{

    public delegate void StatusChange();

    class Model
    {
        public event StatusChange statuschange;
        int size;
        int tanksAmount;
        int applesAmount;
        int weaponC;
        int crushedTankCounter;
        private Player pl;
        private List<Tank> tanks;
        private List<Weapon> weapons;
        private List<Wall> walls;
        private List<Weapon> gainedWeapons;
        private WeaponCounter weaponCounter;
        Random r;

        public Player Pl { get { return pl; } }
        public List<Projectile> Pr { get; set; }
        public State state { get; set;}
        public int speed { get; }
        public List<Tank> Tanks { get { return tanks; } }
        public List<Weapon> Weapons { get { return weapons; } }
        public List<Wall> Walls { get { return walls; } }
        public WeaponCounter WeaponCounterProperty { get { return weaponCounter; } }
        public int WeaponC { get { return weaponC; } set { weaponC = value; } }


        public Model(int size, int tanksAmount, int applesAmount, int speed)
        {
            this.size = size;
            this.tanksAmount = tanksAmount;
            this.applesAmount = applesAmount;
            this.speed = speed;
          
            r = new Random();

            NewGame();
        }

        public void NewGame()
        {
            pl = new Player(size);
            tanks = new List<Tank>();
            walls = new List<Wall>();
            weapons = new List<Weapon>();
            Pr = new List<Projectile>();
            gainedWeapons = new List<Weapon>();
            weaponCounter = new WeaponCounter(size);

            weapons.Add(new Weapon(0, size));

            CreateWalls();
            CreateWeapons(applesAmount);
            CreateTanks();

            crushedTankCounter = 0;
            weaponC = 0;
            state = State.stoped;
            statuschange?.Invoke(); //проверка на нулевое значение и последующий вызов
        }

        private void CreateWalls()
        {
            for (int i = 20; i <= 260; i += 40)
                for (int j = 20; j <= 220; j += 40)
                    walls.Add(new Wall(i, j));
        }
        private void CreateWeapons(int addition = 0)
        {
            int x, y;

            while (Weapons.Count <= addition)
            {
                x = r.Next(7) * 40;
                y = r.Next(7) * 40;
                bool quit = false;
                foreach (Weapon w in Weapons)
                {
                    if (w.X == x && w.Y == y)
                        quit = true;
                }

                if (quit)
                    continue;

                Weapons.Add(new Weapon(x, y));
            }
        }


        private void CreateTanks()
        {
            int x, y;
           
            //единоразовое создание охотника под индеком 0
            if (Tanks.Count == 0)
                Tanks.Add(new Hunter(size, r.Next(7) * 40, r.Next(7)* 40));

            while (Tanks.Count < tanksAmount)
            {
                x = r.Next(7) * 40;
                y = r.Next(7) * 40;
                bool quit = false;

                foreach (Tank t in Tanks)
                {
                    if (x == t.X && y == t.Y || Pl.X == x && Pl.Y == y)
                        quit = true;
                }
                if (quit)
                    continue;
                
                Tanks.Add(new Tank(size, x, y));
            }
        }

        public void Play()
        {
            while (state == State.commenced)
            {
                Thread.Sleep(speed);

                //движение игрока
                Pl.Run();

                //движение снаряда
                for (int i = 0; i < Pr.Count; i++)
                {
                    if (Pr[i] != null)
                        Pr[i].Run(); 
                }

                //движение охотника по направлению к игроку
                ((Hunter)Tanks[0]).Run(Pl.X, Pl.Y);

                //движение танков
                for (int q = 1; q < Tanks.Count; q++)
                    Tanks[q].Run();

                //попадание снаряда в танк
                if (Pr != null)
                {
                    for (int p = 1; p < Tanks.Count; p++)
                    {
                        for (int pi = 0; pi < Pr.Count; pi++)
                        {           
                            if ((Pr[pi].X - Tanks[p].X >= 0 && Pr[pi].X - Tanks[p].X <= 20) && (Pr[pi].Y - Tanks[p].Y >= 0 && Pr[pi].Y - Tanks[p].Y <= 20))
                            {
                                Tanks.RemoveAt(p);
                                Pr.RemoveAt(pi);
                                crushedTankCounter++;
                                if (crushedTankCounter >= 4)
                                {
                                    state = State.winner;
                                    statuschange();
                                }
                            }
                        }
                    }
                }

                //проверка вылета снаряда за границы поля
                if (Pr != null)
                    for (int pi = 0; pi < Pr.Count; pi++)
                        if (Pr[pi].X == -1 || Pr[pi].X == size + 1 || Pr[pi].Y == -1 || Pr[pi].Y == size + 1)
                            Pr.RemoveAt(pi);


                //механика отталкивания
                for (int i = 0; i < Tanks.Count - 1; i++)
                    for (int j = i + 1; j < Tanks.Count; j++)
                        if
                            (
                                Math.Abs(Tanks[i].X - Tanks[j].X) <= 19 && (Tanks[i].Y == Tanks[j].Y)
                                ||
                                Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 19 && (Tanks[i].X == Tanks[j].X)
                                ||
                                Math.Abs(Tanks[i].X - Tanks[j].X) <= 19 && Math.Abs(Tanks[i].Y - Tanks[j].Y) <= 19                                
                            )
                        {
                            if (i == 0)
                                ((Hunter)Tanks[0]).TurnAround();
                            else
                                Tanks[i].TurnAround();

                            Tanks[j].TurnAround();
                        }

                //проверка столкновения
                for (int c = 0; c < Tanks.Count; c++)
                {
                    if (
                            Math.Abs(Pl.X - Tanks[c].X) <= 19 && (Pl.Y == Tanks[c].Y)
                            ||
                            Math.Abs(Pl.Y - Tanks[c].Y) <= 19 && (Pl.X == Tanks[c].X)
                            ||
                            Math.Abs(Pl.X - Tanks[c].X) <= 19 && Math.Abs(Pl.Y - Tanks[c].Y) <= 19

                       )
                    {
                        state = State.looser;
                        statuschange();
                    }
                }

                //реализация подбора оружия
                for (int k = 0; k < Weapons.Count; k++)
                {
                    if (Math.Abs(Pl.X - Weapons[k].X) <= 19 && (Pl.Y == Weapons[k].Y)
                        ||
                        Math.Abs(Pl.Y - Weapons[k].Y) <= 19 && (Pl.X == Weapons[k].X))
                    {
                        weapons.RemoveAt(k);
                        weaponCounter.PutCurrentImg(++weaponC);
                    }
                }

                //создает на поле кол-во снарядов которое нехватает по отношению снарядов у игрока
                CreateWeapons(applesAmount - weaponC);


            }
        }
    }
}

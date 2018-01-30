using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class Weapon
    {
        WeaponImage weaponimg = new WeaponImage();
        
        public Image Img { get; }
        public int X { get; }
        public int Y { get; }

        public Weapon(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Img = weaponimg.Img;
        }
    }
}

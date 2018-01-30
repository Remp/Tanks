using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class WeaponCounter
    {
        WeaponCounterImage weaponCounterImage = new WeaponCounterImage();

        private Image currentImg;
        int x, y, size;

        public Image CurrentImg { get { return currentImg; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public WeaponCounter(int size)
        {
            this.size = size;
            x = 20;
            y = size; ;
            PutCurrentImg(0);
        }
        
        public void PutCurrentImg (int count)
        {
            if (count == 0)
                currentImg = Properties.Resources.Counter0;
            if (count == 1)
                currentImg = Properties.Resources.Counter1;
            if (count == 2)
                currentImg = Properties.Resources.Counter2;
            if (count == 3)
                currentImg = Properties.Resources.Counter3;
        }


    }

    class WeaponCounterImage
    {
        Image[] counter = new Image[]
        {
            Properties.Resources.Counter0,
            Properties.Resources.Counter1,
            Properties.Resources.Counter2,
            Properties.Resources.Counter3
        };

        public Image[] Counter { get { return counter; } }
    }
}

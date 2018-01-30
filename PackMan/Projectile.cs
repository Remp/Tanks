using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackMan
{
    class Projectile: IHaveCurrentPicture
    {
        ProjectileImage projectileImage = new ProjectileImage();
        Image currentImage;
        int x, y, moveX, moveY, size;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public int MoveX { get { return moveX; } set { moveX = value; } }
        public int MoveY { get { return moveY; } set { moveY = value; } }

        public Image CurrentImage{ get { return currentImage;} }

        public Projectile(int x, int y, int moveX, int moveY)
        {
            this.x = x;
            this.y = y;
            this.moveX = moveX;
            this.moveY = moveY;
            PutImg();
        }
       
        private void PutImg()
        {
            if (moveX == -1)
                currentImage = projectileImage.Left;
            if (moveX == 1)
                currentImage = projectileImage.Right;
            if (moveY == -1)
                currentImage = projectileImage.Up;
            if (moveY == 1)
                currentImage = projectileImage.Down;
        }

        public void Run()
        {
            x += moveX * 3;
            y += moveY * 3;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackMan
{
    class Hunter: Tank
    {
        HunterImage hunterImage = new HunterImage();

        public Hunter(int size, int x, int y) : base(size, x, y)
        {
            PutImg();
            PutCurrentImage();
        }
        private void PutImg()
        {
            if (moveX == 1)
                img = hunterImage.Right;
            if (moveX == -1)
                img = hunterImage.Left;
            if (moveY == 1)
                img = hunterImage.Down;
            if (moveY == -1)
                img = hunterImage.Up;
        }

        public void Run(int targetX, int targetY)
        {
            x += moveX;
            y += moveY;
            Transparent();
            if (x % 40 == 0 && y % 40 == 0)
                Turn(targetX, targetY);
            PutCurrentImage();
        }

        public void Turn(int targetX, int targetY )
        {
            moveX = moveY = 0;
            if (X < targetX)
                moveX = 1;
            if (X > targetX)
                moveX = -1;
            if (Y < targetY)
                moveY = 1;
            if (Y > targetY)
                moveY = -1;

            if (moveX != 0 && moveY != 0)
                if (r.Next(5000) < 2500)
                    moveX = 0;
                else
                    moveY = 0;
            PutImg();
        }

        new public void TurnAround()
        {
            moveX = -1 * moveX;
            moveY = -1 * moveY;
            PutImg();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class Player : IRun, ITurn, ITransparent, IHaveCurrentPicture
    {
        WhiteTankImage tankImg = new WhiteTankImage();
        static Random r;

        private int x, y, size;
        private int moveX, moveY;
        public int nextX, nextY;
        private Image[] img;
        private Image currentImg;
        private int counter;

        public int MoveX { get { return moveX; } }
        public int MoveY { get { return moveY; } }
        public Image CurrentImage { get { return currentImg; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Player(int size)
        {
            this.size = size;
            x = 120;
            y = 240;
            r = new Random();

            while (!(moveX != 0 && moveY == 0 || moveX == 0 && moveY != 0))
            {
                moveX = r.Next(-1, 2);
                moveY = r.Next(-1, 2);
            }
            nextX = moveX;
            nextY = moveY;
            PutImg();
            PutCurrentImage();

        }

        void PutImg()
        {
            if (moveX == 1)
                img = tankImg.Right;
            if (moveX == -1)
                img = tankImg.Left;
            if (moveY == 1)
                img = tankImg.Down;
            if (moveY == -1)
                img = tankImg.Up;

        }

        public void Run()
        {
            x += moveX;
            y += moveY;
            Transparent();
            if (x % 40 == 0 && y % 40 == 0)
                Turn();
            PutCurrentImage();
        }

        private void PutCurrentImage()
        {
            if (counter > 3)
                counter = 0;
            currentImg = img[counter++];
        }

        public void Turn()
        {
            moveX = nextX;
            moveY = nextY;
            PutImg();
        }

        public void Transparent()
        {
            if (x == -1)
            {
                x = size - 21;
                return;
            }

            if (x == size - 19)
            {
                x = 1;
                return;
            }

            if (y == -1)
            {
                y = size - 21;
                return;
            }

            if (y == size - 19)
            {
                y = 1;
                return;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class Tank: IRun, ITurn, ITurnAround, ITransparent, IHaveCurrentPicture
    {
        private PurpleTankImage tankImg = new PurpleTankImage();
        protected static Random r;

        protected int x, y, size;
        protected int moveX, moveY;
        protected Image[] img;
        protected Image currentImg;
        protected int counter;

        public Image CurrentImage { get { return currentImg; } }
        public int X {get { return x; } }
        public int Y {get { return y; } }
       
        public Tank(int size, int x, int y)
        {
            //размер нужно знать, для обеспечения зеркальных стен
            this.size = size;

            r = new Random();

            //начальные координаты
            this.x = x;
            this.y = y;

            //начальное направление
            while (!(moveX != 0 && moveY == 0 || moveX == 0 && moveY != 0))
            {
                moveX = r.Next(-1, 2);
                moveY = r.Next(-1, 2); 
            }
            PutImg();
            PutCurrentImage();

        }

        //обеспечивает смену массива картинок при повороте
        private void PutImg()
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

        //механика движения
        public void Run()
        {
            x += moveX;
            y += moveY;
            Transparent();
            if (x % 40 == 0 && y % 40 == 0)
                Turn();
            PutCurrentImage();
        }

        //обеспечивает анимацию движения
        protected void PutCurrentImage()
        {
            if (counter > img.Count() - 1)
                counter = 0;
            currentImg = img[counter++];
        }

        //механика поворота
        public void Turn()
        {                                    
            if (r.Next(5000) < 2500) //движение по оси X
            {
                if (moveX != 0)
                { }
                else
                {
                    moveY = 0;
                    while (moveX == 0)
                        moveX = r.Next(-1, 2);
                }                                      
            }
            else // движение по оси Y
            {
                if (moveY != 0)
                { }
                else
                {
                    moveX = 0;
                    while (moveY == 0)
                        moveY = r.Next(-1, 2);
                }
            }
            PutImg();                                

        }

        //мезаника зеркальных стен
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

        //механика разворота при столкновении
        public void TurnAround()
        {
            moveX = -1 * moveX;
            moveY = -1 * moveY;
            PutImg();
        }
    }
}

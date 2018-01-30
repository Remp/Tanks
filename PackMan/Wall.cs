using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class Wall: IHavePicture
    {
        WallImage wallImage = new WallImage();

        public Image Img { get; }
        public int X { get; }
        public int Y { get; }
        public Wall(int x, int y)
        {
            Img = wallImage.WallImg;
            X = x;
            Y = y;
        }
    }
}

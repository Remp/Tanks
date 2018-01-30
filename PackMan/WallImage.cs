using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class WallImage
    {
        Image wallImg;

        public Image WallImg
        {
            get
            {
                return wallImg = Properties.Resources.Wall;
            }
        }
    }
}

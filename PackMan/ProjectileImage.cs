using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class ProjectileImage
    {
        #region images
        Image up = Properties.Resources.ProjectileUp;
        Image down = Properties.Resources.ProjectileDown;
        Image right = Properties.Resources.ProjectileRight;
        Image left = Properties.Resources.ProjectileLeft;
        #endregion

        #region properties
        public Image Up { get { return up; } }
        public Image Down { get { return down; } }
        public Image Left { get { return left; } }
        public Image Right { get { return right; } }
        #endregion

    }
}

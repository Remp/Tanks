using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    class PurpleTankImage
    {
        #region Properties
        public Image[] Up
        {
            get { return up; }
        }
        public Image[] Down
        {
            get { return down; }
        }
        public Image[] Left
        {
            get { return left; }
        }
        public Image[] Right
        {
            get { return right; }
        }


        #endregion

        #region Images
        Image[] up = new Image[]
        {
            Properties.Resources.PurpleTankUp1,
            Properties.Resources.PurpleTankUp2,
            Properties.Resources.PurpleTankUp3,
            Properties.Resources.PurpleTankUp4
        };

        Image[] down = new Image[]
        {
            Properties.Resources.PurpleTankDown1,
            Properties.Resources.PurpleTankDown2,
            Properties.Resources.PurpleTankDown3,
            Properties.Resources.PurpleTankDown4
        };

        Image[] left = new Image[]
        {
            Properties.Resources.PurpleTankLeft1,
            Properties.Resources.PurpleTankLeft2,
            Properties.Resources.PurpleTankLeft3,
            Properties.Resources.PurpleTankLeft4
        };

        Image[] right = new Image[]
        {
            Properties.Resources.PurpleTankRight1,
            Properties.Resources.PurpleTankRight2,
            Properties.Resources.PurpleTankRight3,
            Properties.Resources.PurpleTankRight4,
        };
        #endregion

    }

    class WhiteTankImage
    {

        #region Properties
        public Image[] Up
        {
            get { return up; }
        }
        public Image[] Down
        {
            get { return down; }
        }
        public Image[] Left
        {
            get { return left; }
        }
        public Image[] Right
        {
            get { return right; }
        }


        #endregion

        #region Images
        Image[] up = new Image[]
        {
            Properties.Resources.WhiteTankUp1,
            Properties.Resources.WhiteTankUp2,
            Properties.Resources.WhiteTankUp3,
            Properties.Resources.WhiteTankUp4
        };

        Image[] down = new Image[]
        {
            Properties.Resources.WhiteTankDown1,
            Properties.Resources.WhiteTankDown2,
            Properties.Resources.WhiteTankDown3,
            Properties.Resources.WhiteTankDown4
        };

        Image[] left = new Image[]
        {
            Properties.Resources.WhiteTankLeft1,
            Properties.Resources.WhiteTankLeft2,
            Properties.Resources.WhiteTankLeft3,
            Properties.Resources.WhiteTankLeft4
        };

        Image[] right = new Image[]
        {
            Properties.Resources.WhiteTankRight1,
            Properties.Resources.WhiteTankRight2,
            Properties.Resources.WhiteTankRight3,
            Properties.Resources.WhiteTankRight4,
        };
        #endregion
    }

    class HunterImage
    {
        #region Properties
        public Image[] Up
        {
            get { return up; }
        }
        public Image[] Down
        {
            get { return down; }
        }
        public Image[] Left
        {
            get { return left; }
        }
        public Image[] Right
        {
            get { return right; }
        }


        #endregion

        #region Images
        Image[] up = new Image[]
        {
            Properties.Resources.HunterUp1,
            Properties.Resources.HunterUp2,
            Properties.Resources.HunterUp3
        };

        Image[] down = new Image[]
        {
            Properties.Resources.HunterDown1,
            Properties.Resources.HunterDown2,
            Properties.Resources.HunterDown3
        };

        Image[] left = new Image[]
        {
            Properties.Resources.HunterLeft1,
            Properties.Resources.HunterLeft2,
            Properties.Resources.HunterLeft3
        };

        Image[] right = new Image[]
        {
            Properties.Resources.HunterRight1,
            Properties.Resources.HunterRight2,
            Properties.Resources.HunterRight3
        };
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PackMan
{
    interface IRun
    {
        void Run();
    }


    interface ITurn
    {
        void Turn();
    }

    interface ITurnAround
    {
        void TurnAround();
    }


    interface IWeaponPickUp
    {
        void PickUp();
    }


    interface ITransparent
    {
        void Transparent();
    }

    interface IHavePicture
    {
        Image Img { get; }
    }

    interface IHaveCurrentPicture
    {
        Image CurrentImage { get; }
    }

}

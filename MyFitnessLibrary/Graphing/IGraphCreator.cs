using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyFitnessLibrary.Graphing
{
    interface IGraphCreator
    {

        Image GetImage(IGraphOptions graphOptions)
        {
        }
    }

    interface IGraphOptions
    {

    }
}

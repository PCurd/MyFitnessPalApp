using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyFitnessLibrary.Graphing
{
    public interface IGraphCreator
    {

        Image GetImage(IGraphOptions graphOptions);
        void CreateChart(GraphType graphType);
    }

    public interface IGraphOptions
    {

    }

    public enum GraphType
    {
        Bar, Line, Pie, Venn, Scatter
    }
}

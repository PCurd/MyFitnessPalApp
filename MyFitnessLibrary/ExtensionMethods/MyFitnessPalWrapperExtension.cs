using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFitnessLibrary.Network;
using MyFitnessLibrary.XML;
using MyFitnessLibrary.Graphing;
using MyFitnessLibrary.Fitness;
using System.Drawing;

namespace MyFitnessLibrary.ExtensionMethods
{
    public static class MyFitnessPalWrapperExtension
    {
        public static Image GetCaloriesComparisonBarGraph(this IMyFitnessPalWrapper wrapper)
        {
            DataSetBuilder dataSetBuilder = new DataSetBuilder(wrapper.MyFitnesses, wrapper.Days);
            
            return wrapper.Graph.GetCaloriesComparisonGraph(GraphType.Bar, wrapper.MyFitnesses, dataSetBuilder, wrapper.Days).GetImage(wrapper.Graph.DefaultGraphOptions);
        }
    }
}

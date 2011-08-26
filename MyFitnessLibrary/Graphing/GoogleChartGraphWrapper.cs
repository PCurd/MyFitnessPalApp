using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoogleChartSharp;
using MyFitnessLibrary.Fitness;

namespace MyFitnessLibrary.Graphing
{
    public class GoogleChartGraphWrapper : MyFitnessLibrary.Graphing.IGraphWrapper
    {
     
        public IGraphCreator GetCaloriesComparisonGraph(GraphType graphType, MyFitnessList MyFitnesses, int Days)
        {

            DataSetBuilder dataSetBuilder = new DataSetBuilder(MyFitnesses,Days);
            int LeftRange;
            List<int[]> caloriesComparison = dataSetBuilder.CaloriesComparison(out LeftRange);
            IGraphCreator Graph = new GoogleChartGraphCreator(caloriesComparison, dataSetBuilder.DateLabels, LeftRange);
            Graph.CreateChart(graphType);
            return Graph;
        }

        public IGraphOptions DefaultGraphOptions { get { return new GoogleChartGraphOptions(); } }
    }
}

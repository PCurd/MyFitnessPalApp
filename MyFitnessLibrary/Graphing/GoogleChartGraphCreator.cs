using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GoogleChartSharp;

namespace MyFitnessLibrary.Graphing
{
    public class GoogleChartGraphCreator : IGraphCreator
    {
        List<int[]> datasets = new List<int[]>();
        string[] BottomLabels;
        Chart chart;
        private int LeftRange = 0;

        public GoogleChartGraphCreator(List<int[]> datasets)
        {
            this.datasets = datasets;
        }


        public GoogleChartGraphCreator(List<int[]> datasets, string[] BottomLabels, int LeftRange) :this(datasets)
        {
            this.BottomLabels = BottomLabels;
            this.LeftRange = LeftRange;
        }

        void CreateBarChart()
        {
            int Width = 500;
            chart = new BarChart(Width, 600, BarChartOrientation.Vertical, BarChartStyle.Stacked);
            //chart.SetTitle("Vertical Stacked");
            ChartAxis BottomAxis = new ChartAxis(ChartAxisType.Bottom);
            ChartAxis LeftAxis = new ChartAxis(ChartAxisType.Left);

            //LeftAxis.SetRange(0, datasets[0].Max());
            if (LeftRange>0)
                LeftAxis.SetRange(0, LeftRange);

            if (BottomLabels != null)
            {
                ChartAxis BottomAxis2 = new ChartAxis(ChartAxisType.Bottom);
                int bottomLabelsCount = BottomLabels.Count();
                for (int i = 0; i < bottomLabelsCount; i++)
                {
                    string label = BottomLabels[i];
                    if (i % 2 != 0)
                    {
                        //Odd
                        BottomAxis.AddLabel(new ChartAxisLabel(label, (100.0f / bottomLabelsCount)*(i+0.5f)));
                    }
                    else
                    {
                        BottomAxis2.AddLabel(new ChartAxisLabel(label, (100.0f / bottomLabelsCount) * (i+0.5f)));
                    }

                }

                chart.AddAxis(BottomAxis);
                chart.AddAxis(BottomAxis2);
            }
            else
                chart.AddAxis(BottomAxis);
            //BottomAxis.AddLabel(new ChartAxisLabel(

            chart.AddAxis(LeftAxis);
            chart.SetData(datasets);

            chart.SetDatasetColors(new string[] { "FF0000", "00AA00" });
        }

        public void CreateChart(GraphType graphType)
        {
            switch (graphType)
            {
                case GraphType.Bar: CreateBarChart(); break;
            }
        }

        string GetUrl()
        {
            if (chart == null)
                throw new NullReferenceException("Chart has not been created");
            return chart.GetUrl();
        }

        public Image GetImage(IGraphOptions graphOptions)
        {
            return (new ImageDownloader(new Uri(GetUrl()))).DownloadedImage;
        }



    }
}
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
        Chart chart;

        public GoogleChartGraphCreator(List<int[]> datasets)
        {
            this.datasets = datasets;
        }

        void CreateBarChart()
        {
            chart = new BarChart(250, 450, BarChartOrientation.Vertical, BarChartStyle.Stacked);
            chart.SetTitle("Horizontal Stacked");
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
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

    public class GoogleChartGraphOptions : IGraphOptions
    {
    }
}
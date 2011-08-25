using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFitnessLibrary.Graphing;

namespace MyFitnessLibrary.Fitness
{
    public class MyFitnessPalConfigXMLGoogleChart : MyFitnessLibrary.Fitness.IMyFitnessPalConfig
    {
        private IMyFitnessPalWrapper myFitnessPal;
        public MyFitnessPalConfigXMLGoogleChart(int Days)
        {
            this.Days = Days;
            this.myFitnessPal = new MyFitnessPalXMLWrapper(@"ConfigFile.xml", Days, new GoogleChartGraphWrapper());
        }

        public int Days { get; set; }

        public IMyFitnessPalWrapper MyFitnessPal { get { return myFitnessPal; } }
    }
}

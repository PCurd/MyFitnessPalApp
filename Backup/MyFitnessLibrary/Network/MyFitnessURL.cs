using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using MyFitnessLibrary.Fitness;

namespace MyFitnessLibrary.Network
{
    public static class MyFitnessURL
    {
        private static Dictionary<MyFitnessStatType, string> URLs = new Dictionary<MyFitnessStatType, string>();
        private const string MyFitnessBaseURL = @"http://www.myfitnesspal.com/reports/results";

        public static  string AddSpaces(MyFitnessStatType MyFitnessStat)
        {
            return Enum.GetName(typeof(MyFitnessStatType), MyFitnessStat).Replace("_"," ");
        }

        public static string AddSpaces(string MyFitnessString)
        {
            return MyFitnessString.Replace(@"/", " ");
        }

        static MyFitnessURL()
        {
            foreach (var MyFitnessStat in Enum.GetValues(typeof(MyFitnessStatType)).Cast<MyFitnessStatType>())
            {
                if ((int)MyFitnessStat<10)
                {
                    //Progress
                    URLs.Add(MyFitnessStat, string.Format("progress/{0}", (int)MyFitnessStat));
                }
                else if ((int)MyFitnessStat < 20)
                {
                    //Fitness
                    URLs.Add(MyFitnessStat, string.Format("fitness/{0}", AddSpaces(MyFitnessStat)));
                }
                else
                {
                    //Nutrition
                    URLs.Add(MyFitnessStat, string.Format("nutrition/{0}", AddSpaces(MyFitnessStat)));
                }
            }
        }

        public static string FormatURL(MyFitnessStatType MyFitnessStat, int NumberOfDays)
        {
            return string.Format("{0}/{1}/{2}", MyFitnessBaseURL, URLs[MyFitnessStat], NumberOfDays);
        }
    }
}

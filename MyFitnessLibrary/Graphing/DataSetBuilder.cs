using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MyFitnessLibrary.Fitness;
using MyFitnessLibrary.XML;
using MyFitnessLibrary.Network;
using System.IO;

namespace MyFitnessLibrary.Graphing
{
    public class DataSetBuilder 
    {
        private int Days;
        private MyFitnessList fitnessList;
        private double DataSetScaleFactor = 4095.0;

        public DataSetBuilder(MyFitnessList FitnessList, int Days)
        {
            if ((Days > (DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365)) || (Days < 1))
            {
                throw new ArgumentOutOfRangeException("Number of Days cannot exceed number of days this year or be less than 1");
            }
            fitnessList = FitnessList;
            this.Days = Days;
        }

        public String[] DateLabels
        {
            get
            {
                return GetShortDates(fitnessList.Last(Days));
            }
        }


        public List<int[]> CaloriesComparison(out int LeftRange)
        {

            List<int[]> dataset = new List<int[]>();

            dataset.Add(GetDataSetByMyFitnessStatType(MyFitnessStatType.Net_Calories, fitnessList.Last(Days)));

            dataset.Add(GetDataSetByMyFitnessStatType(MyFitnessStatType.Calories_Burned, fitnessList.Last(Days)));

            //Calculate maximum Calories:
            LeftRange = GetDataSetByMyFitnessStatType(MyFitnessStatType.Calories, fitnessList.Last(Days)).Max();
            //4095.0/2800
            return ScaleListOfArray(dataset, DataSetScaleFactor / LeftRange);

        }

        private int[] GetDataSetByMyFitnessStatType(MyFitnessStatType myFitnessStatType, List<MyFitness> Records)
        {

            int[] tempDataSet = new int[Records.Count];

            for (int i = 0; i < Records.Count; i++)
            {
                MyFitness myFitness = Records[i];

                tempDataSet[i] = (int)myFitness.GetFitnessValue(myFitnessStatType);
            }
            return tempDataSet;
        }

        private String[] GetShortDates(List<MyFitness> Records)
        {
            string[] tempDataSet = new string[Records.Count];

            for (int i = 0; i < Records.Count; i++)
            {
                MyFitness myFitness = Records[i];

                tempDataSet[i] = string.Format("{0:dd/MM/yy}",myFitness.Date);
            }
            return tempDataSet;
        }
        private List<int[]> ScaleListOfArray(List<int[]> list, double scale)
        {
            for (int i = 0; i<list.Count;i++)
            {
                list[i] = ScaleList(list[i].ToList<int>(), scale).ToArray();
            }
            return list;
        }

        private List<int> ScaleList(List<int> list, double scale)
        {
            return list.Select(x => (int)(x * scale)).ToList();
        }
    }
}

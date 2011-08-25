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
        private MyFitnessList fitnessList;

        public DataSetBuilder(MyFitnessList FitnessList)
        {
            fitnessList = FitnessList;

        }

        public String[] DateLabels
        {
            get
            {
                return GetShortDates(fitnessList.LastFortnight);
            }
        }


        public List<int[]> CaloriesComparison(out int LeftRange)
        {

            List<int[]> dataset = new List<int[]>();

            dataset.Add(GetDataSetByMyFitnessStatType(MyFitnessStatType.Net_Calories, fitnessList.LastFortnight));

            dataset.Add(GetDataSetByMyFitnessStatType(MyFitnessStatType.Calories_Burned, fitnessList.LastFortnight));

            //Calculate maximum Calories:
            LeftRange = GetDataSetByMyFitnessStatType(MyFitnessStatType.Calories, fitnessList.LastFortnight).Max();
            //4095.0/2800
            return ScaleListOfArray(dataset,4095.0/LeftRange);

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

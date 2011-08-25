using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyFitnessLibrary.Fitness;
using MyFitnessLibrary.XML;
using MyFitnessLibrary.Network;
using MyFitnessLibrary.Graphing;
using System.IO;

namespace MyFitnessPalApp
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
        public List<int[]> CaloriesComparison
        {
            get
            {
                List<int[]> dataset = new List<int[]>();

                dataset.Add(GetDataSetByMyFitnessStatType(MyFitnessStatType.Net_Calories, fitnessList.LastFortnight));

                dataset.Add(GetDataSetByMyFitnessStatType(MyFitnessStatType.Calories_Burned, fitnessList.LastFortnight));

                return dataset;
            }
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
    }
}

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

        public List<int[]> CaloriesComparison
        {
            get
            {
                List<int[]> dataset;
                int[] tempDataSet = new int[fitnessList.Values.Count];
                for (int i = 0; i < fitnessList.Values.Count; i++)
                {
                    MyFitness myFitness = fitnessList.Values[i];
                    tempDataSet[i] = (int)myFitness.GetFitnessValue(MyFitnessStatType.Calories);
                }
                dataset = new List<int[]>();

                dataset.Add(tempDataSet);

                tempDataSet = new int[fitnessList.Values.Count];

                for (int i = 0; i < fitnessList.Values.Count; i++)
                {
                    MyFitness myFitness = fitnessList.Values[i];
                    tempDataSet[i] = (int)myFitness.GetFitnessValue(MyFitnessStatType.Calories_Burned);
                }

                dataset.Add(tempDataSet);

                return dataset;
            }
        }
    }
}

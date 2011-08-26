using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFitnessLibrary.Fitness
{
    public class MyFitnessList
    {
        public List<MyFitness> Values;

        public MyFitnessList()
        {
            Values = new List<MyFitness>();
        }

        public List<MyFitness> LastFortnight
        {
            get
            {
                return Last(14);
            }
        }

        //public List<MyFitness> LastDays
        //{
        //    get{return Last(

        public List<MyFitness> Last(int count)
        {
            IEnumerable<MyFitness> valuesNonExcluded = Values.Where(x => !x.IsExcluded);
            return valuesNonExcluded.Where((x, y) => y > valuesNonExcluded.Count() - (count + 1)).ToList();
        }
    }
}

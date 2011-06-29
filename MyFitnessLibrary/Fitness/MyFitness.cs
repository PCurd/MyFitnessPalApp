using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFitnessLibrary.XML;
using MyFitnessLibrary.Network;
using System.Xml.Serialization;

namespace MyFitnessLibrary.Fitness
{
    public class MyFitness
    {
        private string _RawDate;
        public string RawDate
        {
            get
            {
                return _RawDate;
            }
            set
            {
                _RawDate = value;
                if (_RawDate.Length>0)
                    Date= ConvertRawDateToDate(RawDate);
            }
        }

        public DateTime Date { get; set; }
        public bool IsExcluded { get; set; }

       
        public double Weight { get; set; }
        public double Neck { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double Calories_Burned { get; set; }
        public double Exercise_Minutes { get; set; }
        public double Net_Calories { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Saturated_Fat { get; set; }
        public double Polyunsaturated_Fat { get; set; }
        public double Monounsaturated_Fat { get; set; }
        public double Trans_Fat { get; set; }
        public double Cholesterol { get; set; }
        public double Sodium { get; set; }
        public double Potassium { get; set; }
        public double Fiber { get; set; }
        public double Sugar { get; set; }
        public double Vitamin_A { get; set; }
        public double Vitamin_C { get; set; }
        public double Iron { get; set; }
        public double Calcium { get; set; }


        public MyFitness()
        {
            RawDate = "";

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var MyFitnessStat in Enum.GetValues(typeof(MyFitnessStatType)).Cast<MyFitnessStatType>())
            {
                sb.Append(string.Format("{0}: {1} ", MyFitnessURL.AddSpaces(Enum.GetName(typeof(MyFitnessStatType), MyFitnessStat)), GetFitnessValue(MyFitnessStat)));
            }

            return sb.ToString();
        }

        public double GetFitnessValue(MyFitnessStatType MyFitnessStat)
        {
            return (double)this.GetType().GetProperty(Enum.GetName(typeof(MyFitnessStatType),MyFitnessStat)).GetValue(this,null);
        }

        public void SetFitnessValue(MyFitnessStatType MyFitnessStat, double Value)
        {
            this.GetType().GetProperty(Enum.GetName(typeof(MyFitnessStatType), MyFitnessStat)).SetValue(this, Value, null);
        
        }

        public static DateTime ConvertRawDateToDate(string _RawDate)
        {
            DateTime LocalDate = DateTime.Parse(DateTime.Now.Year + "/" + _RawDate);

            if (LocalDate > DateTime.Now)
                LocalDate = LocalDate.AddYears(-1);

            return LocalDate;
        }

        public void Update(MyFitnessStatType MyFitnessStat, double NumberValue)
        {
            SetFitnessValue(MyFitnessStat, NumberValue);
        }

        public static MyFitness Create(MyFitnessStatType MyFitnessStat, MyFitnessXML item)
        {
            MyFitness _MyFitness = new MyFitness { RawDate = item.StringValue };
            _MyFitness.Update(MyFitnessStat, item.NumberValue);

            return _MyFitness;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using MyFitnessLibrary.Network;
using MyFitnessLibrary.Fitness;

namespace MyFitnessLibrary.XML
{

    public class XMLMyFitnessLoader
    {
        Login _login;

        public XMLMyFitnessLoader(Login login)
        {
            _login = login;
        }

        private XDocument GetXML(MyFitnessStatType MyFitnessStat, int NumberOfDays)
        {
            string URL = MyFitnessURL.FormatURL(MyFitnessStat, NumberOfDays);
            return GetXML(URL);
        }

        private XDocument GetXML(string URL)
        {

            StringBuilder builder = new StringBuilder();
            string ReadPage = _login.ReadPage(URL);

            return XDocument.Parse(ReadPage);

        }

        public List<MyFitnessXML> GetValues(XDocument xDoc)
        {

            var Chart_DataL = from c in xDoc.Elements("chart").Elements("chart_data").Elements("row")
                              select c;

            var Chart_DataStrings = from c in Chart_DataL
                                    where c.Element("string") != null
                                    select c.Elements("string");

            var Chart_DataNumbers = from c in Chart_DataL
                                    where c.Element("number") != null
                                    select c.Elements("number");

            List<MyFitnessXML> XMLList = new List<MyFitnessXML>();

            //Start at 1 to avoid first record is 0 bug
            for (int i = 1; i < Chart_DataStrings.ElementAt(0).Count(); i++)
            {

                XMLList.Add(new MyFitnessXML
                {
                    StringValue = (string)Chart_DataStrings.ElementAt(0).ElementAt(i),
                    NumberValue = (double)Chart_DataNumbers.ElementAt(0).ElementAt(i)
                });
            }

            return XMLList;

        }
        /// <summary>
        /// Enter from outside class
        /// </summary>
        /// <param name="MyFitnessStat"></param>
        /// <param name="MyFitnessList"></param>
        /// <param name="NumberOfDays"></param>
        public void GetValue(MyFitnessStatType MyFitnessStat, List<MyFitness> MyFitnessList, int NumberOfDays)
        {
            if ((NumberOfDays > (DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365)) || (NumberOfDays < 1))
            {
                throw new ArgumentOutOfRangeException("Number of Days cannot exceed number of days this year or be less than 1");
            }
            //GetXML based on the stat type
            //get one more day due to the zero first record bug
            var XML = GetXML(MyFitnessStat, NumberOfDays + 1);
            //Get values from xml
            var ListXML = GetValues(XML);
            //assign to collection
            ConvertXMLListToValue(MyFitnessList, ListXML, MyFitnessStat);
        }

        public void ConvertXMLListToValue(List<MyFitness> MyFitnessList, List<MyFitnessXML> XMLList, MyFitnessStatType MyFitnessStat)
        {
            foreach (var item in XMLList)
            {
                var ExistingMyFitness = MyFitnessList.FirstOrDefault(x => x.Date == MyFitness.ConvertRawDateToDate(item.StringValue));
                if (ExistingMyFitness != null)
                {
                    ExistingMyFitness.Update(MyFitnessStat, item.NumberValue);
                }
                else
                {
                    MyFitnessList.Add(MyFitness.Create(MyFitnessStat, item));
                }
            }
        }







    }
}

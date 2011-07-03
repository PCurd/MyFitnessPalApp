using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFitnessLibrary.Network;
using MyFitnessLibrary.XML;

namespace MyFitnessLibrary.Fitness
{
    public class MyFitnessPalWrapper
    {

        public LoadConfig config { get; set; }
        public LoginDetails loginDetails { get; set; }
        public Login login { get; set; }
        public XMLMyFitnessLoader Loader { get; set; }
        public int Days { get; set; }
        public MyFitnessList MyFitnesses;
        public XMLMyFitnessExporter xmlMyFitnessExporter;
        private XMLMyFitnessImporter xmlMyFitnessImporter;

        public MyFitnessPalWrapper(string ConfigFileName, int Days)
        {

            config = new LoadConfig(ConfigFileName);
            loginDetails = (LoginDetails)config.GetContents(typeof(LoginDetails));
            login = new Login(loginDetails);
            Loader = new XMLMyFitnessLoader(login);
            this.Days = 14;
            MyFitnesses = new MyFitnessList();
           
        }

        public void LoadValues()
        {
            Loader.LoadValues(Days, ref MyFitnesses);
        }

        public void ExportXML(string FileName)
        {
            xmlMyFitnessExporter = new XMLMyFitnessExporter(MyFitnesses, FileName);
            xmlMyFitnessExporter.Serialize();
        }

        public void ImportXML(string FileName)
        {
            xmlMyFitnessImporter = new XMLMyFitnessImporter(ref MyFitnesses, FileName);
            MyFitnesses= xmlMyFitnessImporter.DeSerialize();
        }
    }
}

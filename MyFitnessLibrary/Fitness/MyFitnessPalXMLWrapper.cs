using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFitnessLibrary.Network;
using MyFitnessLibrary.XML;
using MyFitnessLibrary.Graphing;
using System.Drawing;

namespace MyFitnessLibrary.Fitness
{
    public class MyFitnessPalXMLWrapper : MyFitnessLibrary.Fitness.IMyFitnessPalWrapper
    {

        public LoadConfig config { get; set; }
        public LoginDetails loginDetails { get; set; }
        public Login login { get; set; }
        private IMyFitnessLoader Loader { get; set; }
        public int Days { get; private set; }
        private MyFitnessList myFitnessList;

        public MyFitnessList MyFitnesses
        {
            get { return myFitnessList; }
            private set { myFitnessList = value; }
        }
        private IMyFitnessExporter MyFitnessExporter;
        private IMyFitnessImporter MyFitnessImporter;

        private IGraphWrapper graphWrapper;
        public IGraphWrapper Graph { get { return graphWrapper; } }

 

        public MyFitnessPalXMLWrapper(string ConfigFileName, int Days, IGraphWrapper graphWrapper)
        {

            config = new LoadConfig(ConfigFileName);
            loginDetails = (LoginDetails)config.GetContents(typeof(LoginDetails));
            login = new Login(loginDetails);
            Loader = new XMLMyFitnessLoader(login);
            MyFitnesses = new MyFitnessList();
            this.graphWrapper = graphWrapper;
            this.Days = Days;
           
        }

        public void LoadValues()
        {
            Loader.LoadValues(Days, ref myFitnessList);
        }

        public void Export(string FileName)
        {
            MyFitnessExporter = new XMLMyFitnessExporter(MyFitnesses, FileName);
            MyFitnessExporter.Serialize();
        }

        public void Import(string FileName)
        {
            MyFitnessImporter = new XMLMyFitnessImporter(ref myFitnessList, FileName);
            MyFitnesses= MyFitnessImporter.DeSerialize();
        }

        


    }
}
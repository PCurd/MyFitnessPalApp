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
using System.IO;

namespace MyFitnessPalApp
{
    public partial class Form1 : Form
    {
        private LoginDetails loginDetails;
        private Login login;
        LoadConfig config = new LoadConfig(@"ConfigFile.xml");

        MyFitnessList MyFitnesses;

        public Form1()
        {
            InitializeComponent();
            loginDetails = (LoginDetails)config.GetContents(typeof(LoginDetails));
            login = new Login(loginDetails);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            UpdateForm();

         }

        private void DoUpdate()
        {
            if (MyFitnesses==null)
                MyFitnesses = new MyFitnessList();
            CreateSomeXMLFitnesses();


            UpdateForm();

        }

        private void UpdateForm()
        {
            string Output = "";
            if (MyFitnesses == null)
            {
                return;
            }

            foreach (MyFitness value in MyFitnesses.Values)
            {
                string LineItem = value.ToString() + Environment.NewLine;
                Output += LineItem;

            }
            textBox1.Text = Output;
        }


        //**TODO Should be in library
        void CreateSomeXMLFitnesses()
        {
            XMLMyFitnessLoader loader = new XMLMyFitnessLoader(login);

            int Days = 14;

            foreach (var MyFitnessStat in Enum.GetValues(typeof(MyFitnessStatType)).Cast<MyFitnessStatType>())
            {
                loader.GetValue(MyFitnessStat, MyFitnesses.Values, Days);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XMLMyFitnessExporter xmlMyFitnessExporter = new XMLMyFitnessExporter(MyFitnesses,"xmlout.xml");
            textBox2.Text = "XML Serialisation Starting";
            xmlMyFitnessExporter.Serialize();
        }

        private void btnUpdateValues_Click(object sender, EventArgs e)
        {
            DoUpdate();
        }

        private void btnShowValues_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void btnDeSerialize_Click(object sender, EventArgs e)
        {
            XMLMyFitnessImporter xmlMyFitnessImporter = new XMLMyFitnessImporter(ref MyFitnesses, "xmlout.xml");

            textBox2.Text = "XML DeSerialisation Starting";

            MyFitnesses = xmlMyFitnessImporter.DeSerialize();
        }
    }
}

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
        MyFitnessList MyFitnesses;

        public Form1()
        {
            InitializeComponent();
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


        void CreateSomeXMLFitnesses()
        {
            XMLMyFitnessLoader loader = new XMLMyFitnessLoader(new Login("****", "****"));

            int Days = 14;

            foreach (var MyFitnessStat in Enum.GetValues(typeof(MyFitnessStatType)).Cast<MyFitnessStatType>())
            {
                loader.GetValue(MyFitnessStat, MyFitnesses.Values, Days);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TextWriter tw = File.CreateText("xmlout.xml"))
            {
                textBox2.Text = "XML Serialisation Starting";
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(MyFitnessList));
                x.Serialize(tw, MyFitnesses);
                
            }

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
            using (TextReader tr = File.OpenText("xmlout.xml"))
            {
                textBox2.Text = "XML DeSerialisation Starting";
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(MyFitnessList));
                MyFitnesses=(MyFitnessList)x.Deserialize(tr);

            }
        }
    }
}

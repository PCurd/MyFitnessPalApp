using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyFitnessLibrary.ExtensionMethods;
using MyFitnessLibrary.Fitness;
//using MyFitnessLibrary.XML;
//using MyFitnessLibrary.Network;
using MyFitnessLibrary.Graphing;
using System.IO;

namespace MyFitnessPalApp
{
    public partial class Form1 : Form
    {
        private string XMLOutFile = @"xmlout.xml";

        private IMyFitnessPalWrapper MyFitness;
        private IMyFitnessPalConfig MyFitnessPalConfig;
        public Form1()
        {
            InitializeComponent();
            MyFitnessPalConfig = new MyFitnessPalConfigXMLGoogleChart(14);
            MyFitness = MyFitnessPalConfig.MyFitnessPal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void DoUpdate()
        {
            MyFitness.LoadValues();
            UpdateForm();
        }

        private void UpdateForm()
        {
            string Output = "";

            foreach (MyFitness value in MyFitness.MyFitnesses.Values)
            {
                string LineItem = value.ToString() + Environment.NewLine;
                Output += LineItem;

            }
            textBox1.Text = Output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "XML Serialisation Starting";
            MyFitness.Export(XMLOutFile);
        }

        private void btnUpdateValues_Click(object sender, EventArgs e)
        {
            DoUpdate();
        }

        private void btnShowValues_Click(object sender, EventArgs e)
        {
            UpdateForm();

            PBGraph.Image = MyFitness.GetCaloriesComparisonBarGraph();
        }

        private void btnDeSerialize_Click(object sender, EventArgs e)
        {
            textBox2.Text = "XML DeSerialisation Starting";
            MyFitness.Import(XMLOutFile);
        }
    }
}

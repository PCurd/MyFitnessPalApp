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
    public class XMLMyFitnessExporter : MyFitnessLibrary.XML.IMyFitnessExporter
    {

        private string _FileName;
        private MyFitnessList _MyFitnesses;
        public XMLMyFitnessExporter(MyFitnessList MyFitnesses, string FileName)
        {
            this._MyFitnesses = MyFitnesses;
            this._FileName = FileName;
        }

        public void Serialize()
        {
            using (TextWriter tw = File.CreateText(_FileName))
            {

                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_MyFitnesses.GetType());
                x.Serialize(tw, _MyFitnesses);

            }
        }
    }
}

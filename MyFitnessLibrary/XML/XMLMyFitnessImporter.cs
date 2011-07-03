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
    public class XMLMyFitnessImporter
    {
        private string _FileName;
        private MyFitnessList _MyFitnesses;
        public XMLMyFitnessImporter(ref MyFitnessList MyFitnesses, string FileName)
        {
            this._MyFitnesses = MyFitnesses;
            this._FileName = FileName;
        }

        public MyFitnessList DeSerialize()
        {
            using (TextReader tr = File.OpenText(_FileName))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(MyFitnessList));
                return (MyFitnessList)x.Deserialize(tr);

            }
        }
    }
}

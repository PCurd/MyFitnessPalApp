using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace MyFitnessLibrary.XML
{
    public class LoadConfig
    {

        public LoadConfig(string ConfigFile)
        {
            this.ConfigFile = ConfigFile;
        }

        string ConfigFile;


        public object GetContents( Type ReturnType)
        {

            //using (TextWriter tw = File.CreateText("xmlout.xml"))
            //{
            //    textBox2.Text = "XML Serialisation Starting";
            //    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(MyFitnessList));
            //    x.Serialize(tw, MyFitnesses);

            //}

            using (TextReader tr = File.OpenText(ConfigFile))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ReturnType);
                return x.Deserialize(tr);

            }
        }

    }
}

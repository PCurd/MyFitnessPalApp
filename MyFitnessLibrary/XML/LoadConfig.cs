using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace MyFitnessLibrary.XML
{
    public class LoadConfig
    {
        string ConfigFile;

        public LoadConfig(string ConfigFile)
        {
            this.ConfigFile = ConfigFile;
        }

        public object GetContents( Type ReturnType)
        {

            using (TextReader tr = File.OpenText(ConfigFile))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ReturnType);
                return x.Deserialize(tr);

            }
        }

        public void Serialize(Type ReturnType, object obj)
        {
            using (TextWriter tw = File.CreateText(ConfigFile))
            {

                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ReturnType);
                x.Serialize(tw, obj);

            }
        }
        public void BinarySerialize(Type ReturnType, object obj)
        {
            var formatter = new SoapFormatter();

            using (Stream s = File.Create(ConfigFile + ".dat"))
                formatter.Serialize(s, obj);
        }

        public object BinaryDeserialize(Type ReturnType)
        {
            var formatter = new SoapFormatter();

            if (File.Exists(ConfigFile + ".dat"))
            {
                using (Stream s = File.OpenRead(ConfigFile + ".dat"))
                    return formatter.Deserialize(s);

            }
            else
                return Activator.CreateInstance(ReturnType);
        }
    }
}

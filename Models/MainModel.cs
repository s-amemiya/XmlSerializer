using System;
using System.IO;
using System.Xml.Serialization;
using XmlSerializerTest.Entities;

namespace XmlSerializerTest.Models
{
    public class MainModel
    {
        #region Private members

        private void WaitForPressAnyKey()
        {
            Console.Write("press any key to return.");
            Console.ReadKey();
        }

        private Configuration DeserializeConfigurationFromXml(string xmlFilePath)
        {
            if (string.IsNullOrEmpty(xmlFilePath)) { return null; }
            if (!File.Exists(xmlFilePath)) { return null; }

            using (var fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(Configuration));
                return serializer.Deserialize(fs) as Configuration;
            }
        }

        private void WriteToConsole(Configuration configuration)
        {
            foreach (var fruit in configuration.Fruits)
            {
                Console.WriteLine(fruit.Id + ": " + fruit.Name);
            }
        }

        #endregion

        #region Public members

        public void Run()
        {
            var xmlFilePath = "Configuration.xml";
            var configuration = DeserializeConfigurationFromXml(xmlFilePath);
            if (configuration == null)
            {
                Console.WriteLine("not deserialized.");
                WaitForPressAnyKey();
                return;
            }

            WriteToConsole(configuration);
            WaitForPressAnyKey();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class XmlTransformer
    {
        string _filePath;
        public bool isValid;

        public XmlTransformer(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath), "argument should not be null");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("file ${filePath} not found");
            _filePath = filePath;
        }
        public void Validate(string xsdFilePath)
        {
            isValid = true;
            if (xsdFilePath == null)
                throw new ArgumentNullException(nameof(xsdFilePath), "argument should not be null");
            if (!File.Exists(xsdFilePath))
                throw new FileNotFoundException("file ${xsdFilePath} not found");

            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add("", xsdFilePath);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += XmlValidationEventHandler;
            using (var reader = XmlReader.Create(_filePath, xmlReaderSettings))
            {
                while (reader.Read()) ;
            }
        }
        void XmlValidationEventHandler(object sender, ValidationEventArgs args)
        {
            isValid = false;
        }
        public string Transform(string xsltFilePath)
        {
            if (xsltFilePath == null)
                throw new ArgumentNullException(nameof(xsltFilePath), "argument should not be null");
            if (!File.Exists(xsltFilePath))
                throw new FileNotFoundException("file ${xsltFilePath} not found");
            
            var xslt = new XslCompiledTransform();
            using (var xr = XmlReader.Create(xsltFilePath))
            {
                xslt.Load(xr);
            }
            var result = String.Empty;

            using (var xr = XmlReader.Create(_filePath))
            {
                using (var sw = new StringWriter())
                {
                    xslt.Transform(xr, null, sw);
                    result = sw.ToString();
                }
            }
            return result;
        }
    }
}


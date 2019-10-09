﻿using System;
using System.IO;
using System.Text;
using ValidateXmlFileUseXsdSchemaPoC.Interfaces;
using ValidateXmlFileUseXsdSchemaPoC.Services;

namespace ValidateXmlFileUseXsdSchemaPoC
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileDirectory = @"TEST\";
            string[] fileXml = Directory.GetFiles(FileDirectory);
            var xsd = File.ReadAllText(@"Assets\Schemat_JPK_VAT(3)_v1-1.xsd");

            IXmlFileValidation saxon = new SaxonValidate();
            IXmlFileValidation xmlValidate = new XmlDocumentValidate();

            foreach (string file in fileXml)
            {
                var xml = File.ReadAllText(file, Encoding.UTF8);
                Console.WriteLine($"saxon- {file} => {saxon.Validate(xml, xsd)}");
                Console.WriteLine($"{file} => {xmlValidate.Validate(xml, xsd)}");
            }
            Console.ReadKey();
        }
    }
}

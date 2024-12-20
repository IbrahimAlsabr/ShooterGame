using System;
using System.Collections.Generic;

public class XMLValidationTest
{
    public bool Run()
    {
        bool filesAreValid = true;

        var filesToValidate = new List<(string xmlPath, string xsdPath)>
        {
            ("Data/XML/GameSaves.xml", "Data/XSD/GameSaves.xsd"),
            ("Data/XML/GameConfig.xml", "Data/XSD/GameConfig.xsd"),
            ("Data/XML/PlayerProfile.xml", "Data/XSD/PlayerProfile.xsd")
        };

        foreach (var (xmlPath, xsdPath) in filesToValidate)
        {
            Console.WriteLine($"Validation de {xmlPath} avec {xsdPath} :");

            bool isValid = XmlValidator.ValidateSchema(xmlPath, xsdPath);

            if (isValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Validation Passed!");
                Console.ResetColor();
            }
            else
            {
                filesAreValid = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Validation Failed!");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        return filesAreValid;
    }
}
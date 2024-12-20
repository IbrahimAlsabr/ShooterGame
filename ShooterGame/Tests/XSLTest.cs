using System;
using System.IO;
using System.Collections.Generic;

public class XSLTest
{
    public void Run()
    {
        bool filesAreValid = true;

        var filesToValidate = new List<(string xmlPath, string xsdPath, string htmlPath)>
        {
            ("Data/XML/PlayerProfile.xml", "Data/XSLT/PlayerGameList.xsl", "Data/HTML/PlayerGameList.html"),
            ("Data/XML/PlayerProfile.xml", "Data/XSLT/PlayerProfile.xsl", "Data/HTML/PlayerProfile.html"),
            ("Data/XML/GameSaves.xml", "Data/XSLT/PlayerGameList.xsl", "Data/HTML/PlayerGameList.html"),
            ("Data/XML/GameSaves.xml", "Data/XSLT/HiScores.xsl", "Data/HTML/HiScores.html")
        };

        foreach (var (xmlPath, xsltPath, htmlPath) in filesToValidate)
        {
            Console.WriteLine($"Tranformation de {xmlPath} to {htmlPath} :");
            XmlTransformer.XslTransform(xmlPath, xsltPath, htmlPath);
            Console.WriteLine();
        }
    }
}
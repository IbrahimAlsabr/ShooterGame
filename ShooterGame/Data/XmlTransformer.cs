using System;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;

public static class XmlTransformer
{
    public static void XslTransform(string xmlFilePath, string xsltFilePath, string htmlFilePath)
    {
        string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
        xmlFilePath = Path.Combine(projectRoot, "..", "..", "..", xmlFilePath);
        xsltFilePath = Path.Combine(projectRoot, "..", "..", "..", xsltFilePath);
        htmlFilePath = Path.Combine(projectRoot, "..", "..", "..", htmlFilePath);


        XPathDocument xpathDoc = new XPathDocument(xmlFilePath);
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(xsltFilePath);
        using (XmlWriter htmlWriter = XmlWriter.Create(htmlFilePath, new XmlWriterSettings { Indent = true }))
        {
            xslt.Transform(xpathDoc, null, htmlWriter);
            Console.WriteLine($"Transformation completed. Output written to {htmlFilePath}");
        }
    }
}
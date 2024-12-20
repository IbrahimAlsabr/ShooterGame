using System;
using System.Xml;
using System.Xml.Schema;

public static class XmlValidator
{
    public static bool ValidateSchema(string xmlPath, string xsdPath)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(xmlPath);
        xml.Schemas.Add(null, xsdPath);

        try
        {
            xml.Validate(null);
        }
        catch (XmlSchemaValidationException)
        {
            return false;
        }

        return true;
    }
}
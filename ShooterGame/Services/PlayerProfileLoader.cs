namespace ShooterGame.Services;

using System;
using System.Xml;
using System.Xml.XPath;

public class PlayerProfileLoader
{
    private XmlDocument doc;
    private XPathNavigator navigator;
    private string filePath = "Data/XML/PlayerProfile.xml";

    public PlayerProfileLoader()
    {
        doc = new XmlDocument();
        doc.Load(filePath);
        navigator = doc.CreateNavigator();
    }

    public String GetPlayerName() => navigator.SelectSingleNode("/PlayerProfile/PlayerName")?.Value;
    public String GetLastLevel() => navigator.SelectSingleNode("/PlayerProfile/LastLevel")?.Value;
    public String GetLastScore() => navigator.SelectSingleNode("/PlayerProfile/LastScore")?.Value;
    public String GetLastPlayed() => navigator.SelectSingleNode("/PlayerProfile/LastPlayed")?.Value;

    public void DisplayData()
    {
        Console.WriteLine($"Nom du joueur : {GetPlayerName()}");
        Console.WriteLine($"Dernier niveau joué : {GetLastLevel()}");
        Console.WriteLine($"Dernier score : {GetLastScore()}");
        Console.WriteLine($"Dernière date de jeu : {GetLastPlayed()}");
    }

    private void UpdateSpecificNode(string nodeName, string newValue)
    {
        XmlNode node = doc.SelectSingleNode($"/PlayerProfile/{nodeName}");
        if (node != null)
        {
            node.InnerText = newValue;
            doc.Save(filePath);
            Console.WriteLine($"Updated {nodeName} to {newValue}.");
        }
        else
        {
            Console.WriteLine($"Node {nodeName} not found.");
        }
    }

    public void UpdateLastScore(string newValue)
    {
        UpdateSpecificNode("LastScore", newValue);
    }

    public void UpdateLastLevel(string newValue)
    {
        UpdateSpecificNode("LastLevel", newValue);
    }

    public void UpdateLastPlayed(string newValue)
    {
        UpdateSpecificNode("LastPlayed", newValue);
    }

    public void UpdatePlayerName(string newValue)
    {
        UpdateSpecificNode("PlayerName", newValue);
    }
}
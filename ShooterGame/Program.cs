using System;

// ========================================================
//                 XML VALIDATION USING XSD
// ========================================================

Console.WriteLine("---------------------------------------");
Console.WriteLine("---- STARTING XML FILE VALIDATION ----");
Console.WriteLine("---------------------------------------");

// Validate the XML file using the associated XSD schema
var xmlValidator = new XMLValidationTest();
var isXmlValid = xmlValidator.Run();

// ========================================================
//                XML TO HTML TRANSFORMATION
// ========================================================

Console.WriteLine("------------------------------------------");
Console.WriteLine("---- STARTING XML FILE TRANSFORMATION ----");
Console.WriteLine("------------------------------------------");

// Transform the XML file to HTML format using XSLT
var xmlTransformer = new XSLTest();
xmlTransformer.Run();

// ========================================================
//                 GAME LAUNCH (IF VALID)
// ========================================================

if (isXmlValid)
{
    Console.WriteLine("XML Validation Passed - Proceeding to Launch Game...");
    // Uncomment the lines below to launch the game
    using var game = new ShooterGame.Game1();
    game.Run();
}
else
{
    Console.WriteLine("XML Validation Failed - Game Launch Aborted.");
}
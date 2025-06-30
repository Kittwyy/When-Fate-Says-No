using System;
using System.Threading;

public static class GameHelper
{
    // Diese Methode ist jetzt öffentlich und statisch,
    // sodass wir sie von jeder anderen Klasse aus mit GameHelper.TypeText(...) aufrufen können.
    
    public static void DisplayHopeStatus()
    {
        string statusText = "";
        if (Program.hopeLevel >= 3)
        {
            statusText = "A tiny flicker of warmth spreads through your chest. It's unfamiliar.";
        }
        else if (Program.hopeLevel <= -3)
        {
            statusText = "The familiar, heavy cloak of despair settles on your shoulders.";
        }
        // Man könnte hier noch mehr Stufen einbauen.
    
        if (!string.IsNullOrEmpty(statusText))
        {
            Console.WriteLine();
            TypeText(statusText);
        }
    }
    public static void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            if (c == '.' || c == '?' || c == '!' || c == ',')
            {
                Thread.Sleep(300); // Längere Pause bei Satzzeichen
            }
            else
            {
                Thread.Sleep(5); // Etwas schnellere Tipp-Geschwindigkeit
            }
        }
        Console.WriteLine();
    }
}
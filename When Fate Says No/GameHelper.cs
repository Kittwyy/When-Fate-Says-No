using System;
using System.Threading;

public static class GameHelper
{
    // Diese Methode ist jetzt öffentlich und statisch,
    // sodass wir sie von jeder anderen Klasse aus mit GameHelper.TypeText(...) aufrufen können.
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
                Thread.Sleep(35); // Etwas schnellere Tipp-Geschwindigkeit
            }
        }
        Console.WriteLine();
    }
}
using System;

public class TrainTracksScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("You arrive at the train tracks. The metal hums with a distant promise.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to the main menu for now.");
        Console.ReadLine();
        // An dieser Stelle würde man zum Hauptmenü zurückkehren oder das Spiel beenden.
        // Vorerst kehren wir einfach aus der Methode zurück.
    }
}
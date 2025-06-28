using System;

public class BridgeScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("The old bridge groans under your weight. The river below is dark and cold.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to the main menu for now.");
        Console.ReadLine();
    }
}
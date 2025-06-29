using System;

public class WaitInBedScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You lie down. The pain in your ankle is a constant, nagging presence.");
        GameHelper.TypeText("There is nothing to do but stare at the ceiling and wait.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to your room's options.");
        Console.ReadLine();
        new RoomScene().Load();
    }
}
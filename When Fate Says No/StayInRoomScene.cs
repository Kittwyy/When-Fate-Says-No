using System;

public class StayInRoomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("You stay. The walls seem to close in. The silence is deafening.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to the main menu for now.");
        Console.ReadLine();
    }
}
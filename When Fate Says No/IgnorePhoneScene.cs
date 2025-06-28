using System;

public class IgnorePhoneScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("You stare at the phone, letting each ring echo in the suffocating silence.");
        Console.WriteLine("After the tenth ring, it stops. The silence that returns is somehow heavier than before.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to the main menu for now.");
        Console.ReadLine();
    }
}
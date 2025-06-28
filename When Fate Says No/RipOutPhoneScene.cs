using System;

public class RipOutPhoneScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("With a surge of adrenaline, you tear the phone cord from the wall socket.");
        Console.WriteLine("The ringing is cut short. You stand, breathing heavily, holding the severed cord.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to the main menu for now.");
        Console.ReadLine();
    }
}
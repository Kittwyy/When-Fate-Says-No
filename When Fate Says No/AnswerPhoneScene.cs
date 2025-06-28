using System;

public class AnswerPhoneScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("Your hand trembles as you pick up the receiver. You bring it to your ear.");
        Console.WriteLine("A faint, crackling voice, barely a whisper, says a name you haven't heard in a long time.");
        Console.WriteLine("(The story continues here...)");
        Console.WriteLine("\nPress Enter to return to the main menu for now.");
        Console.ReadLine();
    }
}
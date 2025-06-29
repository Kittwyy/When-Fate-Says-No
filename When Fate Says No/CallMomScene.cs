using System;
using System.Threading;

public class CallMomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("With a deep breath that doesn't quite fill your lungs, you dial the familiar number.");
        GameHelper.TypeText("It rings twice. You almost hang up.");
        GameHelper.TypeText("Then, her voice. 'Hello?'");
        GameHelper.TypeText("'Hi, Mom. It's me.'");
        GameHelper.TypeText("A pause. You can hear her relief. 'Oh, honey. I'm so glad you called. How are you?'");
        GameHelper.TypeText("You consider lying. You consider saying 'fine'. But you don't.");
        GameHelper.TypeText("'Not... not great, Mom.'");
        GameHelper.TypeText("The silence on the other end is different this time. Not confusion. Just... listening.");
        GameHelper.TypeText("'Okay,' she says softly. 'Okay, honey. Thank you for telling me. Is there anything...?'");
        GameHelper.TypeText("She trails off, not knowing what to offer. You don't know what to ask for.");
        GameHelper.TypeText("'I just... wanted to call,' you say.");
        GameHelper.TypeText("'I'm glad you did,' she replies, and you can tell she means it. 'I love you.'");
        GameHelper.TypeText("The call ends a few moments later. Nothing is fixed. But for the first time in a long time, you don't feel entirely alone.");

        // Ein schwieriger, aber positiver Schritt, der viel Hoffnung gibt.
        Program.ChangeHope(2);
        // Wir setzen den Zustand, dass der Anruf getätigt wurde.
        Program.momHasBeenCalled = true;
        Console.WriteLine($"\n[STATE UPDATE: Hope increased to {Program.hopeLevel}. You have now called your mom.]");

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();

        // Kehre zurück in den Raum.
        new RoomScene().Load();
    }
}
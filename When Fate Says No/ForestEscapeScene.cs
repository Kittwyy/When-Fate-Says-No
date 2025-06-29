using System;

public class ForestEscapeScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You plunge into the treeline, the darkness swallowing you whole.");
        GameHelper.TypeText("Branches whip at your face. A root catches your foot and you go down hard.");
        GameHelper.TypeText("A sharp pain shoots up your ankle. It's twisted, maybe broken.");
        
        // HIER SETZEN WIR DEN NEUEN ZUSTAND
        Program.isInjured = true;
        Console.WriteLine("\n[STATE UPDATE: You are now injured.]"); // Debug-Nachricht

        GameHelper.TypeText("The sounds of the chase fade behind you, replaced by the sound of your own ragged breathing.");
        GameHelper.TypeText("You drag yourself through the woods for what feels like hours, until you finally collapse against your own front door.");

        Console.WriteLine("\nPress Enter to go inside...");
        Console.ReadLine();

        // Anstatt das Spiel zu beenden, kehren wir zurück in den Startraum.
        new RoomScene().Load();
    }
}
using System;

public class PoliceLeavesScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("The officer studies your face for a long moment. You hold your breath.");
        GameHelper.TypeText("'Alright,' he finally says. 'It's late to be out admiring the view. Be safe now.'");
        GameHelper.TypeText("He nods, gets back in his car, and drives away, leaving you alone once more in the quiet darkness.");
        GameHelper.TypeText("The opportunity is gone. The place feels tainted now.");

        // Setze den neuen Zustand
        Program.bridgeIsBlocked = true;
        Console.WriteLine("\n[STATE UPDATE: The bridge is now a blocked option.]");

        Console.WriteLine("Press Enter to walk home...");
        Console.ReadLine();

        // Kehre zurück in den Startraum
        new RoomScene().Load();
    }
}
using System;

public class RideHomeScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("The officer's expression softens slightly. 'I get it. We all have those weeks.'");
        GameHelper.TypeText("'But this isn't the place for it. Come on, how about I give you a ride home? No fuss.'");
        GameHelper.TypeText("You hesitate, but nod. The fight has gone out of you.");
        GameHelper.TypeText("The ride home is silent. He drops you off at your door. 'Take care of yourself,' he says, and then he's gone.");
        GameHelper.TypeText("You can't go back there now. He'd recognize you.");

        // Setze den neuen Zustand
        Program.bridgeIsBlocked = true;
        Console.WriteLine("\n[STATE UPDATE: The bridge is now a blocked option.]");

        Console.WriteLine("Press Enter to go inside...");
        Console.ReadLine();
        
        // Kehre zurück in den Startraum
        new RoomScene().Load();
    }
}
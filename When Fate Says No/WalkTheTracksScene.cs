using System;

public class WalkTheTracksScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You step off the platform and onto the gravel of the track bed.");
        GameHelper.TypeText("You start walking, leaving the dim lights of the station behind. The world is just the crunch of gravel under your feet.");
        GameHelper.TypeText("After a while, you hear a faint whimpering sound from the bushes beside the tracks.");
        GameHelper.TypeText("You stop. You listen. It comes again, small and pathetic.");
        GameHelper.TypeText("Curiosity, an emotion you haven't felt in a long time, pulls you towards the sound.");
        GameHelper.TypeText("Huddled in the bushes is a small, shivering dog, its leash tangled in the thorns. It has a collar, but looks lost.");
        GameHelper.TypeText("It looks up at you with wide, terrified eyes. It doesn't bark. It just shivers.");
        GameHelper.TypeText("You can't just leave it here. For the first time all night, your own problems feel... distant.");
        
        Program.ChangeHope(3); 
        Program.hasDog = true;
        Console.WriteLine("\n[STATE UPDATE: You found a dog! Hope significantly increased.]");

        Console.WriteLine("\nPress Enter to untangle the leash and take the dog with you...");
        Console.ReadLine();

        new RoomScene().Load();
    }
}
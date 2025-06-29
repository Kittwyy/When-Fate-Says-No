using System;
using System.Threading;

public class WaitForNextTrainScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You sit back down on the cold bench, a stubborn resolve setting in.");
        GameHelper.TypeText("No. Waiting isn't enough. You need certainty.");
        GameHelper.TypeText("You step off the platform and lie down on the cold, unforgiving steel of the tracks. The vibrations of the world run through you.");
        GameHelper.TypeText("This time, there is no escape.");
        Thread.Sleep(2000);

        GameHelper.TypeText("...until the same crackly voice from the speaker echoes across the empty station.");
        GameHelper.TypeText("\"Attention. The 11:32 PM service has also been cancelled. All services are suspended for the night.\"");
        GameHelper.TypeText("Suspended. The word hangs in the air. You feel nothing. Not anger, not sadness. Just... empty.");
        GameHelper.TypeText("Slowly, you get up and sit back on the bench. The tracks are just cold, dead metal now.");

        Console.WriteLine();
        Console.WriteLine("The station is a tomb. What now?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Walk along the tracks, away from here.");
        Console.WriteLine("2. Go home. Defeated.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                nextScene = new WalkTheTracksScene();
                break;
            case "2":
                Program.ChangeHope(-1);
                nextScene = new RoomScene();
                break;
            default:
                nextScene = this;
                break;
        }
        nextScene.Load();
    }
}
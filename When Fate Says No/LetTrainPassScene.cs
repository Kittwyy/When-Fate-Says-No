using System;

public class LetTrainPassScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("At the last second, something makes you step back from the yellow line.");
        GameHelper.TypeText("The train screams past, a violent rush of wind and noise that shakes you to your core.");
        GameHelper.TypeText("And then, just as quickly, it's gone. Leaving only silence in its wake.");
        GameHelper.TypeText("You stand there, breathing heavily. You are still here.");
        
        Console.WriteLine($"\n[STATE UPDATE: Hope is now at maximum ({Program.hopeLevel})!]");
        Console.WriteLine("\nPress Enter to walk home...");
        Console.ReadLine();
        
        new RoomScene().Load();
    }
}
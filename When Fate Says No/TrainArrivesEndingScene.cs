using System;

public class TrainArrivesEndingScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You close your eyes and take the final step.");
        GameHelper.TypeText("A deafening horn. A flash of white light.");
        GameHelper.TypeText("And then... silence.");

        Console.WriteLine("\n\n--- WIN - You died... ---");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
using System;

public class BathtubEndingScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("The water runs cold against your skin.");
        GameHelper.TypeText("There is no hesitation.");
        GameHelper.TypeText("Just a final, quiet decision.");
        GameHelper.TypeText("The water slowly turns crimson.");
        GameHelper.TypeText("And then... everything stops.");

        Console.WriteLine("\n\n--- WIN - You died... ---");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
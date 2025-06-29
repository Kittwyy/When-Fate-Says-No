using System;

public class RunFromPoliceScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("Panic takes over. You start running along the narrow ledge of the bridge.");
        GameHelper.TypeText("You hear a shout behind you, but you don't look back.");
        GameHelper.TypeText("You reach the end of the bridge, your lungs burning. You have a split-second to decide.");
        Console.WriteLine();
        Console.WriteLine("Where do you run?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Into the darkness of the forest.");
        Console.WriteLine("2. Try to lose them in the city streets.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                nextScene = new ForestEscapeScene();
                break;
            case "2":
                nextScene = new CityChaseScene();
                break;
            default:
                // Wenn man in Panik eine falsche Entscheidung trifft, stolpert man...
                GameHelper.TypeText("You hesitate for too long...");
                nextScene = new CityChaseScene(); // und wird in die Stadt getrieben.
                break;
        }

        nextScene.Load();
    }
}
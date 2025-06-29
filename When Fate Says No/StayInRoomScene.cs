using System;

public class StayInRoomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("You stay. The walls seem to close in. The silence is deafening.");
        Console.WriteLine("Time stretches and thins into a meaningless thread.");
        Console.WriteLine("...");
        Console.WriteLine("...and then, a sound. A piercing, artificial shriek.");
        Console.WriteLine("It's the old landline phone on the wall. A phone that hasn't rung in years.");
        Console.WriteLine("It rings again, insistent.");
        Console.WriteLine();
        Console.WriteLine("What do you do?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Answer it. Who could it possibly be?");
        Console.WriteLine("2. Ignore it. Let it ring until it gives up.");
        Console.WriteLine("3. Rip the cord from the wall. Enforce the silence.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                Program.hopeLevel++; // Das Annehmen des Anrufs gibt einen Hoffnungspunkt.
                nextScene = new AnswerPhoneScene();
                break;
            case "2":
                Program.hopeLevel--; // Das Ignorieren senkt die Hoffnung.
                nextScene = new IgnorePhoneScene();
                break;
            case "3":
                Program.hopeLevel -= 2; // Eine aggressive, verzweifelte Tat senkt die Hoffnung stark.
                nextScene = new RipOutPhoneScene();
                break;
            default:
                nextScene = this; 
                break;
        }
        nextScene.Load();
    }
}
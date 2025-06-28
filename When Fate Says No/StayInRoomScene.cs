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
                nextScene = new AnswerPhoneScene(); // Erstelle die "Annehmen"-Szene
                break;
            case "2":
                nextScene = new IgnorePhoneScene(); // Erstelle die "Ignorieren"-Szene
                break;
            case "3":
                nextScene = new RipOutPhoneScene(); // Erstelle die "Kabel-rausreißen"-Szene
                break;
            default:
                nextScene = this; // Lade die Szene neu bei ungültiger Eingabe
                break;
        }
        
        nextScene.Load();
    }
}
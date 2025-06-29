using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static List<string> DiaryEntries = InitializeDiary();

    public static int hopeLevel = 0;
    public static bool isInjured = false;
    public static bool bridgeIsBlocked = false;
    public static bool hasDog = false;
    public static bool momHasBeenCalled = false;
    public static bool trainTracksVisited = false;
    
    // FUck you Cookie! Now I have to add Limits!
    public const int MaxHope = 5;
    public const int MinHope = -5;

    public static List<string> Inventory = new List<string>();
    private static List<string> InitializeDiary()
    {
        // 1. Lade die vordefinierten Lore-Einträge
        var entries = new List<string>(DiaryLore.GetPrewrittenEntries());

        // 2. Prüfe, ob eine Speicherdatei existiert und lade Spieler-Einträge
        if (File.Exists("diary.txt"))
        {
            entries.AddRange(File.ReadAllLines("diary.txt"));
        }

        return entries;
    }

    
    // Die Methode muss public und static sein, damit sie von überall aufgerufen werden kann.
    public static void ChangeHope(int amount)
    {
        hopeLevel += amount;

        // Stelle sicher, dass der Wert die Grenzen nicht überschreitet.
        if (hopeLevel > MaxHope)
        {
            hopeLevel = MaxHope;
        }
        else if (hopeLevel < MinHope)
        {
            hopeLevel = MinHope;
        }
    }
    static void Main(string[] args)
    {
        // Das Hauptmenü bleibt wie es war.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("      When Fate Says No");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Options");
            Console.WriteLine("3. Quit");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    ShowOptions();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid input. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void StartGame()
    {
        IScene startingScene = new RoomScene();
        startingScene.Load();
    }
    
    static void ShowOptions()
    {
        Console.Clear();
        Console.WriteLine("Options are not yet implemented.");
        Console.WriteLine("\nPress Enter to return to the main menu.");
        Console.ReadLine();
    }
}
using System;

class Program
{
    
    public static List<string> DiaryEntries = new List<string>(DiaryLore.GetPrewrittenEntries());
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
        // Erstelle eine Instanz unserer Start-Szene und lade sie.
        // Das ist der einzige Einstiegspunkt in unsere Geschichte.
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
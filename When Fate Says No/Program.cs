using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

// Die Hauptklasse, die unser gesamtes Spiel ausführt und alle Zustände verwaltet.
public static class Program
{
    // --- Globale Spielzustände ---
    // Werden hier deklariert, um einen Überblick über die geplante Komplexität zu geben.
    public static int hopeLevel = 0;
    public static int currentDay = 1;
    public static bool hasReadDiaryToday = false;
    
    // Zustände, die durch Spieleraktionen verändert werden
    public static bool isInjured = false;
    public static bool hasDog = false;
    
    // Zustände, die Optionen permanent blockieren
    public static bool bridgeIsBlocked = false;
    public static bool trainTracksVisited = false;
    public static bool momHasBeenCalled = false;
    
    // Inventar und Tagebuch
    public static List<string> Inventory = new List<string>();
    public static List<DiaryEntry> DiaryEntries = new List<DiaryEntry>(); // Wird später aus DiaryLore.cs befüllt

    // --- Konstanten für die Spielmechanik ---
    public const int MaxHope = 5;
    public const int MinHope = -5;


    // --- Haupt-Startpunkt der Anwendung ---
    public static void Main(string[] args)
    {
        // 1. Zeige die Trigger-Warnung an, bevor irgendetwas anderes passiert.
        ShowTriggerWarning();

        // 2. Starte die Hauptmenü-Schleife.
        MainMenuLoop();
    }

    // --- Kern-Methoden der Spiel-Logik ---
    
    private static void MainMenuLoop()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("      When Fate Says No");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Options");
            Console.WriteLine("3. Quit");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    ShowOptions();
                    break;
                case "3":
                    Environment.Exit(0); // Beendet das Programm sauber.
                    break;
            }
        }
    }
    
    private static void StartNewGame()
    {
        // Setzt alle Zustände für einen neuen Spieldurchlauf zurück.
        hopeLevel = 0;
        currentDay = 1;
        hasReadDiaryToday = false;
        isInjured = false;
        bridgeIsBlocked = false;
        trainTracksVisited = false;
        momHasBeenCalled = false;
        hasDog = false;
        Inventory.Clear();
        
        // Lädt die Lore-Einträge neu.
        // TODO: Diese Zeile wird erst funktionieren, wenn DiaryLore.cs existiert.
        // DiaryEntries = new List<DiaryEntry>(DiaryLore.GetPrewrittenEntries());

        // Startet die erste Szene des Spiels.
        // TODO: Diese Zeile wird erst funktionieren, wenn RoomScene.cs existiert.
        IScene startingScene = new RoomScene();
        startingScene.Load();
    }

    // --- Helfer-Methoden ---

    public static void ChangeHope(int amount)
    {
        hopeLevel += amount;
        hopeLevel = Math.Clamp(hopeLevel, MinHope, MaxHope);
    }

    public static void AdvanceDay()
    {
        currentDay++;
        hasReadDiaryToday = false; // Setzt das Lese-Limit für den neuen Tag zurück.
        GameHelper.TypeText($"\n[A new day begins. It is Day {currentDay}.]"); // Benötigt GameHelper.cs
        Thread.Sleep(2500);
    }
    
    private static void ShowOptions()
    {
        Console.Clear();
        GameHelper.TypeText("Options are not yet implemented."); // Benötigt GameHelper.cs
        Console.WriteLine("\nPress Enter to return to the main menu.");
        Console.ReadLine();
    }
    
    private static void ShowTriggerWarning()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("TRIGGER WARNING\n");
        Console.ResetColor();
        Console.WriteLine("This game contains direct depictions and themes of suicide, depression,");
        Console.WriteLine("and self-harm which may be distressing to some players.");
        Console.WriteLine("\nPlayer discretion is advised.");
        Console.WriteLine("\n\nPress Enter to acknowledge and continue.");
        Console.ReadLine();
    }
}


// --- Interfaces und Structs (gehören eigentlich in eigene Dateien) ---

// TODO: Diese Definitionen in eigene Dateien auslagern (IScene.cs, DiaryEntry.cs)
public interface IScene
{
    void Load();
}

public struct DiaryEntry
{
    public string Title;
    public string Content;
    public int HopeChange;
}
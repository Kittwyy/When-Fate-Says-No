using System;
using System.Collections.Generic;

public class DiaryScene : IScene
{
    // Die Load-Methode und WriteNewEntry bleiben fast unverändert.
    public void Load()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("The leather-bound diary feels heavy in your hands.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Write a new entry.");
            Console.WriteLine("2. Read entries.");
            Console.WriteLine("3. Close the diary.");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    ReadEntries(); // Diese Methode wird jetzt die Paginierung enthalten
                    break;
                case "3":
                    new RoomScene().Load();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void WriteNewEntry()
    {
        Console.Clear();
        Console.WriteLine("Your thoughts spill onto the page. Press Enter when you are done.");
        Console.Write("> ");
        string newEntry = Console.ReadLine();
        
        // Füge das aktuelle Datum für einen schöneren Eintrag hinzu
        string datedEntry = $"{DateTime.Now.ToString("MMMM dd")}.\n{newEntry}";
        Program.DiaryEntries.Add(datedEntry);

        Console.WriteLine("\nEntry saved. Press Enter to return to the diary.");
        Console.ReadLine();
    }

    // KOMPLETT ÜBERARBEITET: Die Methode zum Lesen mit Seiten-System
    private void ReadEntries()
    {
        // Zuerst prüfen, ob es überhaupt Einträge gibt.
        if (Program.DiaryEntries.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("The pages are empty.");
            Console.WriteLine("\nPress Enter to return to the diary.");
            Console.ReadLine();
            return; // Beende die Methode, wenn es nichts zu lesen gibt.
        }

        int currentPage = 0; // Wir fangen immer auf der ersten Seite (Index 0) an.

        // Diese Schleife läuft, solange der Spieler im Lesemodus ist.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Diary Entry ---");
            Console.WriteLine();
            
            // Zeige den Eintrag der aktuellen Seite an.
            Console.WriteLine(Program.DiaryEntries[currentPage]);
            
            Console.WriteLine();
            Console.WriteLine("-------------------");
            // Zeige die Seitenzahl an. Wir addieren 1, da Menschen bei 1 anfangen zu zählen, Computer bei 0.
            Console.WriteLine($"Page {currentPage + 1} of {Program.DiaryEntries.Count}");
            Console.WriteLine("n = next page | p = previous page | b = back to diary menu");
            Console.Write("Navigate: ");

            string navigation = Console.ReadLine().ToLower(); // .ToLower() macht die Eingabe klein (n, p, b)

            switch (navigation)
            {
                case "n":
                    // Gehe zur nächsten Seite, aber nur, wenn wir nicht schon auf der letzten sind.
                    if (currentPage < Program.DiaryEntries.Count - 1)
                    {
                        currentPage++;
                    }
                    break;
                case "p":
                    // Gehe zur vorigen Seite, aber nur, wenn wir nicht schon auf der ersten sind.
                    if (currentPage > 0)
                    {
                        currentPage--;
                    }
                    break;
                case "b":
                    // Verlasse die Lese-Schleife und kehre zum Tagebuch-Menü zurück.
                    return;
            }
        }
    }
}
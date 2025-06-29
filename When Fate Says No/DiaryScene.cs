using System;
using System.Collections.Generic;
using System.IO;

public class DiaryScene : IScene
{
    public void Load()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"[DEBUG: Current Hope Level is {Program.hopeLevel}]");
            Console.WriteLine();
            Console.WriteLine("The leather-bound diary feels heavy in your hands.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Write a new entry.");
            Console.WriteLine("2. Read past entries.");
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
                    ReadEntries();
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
        
        string datedEntry = $"{DateTime.Now.ToString("MMMM dd")}.\n{newEntry}";
        Program.DiaryEntries.Add(datedEntry);
        
        File.AppendAllText("diary.txt", datedEntry + Environment.NewLine);

        // Das Formulieren von Gedanken kann eine kleine Erleichterung sein.
        Program.hopeLevel++; 
        Console.WriteLine($"\nEntry saved. (Hope increased to {Program.hopeLevel})"); // Die Debug-Anzeige hier ist auch hilfreich.
        Console.WriteLine("Press Enter to return to the diary.");
        Console.ReadLine();
    }

    // Die ReadEntries-Methode bleibt unverändert.
    private void ReadEntries()
    {
        if (Program.DiaryEntries.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("The pages are empty.");
            Console.WriteLine("\nPress Enter to return to the diary.");
            Console.ReadLine();
            return;
        }

        int currentPage = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Diary Entry ---");
            Console.WriteLine();
            Console.WriteLine(Program.DiaryEntries[currentPage]);
            Console.WriteLine();
            Console.WriteLine("-------------------");
            Console.WriteLine($"Page {currentPage + 1} of {Program.DiaryEntries.Count}");
            Console.WriteLine("n = next page | p = previous page | b = back to diary menu");
            Console.Write("Navigate: ");

            string navigation = Console.ReadLine().ToLower();

            switch (navigation)
            {
                case "n":
                    if (currentPage < Program.DiaryEntries.Count - 1)
                    {
                        currentPage++;
                    }
                    break;
                case "p":
                    if (currentPage > 0)
                    {
                        currentPage--;
                    }
                    break;
                case "b":
                    return;
            }
        }
    }
}
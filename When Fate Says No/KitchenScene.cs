using System;
using System.Linq;

public class KitchenScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("The kitchen is clean, almost sterile. A single dirty cup sits by the sink.");
        Console.WriteLine("--------------------------");
        
        // Die Option, das Messer zu nehmen, wird nur angezeigt, wenn man es noch nicht hat.
        if (!Program.Inventory.Contains("Knife"))
        {
            Console.WriteLine("1. Open the cutlery drawer.");
        }
        
        Console.WriteLine("2. Look in the fridge.");
        Console.WriteLine("3. Go back to the living room.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                if (!Program.Inventory.Contains("Knife"))
                {
                    GameHelper.TypeText("You slide the drawer open. Spoons, forks... and a sharp kitchen knife.");
                    GameHelper.TypeText("You take the knife. It feels cold and heavy in your hand.");
                    Program.Inventory.Add("Knife");
                    Console.WriteLine("\n[ITEM ACQUIRED: Knife]");
                }
                else
                {
                    GameHelper.TypeText("You already checked the drawer.");
                }
                break;
            case "2":
                GameHelper.TypeText("You open the fridge. It's mostly empty. A carton of milk, half a lemon. You close it again.");
                break;
            case "3":
                return; // Beendet die Load-Methode und kehrt zur Schleife in StayInRoomScene zurück.
        }
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
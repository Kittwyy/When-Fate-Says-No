using System;
using System.Linq;

public class StayInRoomScene : IScene
{
    public void Load()
    {
        // Diese Schleife sorgt dafür, dass wir immer wieder hierher zurückkehren, nachdem wir einen Raum erkundet haben.
        while (true)
        {
            Console.Clear();
            GameHelper.TypeText("You are in the dimly lit living room. The air is stale.");
            GameHelper.TypeText("The silence of the apartment is a constant companion.");
            
            // Zeigt den aktuellen Inventarinhalt an
            if (Program.Inventory.Any())
            {
                Console.WriteLine($"\nYou are carrying: {string.Join(", ", Program.Inventory)}.");
            }

            Console.WriteLine();
            Console.WriteLine("Where do you go?");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. To the kitchen.");
            Console.WriteLine("2. To the bathroom.");
            Console.WriteLine("3. Back to the main room (with the front door).");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();
            IScene nextScene;

            switch (choice)
            {
                case "1":
                    nextScene = new KitchenScene();
                    nextScene.Load(); // Lade die Szene und komme danach hierher zurück
                    break;
                case "2":
                    nextScene = new BathroomScene();
                    nextScene.Load(); // Lade die Szene und komme danach hierher zurück
                    break;
                case "3":
                    new RoomScene().Load(); // Lädt die Hauptszene und bricht diese Schleife ab
                    return;
                default:
                    // Bei Fehleingabe einfach die Schleife wiederholen
                    break;
            }
        }
    }
}
using System;

public class RoomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        // Die Debug-Anzeige zeigt jetzt alle unsere Zustände an.
        Console.WriteLine($"[DEBUG: Hope={Program.hopeLevel} | Injured={Program.isInjured} | BridgeBlocked={Program.bridgeIsBlocked}]");
        Console.WriteLine();

        // ... (Der Code für die Beschreibung basierend auf hopeLevel bleibt gleich)
        if (Program.hopeLevel > 0) { GameHelper.TypeText("The room is quiet. A blank canvas."); }
        else if (Program.hopeLevel < 0) { GameHelper.TypeText("The room is suffocating. The silence has a physical weight to it."); }
        else { GameHelper.TypeText("The room is quiet. Too quiet."); }
        
        if (Program.isInjured) { GameHelper.TypeText("Your ankle throbs with a dull, persistent pain."); }

        // ... (Der Rest der Standard-Beschreibung bleibt gleich)
        Console.WriteLine();
        Console.WriteLine("What do you do?");
        Console.WriteLine("--------------------------");

        Console.WriteLine("1. Go to the train tracks on the edge of town.");
        
        // Hier ist die neue, komplexere Logik für die Anzeige der Option 2
        if (Program.isInjured)
        {
            Console.WriteLine("2. (You can't go to the bridge with your injured ankle.)");
        }
        else if (Program.bridgeIsBlocked)
        {
            Console.WriteLine("2. (The bridge feels... watched now. You can't go back there.)");
        }
        else
        {
            Console.WriteLine("2. Go to the old, forgotten bridge.");
        }

        Console.WriteLine("3. Just... stay here. See what happens.");
        Console.WriteLine("4. Look at the diary on the desk.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                Program.hopeLevel--;
                nextScene = new TrainTracksScene();
                break;
            case "2":
                // Die Logik hier muss jetzt auch beide Zustände prüfen.
                if (Program.isInjured)
                {
                    GameHelper.TypeText("You try to put weight on your foot, but the pain is too sharp. That's not an option right now.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    nextScene = this;
                }
                else if (Program.bridgeIsBlocked)
                {
                    GameHelper.TypeText("No. You can't go back there. Not now. Maybe not ever.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    nextScene = this;
                }
                else
                {
                    Program.hopeLevel--;
                    nextScene = new BridgeScene();
                }
                break;
            case "3":
                nextScene = new StayInRoomScene();
                break;
            case "4":
                nextScene = new DiaryScene();
                break;
            default:
                nextScene = this; 
                break;
        }
        
        nextScene.Load();
    }
}
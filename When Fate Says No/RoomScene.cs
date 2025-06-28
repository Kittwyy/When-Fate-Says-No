using System;

// Diese Klasse repräsentiert die Szene im Zimmer.
// Durch ": IScene" sagen wir C#, dass diese Klasse unserer Schablone entspricht.
public class RoomScene : IScene
{
    // Die Logik von vorhin steckt jetzt in dieser Load-Methode.
    public void Load()
    {
        Console.Clear();
        Console.WriteLine("The room is quiet. Too quiet.");
        Console.WriteLine("The weight of everything presses down, a physical force.");
        Console.WriteLine("The thought is no longer a whisper. It's a scream.");
        Console.WriteLine("You have to get out. You have to make it stop.");
        Console.WriteLine();
        Console.WriteLine("What do you do?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Go to the train tracks on the edge of town.");
        Console.WriteLine("2. Go to the old, forgotten bridge.");
        Console.WriteLine("3. Just... stay here. See what happens.");
        Console.WriteLine("4. Look at the diary on the desk."); // NEUE OPTION
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                nextScene = new TrainTracksScene();
                break;
            case "2":
                nextScene = new BridgeScene();
                break;
            case "3":
                nextScene = new StayInRoomScene();
                break;
            case "4": // NEUER CASE
                nextScene = new DiaryScene();
                break;
            default:
                nextScene = this; 
                break;
        }
        
        nextScene.Load();
    }
}
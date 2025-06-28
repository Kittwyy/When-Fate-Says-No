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
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();

        // Hier kommt der wichtigste Unterschied:
        // Wir rufen keine Methode mehr auf, sondern erstellen ein *Objekt* der nächsten Szene.
        IScene nextScene;

        switch (choice)
        {
            case "1":
                nextScene = new TrainTracksScene(); // Erstelle die Gleis-Szene
                break;
            case "2":
                nextScene = new BridgeScene(); // Erstelle die Brücken-Szene
                break;
            case "3":
                nextScene = new StayInRoomScene(); // Erstelle die "Im-Zimmer-bleiben"-Szene
                break;
            default:
                nextScene = this; // Wenn die Eingabe ungültig ist, lade diese Szene einfach neu.
                break;
        }
        
        // Lade die ausgewählte nächste Szene.
        nextScene.Load();
    }
}
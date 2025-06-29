using System;
using System.Threading;

public class TrainTracksScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You arrive at the train tracks. The metal hums with a distant promise.");
        GameHelper.TypeText("The lonely platform is deserted under the dim lights. It smells of rain and rust.");
        GameHelper.TypeText("An electronic display flickers, showing the next arrival: 10:14 PM. On time.");
        GameHelper.TypeText("You sit on a cold bench and wait.");
        
        // Simuliere eine Wartezeit, um Spannung aufzubauen
        Thread.Sleep(1500);
        GameHelper.TypeText(".");
        Thread.Sleep(1500);
        GameHelper.TypeText(".");
        Thread.Sleep(1500);
        GameHelper.TypeText(".");

        GameHelper.TypeText("Suddenly, the display glitches. The letters scramble into nonsense before settling on a new message:");
        Console.WriteLine("\n\t\tCANCELLED\n");
        Thread.Sleep(1000);

        GameHelper.TypeText("A crackly, automated voice echoes from a hidden speaker:");
        // WICHTIG: Direkte Anspielung auf den Tagebucheintrag für maximale Wirkung
        GameHelper.TypeText("\"The 10:14 PM service is cancelled due to a signal failure. We apologize for the inconvenience.\"");
        GameHelper.TypeText("Signal failure. Of course.");
        GameHelper.TypeText("The universe has a twisted sense of humor.");
        
        Console.WriteLine();
        Console.WriteLine("The platform is silent again. What now?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Wait for the next train. No matter how long it takes.");
        Console.WriteLine("2. Walk along the tracks, away from the station.");
        Console.WriteLine("3. Just go home. It's useless.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                // Sturheit, die in tiefere Hoffnungslosigkeit führt.
                Program.ChangeHope(-1);
                nextScene = new WaitForNextTrainScene();
                break;
            case "2":
                // Eine ziellose, aber aktive Handlung. Keine Änderung der Hoffnung.
                nextScene = new WalkTheTracksScene();
                break;
            case "3":
                // Resignation und Rückkehr. Senkt die Hoffnung.
                Program.ChangeHope(-1);
                nextScene = new RoomScene(); // Führt direkt zurück in den Startraum.
                break;
            default:
                GameHelper.TypeText("Frozen by indecision, you just stand there as the minutes tick by.");
                // Die Szene neu zu laden ist hier eine passende Konsequenz für Unentschlossenheit.
                nextScene = this;
                break;
        }

        nextScene.Load();
    }
}
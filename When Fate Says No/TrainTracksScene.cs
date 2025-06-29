using System;
using System.Threading;

public class TrainTracksScene : IScene
{
    public void Load()
    {
        Program.trainTracksVisited = true;
        
        Console.Clear();
        Console.WriteLine($"[DEBUG: Arrived at tracks with Hope Level {Program.hopeLevel}]");
        Console.WriteLine();

        // --- HIER IST DIE ZENTRALE WEICHE ---
        if (Program.hopeLevel <= -4)
        {
            // --- PFAD DER NIEDRIGEN HOFFNUNG (DER BISHERIGE ABLAUF) ---
            LoadLowHopePath();
        }
        else
        {
            // --- PFAD DER HOHEN HOFFNUNG (NEUER ABLAUF) ---
            LoadHighHopePath();
        }
    }

    // Die Methode für den bekannten "Zug fällt aus"-Pfad
    private void LoadHighHopePath()
    {
        GameHelper.TypeText("You arrive at the train tracks. The metal hums with a distant, grim promise.");
        GameHelper.TypeText("An electronic display flickers, showing the next arrival: 10:14 PM. On time.");
        GameHelper.TypeText("You sit on a cold bench and wait.");
        
        Thread.Sleep(1500); GameHelper.TypeText("."); Thread.Sleep(1500); GameHelper.TypeText("."); Thread.Sleep(1500); GameHelper.TypeText(".");

        GameHelper.TypeText("Suddenly, the display glitches. The letters scramble before settling on a new message:");
        Console.WriteLine("\n\t\tCANCELLED\n");
        Thread.Sleep(1000);

        GameHelper.TypeText("A crackly, automated voice echoes: \"The 10:14 PM service is cancelled due to a signal failure...\"");
        GameHelper.TypeText("Signal failure. Of course. The universe has a twisted sense of humor.");
        
        Console.WriteLine("\nThe platform is silent again. What now?");
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
            case "1": Program.ChangeHope(-1); nextScene = new WaitForNextTrainScene(); break;
            case "2": nextScene = new WalkTheTracksScene(); break;
            case "3": Program.ChangeHope(-1); nextScene = new RoomScene(); break;
            default: nextScene = this; break;
        }
        nextScene.Load();
    }

    // Die NEUE Methode für den "Zug kommt an"-Pfad
    private void LoadLowHopePath()
    {
        GameHelper.TypeText("You arrive at the train tracks. The lights of the station seem less hostile tonight.");
        GameHelper.TypeText("An electronic display shows the next arrival: 10:14 PM. On time.");
        GameHelper.TypeText("You stand at the edge of the platform. Waiting.");
        Thread.Sleep(2000);

        GameHelper.TypeText("In the distance, a single bright light appears. It grows steadily larger.");
        GameHelper.TypeText("A low rumble turns into a ground-shaking roar. The train is here. It's real.");
        GameHelper.TypeText("There are no more coincidences, no more delays. The choice is yours alone.");

        Console.WriteLine("\nThe train thunders towards you. What do you do?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Step forward. End it.");
        Console.WriteLine("2. Step back from the edge. Let it pass.");
        Console.WriteLine("3. Just watch it arrive, frozen in place.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;
        switch (choice)
        {
            case "1":
                nextScene = new TrainArrivesEndingScene(); // Ein definitives "Game Over".
                break;
            case "2":
                // Eine bewusste Entscheidung für das Leben. Gibt maximale Hoffnung.
                Program.ChangeHope(Program.MaxHope); // Setzt die Hoffnung auf den Maximalwert.
                nextScene = new LetTrainPassScene();
                break;
            case "3":
                // Zögern, das in eine neutrale Handlung mündet.
                GameHelper.TypeText("You stand mesmerized as the train screams past, a blur of light and steel. Then, silence.");
                Console.WriteLine("\nPress Enter to go home...");
                Console.ReadLine();
                nextScene = new RoomScene();
                break;
            default:
                nextScene = this;
                break;
        }
        nextScene.Load();
    }
}
using System;
using System.Threading; // Wichtig für den Schreibmaschinen-Effekt!

public class BridgeScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine($"[DEBUG: Arrived at bridge with Hope Level {Program.hopeLevel}]");
        Console.WriteLine();

        // Der Beschreibungstext passt sich wieder dem hopeLevel an.
        if (Program.hopeLevel < -1)
        {
            TypeText("The cold metal of the railing feels like a familiar hand. A final comfort.");
        }
        else
        {
            TypeText("The old bridge groans under your weight. The river below is dark and cold.");
        }
        
        TypeText("You climb over the railing. Your feet find a precarious hold on the narrow ledge.");
        TypeText("Below, nothing but black water. Above, a starless sky.");
        TypeText("This is it. A single step is all it takes.");
        
        // Dramatische Pause
        Thread.Sleep(2000); // Wartet 2 Sekunden

        TypeText("\n...but the silence is suddenly torn apart.");
        TypeText("Splashes of red and blue light dance across the rusty metal, painting you in their colors.");
        TypeText("A car has stopped at the end of the bridge. A police car.");
        TypeText("A figure gets out.");
        
        Console.WriteLine();
        Console.WriteLine("What do you do?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. Climb back over. Pretend to be looking at the view.");
        Console.WriteLine("2. Stay where you are. Say nothing.");
        Console.WriteLine("3. Run. Try to make it to the other side of the bridge.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                // Eine rationale, aber verlogene Handlung.
                Program.hopeLevel++; // Ein kleiner Funke Hoffnung, weil man sich für das Leben entscheidet.
                nextScene = new LieToPoliceScene();
                break;
            case "2":
                // Eine passive, konfrontative Handlung.
                nextScene = new SilentTreatmentScene();
                break;
            case "3":
                // Eine panische Fluchtreaktion.
                Program.hopeLevel--;
                nextScene = new RunFromPoliceScene();
                break;
            default:
                nextScene = this; // Lade die Szene neu bei Fehleingabe.
                break;
        }

        nextScene.Load();
    }

    // NEU: Eine Hilfs-Methode für den Schreibmaschinen-Effekt.
    // Diese Methode können wir in Zukunft auch in andere Klassen kopieren.
    private void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);

            // Eine kurze Pause nach jedem Buchstaben, um den Tipp-Effekt zu erzeugen.
            // Bei Satzzeichen eine längere Pause.
            if (c == '.' || c == '?' || c == '!')
            {
                Thread.Sleep(400);
            }
            else
            {
                Thread.Sleep(40);
            }
        }
        Console.WriteLine(); // Nach dem Text eine neue Zeile beginnen.
    }
}
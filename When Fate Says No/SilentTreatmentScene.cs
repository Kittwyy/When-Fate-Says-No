using System;
using System.Threading;

public class SilentTreatmentScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You don't move. You just stare into the darkness below, the flashing lights feeling distant.");
        GameHelper.TypeText("The officer keeps a safe distance. 'Ma'am? Can you please step back over the railing? Let's just talk.'");
        GameHelper.TypeText("You don't answer. The silence stretches.");
        Thread.Sleep(1500);
        GameHelper.TypeText("You hear him sigh, then the quiet crackle of his radio.");
        GameHelper.TypeText("He isn't talking to you anymore.");
        GameHelper.TypeText("Time passes. Another car arrives. The lights are brighter now. There are more voices.");
        GameHelper.TypeText("The choice has been taken from you.");
        
        // Der Verlust der Kontrolle ist ein schwerer Schlag für die Hoffnung.
        Program.hopeLevel -= 2;
        
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();

        // Dieser Pfad führt direkt in die bekannte Therapie-Szene.
        new CaughtAndTherapyScene().Load();
    }
}
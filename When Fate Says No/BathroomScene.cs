using System;
using System.Linq;

public class BathroomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("The bathroom mirror is smudged. The air smells faintly of bleach.");
        Console.WriteLine("--------------------------");
        
        // Bedingte Optionen werden hier angezeigt
        if (Program.isInjured)
        {
            Console.WriteLine("1. Open the medicine cabinet to treat your ankle.");
        }
        Console.WriteLine("2. Look at the bathtub.");
        Console.WriteLine("3. Go back to the living room.");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                if (Program.isInjured)
                {
                    GameHelper.TypeText("You find some bandages and antiseptic. You carefully clean and wrap your ankle.");
                    GameHelper.TypeText("The pain dulls to a manageable ache. You can walk properly again.");
                    Program.isInjured = false;
                    Program.ChangeHope(1); // Selbstfürsorge gibt einen kleinen Hoffnungsschub.
                    Console.WriteLine("\n[STATE UPDATE: You are no longer injured. Hope increased.]");
                }
                break;
            case "2":
                // Hier prüfen wir die Bedingungen für das Ende.
                GameHelper.TypeText("You stare at the empty, white porcelain of the bathtub.");
                if (Program.Inventory.Contains("Knife") && Program.hopeLevel <= -4)
                {
                    GameHelper.TypeText("You have the knife. The water is cold. The thought is clear.");
                    Console.WriteLine("\nPress Enter to commit to the act...");
                    Console.ReadLine();
                    new BathtubEndingScene().Load();
                    return; // Wichtig, um nach dem Ende nicht weiterzumachen.
                }
                else if (Program.Inventory.Contains("Knife"))
                {
                    GameHelper.TypeText("You hold the knife, but your hands don't shake. The resolve isn't there. Not now.");
                }
                else
                {
                    GameHelper.TypeText("An empty tub offers no solutions.");
                }
                break;
            case "3":
                return; // Kehrt zum Apartment-Hub zurück.
        }
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
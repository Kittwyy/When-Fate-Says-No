using System;

public class LieToPoliceScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You scramble back over the railing, trying to look casual, your heart pounding.");
        GameHelper.TypeText("The officer approaches slowly, his hand not resting on his weapon, but not far either. His expression is neutral.");
        GameHelper.TypeText("'Everything okay here?' he asks, his voice calm.");
        
        Console.WriteLine();
        Console.WriteLine("How do you respond?");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1. 'Yes, officer. Just getting some air. Enjoying the... view.' (A simple lie)");
        Console.WriteLine("2. 'It's... just been a tough week. Needed to think.' (An emotional appeal)");
        Console.WriteLine("3. 'Is there a problem? Can't a person stand here?' (An aggressive deflection)");
        Console.WriteLine();
        Console.Write("Your choice: ");

        string choice = Console.ReadLine();
        IScene nextScene;

        switch (choice)
        {
            case "1":
                // Die beste Lüge. Die Situation wird deeskaliert.
                nextScene = new PoliceLeavesScene();
                break;
            case "2":
                // Erzeugt Empathie, aber führt zu einer sanften Intervention.
                Program.hopeLevel++;
                nextScene = new RideHomeScene();
                break;
            case "3":
                // Eine schlechte Wahl. Eskaliert die Situation und führt zum bekannten "Game Over".
                Program.hopeLevel -= 2;
                nextScene = new CaughtAndTherapyScene();
                break;
            default:
                GameHelper.TypeText("'I... uh...' You stumble over your words.");
                nextScene = new CaughtAndTherapyScene(); // Zögern führt ebenfalls zur Intervention.
                break;
        }

        nextScene.Load();
    }
}
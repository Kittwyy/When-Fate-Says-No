using System;

public class CaughtAndTherapyScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("A beam of light pins you against a wall. 'It's over,' a voice says, not unkindly.");
        GameHelper.TypeText("...");
        GameHelper.TypeText("The next clear thought you have, you are in a different room. It's clean, quiet, and smells of disinfectant.");
        GameHelper.TypeText("A person with a kind face and a notepad is sitting across from you.");
        GameHelper.TypeText("They ask you a question you don't know how to answer: 'Can we start from the beginning?'");
        
        Console.WriteLine("\n\n--- GAME OVER ---");
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
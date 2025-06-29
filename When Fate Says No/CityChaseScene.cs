using System;

public class CityChaseScene : IScene
{
    public void Load()
    {
        Console.Clear();
        GameHelper.TypeText("You dart into a narrow alleyway, the smell of wet garbage filling the air.");
        GameHelper.TypeText("You scramble over a chain-link fence, tearing your jacket.");
        GameHelper.TypeText("But the blue and red lights are everywhere. Sirens echo off the brick walls.");
        GameHelper.TypeText("You are cornered. There is nowhere left to run.");
        
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();

        // Diese Szene führt ohne weitere Wahl direkt zur nächsten.
        new CaughtAndTherapyScene().Load();
    }
}
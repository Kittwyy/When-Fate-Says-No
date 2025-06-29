using System;

public class RoomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine($"[DEBUG: Hope={Program.hopeLevel} | Injured={Program.isInjured} | BridgeBlocked={Program.bridgeIsBlocked} | HasDog={Program.hasDog}]");
        Console.WriteLine();

        // ZUERST PRÜFEN WIR, OB DER SPIELER VERLETZT IST
        if (Program.isInjured)
        {
            // Wenn verletzt, bekommt der Spieler eine komplett andere, eingeschränkte Szene.
            GameHelper.TypeText("You are back in your room. The only thing you can focus on is the throbbing, sharp pain in your ankle.");
            GameHelper.TypeText("Going anywhere far is impossible right now. You are trapped here. Trapped by your own body.");
            Console.WriteLine();
            Console.WriteLine("What can you even do?");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Look at the diary on the desk.");
            Console.WriteLine("2. Just lie in bed and wait for the pain to subside.");
            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();
            IScene nextScene;

            switch (choice)
            {
                case "1":
                    nextScene = new DiaryScene();
                    break;
                case "2":
                    nextScene = new WaitInBedScene();
                    break;
                default:
                    nextScene = this;
                    break;
            }
            nextScene.Load();
        }
        else
        {
            // Wenn NICHT verletzt, läuft die normale, reaktive Szene ab.
            
            if (Program.hopeLevel > 0)
            {
                GameHelper.TypeText("The room is quiet. A blank canvas.");
            }
            else if (Program.hopeLevel < 0)
            {
                GameHelper.TypeText("The room is suffocating. The silence has a physical weight to it.");
            }
            else // hopeLevel == 0
            {
                GameHelper.TypeText("The room is quiet. Too quiet.");
            }

            if (Program.hasDog)
            {
                GameHelper.TypeText("A small, furry creature watches you with trusting eyes from the corner of the room.");
            }

            GameHelper.TypeText("The weight of everything presses down.");
            GameHelper.TypeText("The thought is no longer a whisper. It's a scream.");
            GameHelper.TypeText("You have to get out. You have to make it stop.");
            
            Console.WriteLine();
            Console.WriteLine("What do you do?");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Go to the train tracks on the edge of town.");
            
            if (Program.bridgeIsBlocked)
            {
                Console.WriteLine("2. (The bridge feels... watched now. You can't go back there.)");
            }
            else
            {
                Console.WriteLine("2. Go to the old, forgotten bridge.");
            }

            Console.WriteLine("3. Just... stay here. See what happens.");
            Console.WriteLine("4. Look at the diary on the desk.");

            if (Program.hopeLevel > 1 && !Program.momHasBeenCalled)
            {
                Console.WriteLine("5. Pick up the phone and call Mom.");
            }

            Console.WriteLine();
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();
            IScene nextScene;

            switch (choice)
            {
                case "1":
                    Program.ChangeHope(-1);
                    nextScene = new TrainTracksScene();
                    break;
                case "2":
                    if (Program.isInjured) // Dieser Check ist eine doppelte Sicherheit
                    {
                        GameHelper.TypeText("You try to put weight on your foot, but the pain is too sharp. That's not an option right now.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        nextScene = this;
                    }
                    else if (Program.bridgeIsBlocked)
                    {
                        GameHelper.TypeText("No. You can't go back there. Not now. Maybe not ever.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        nextScene = this;
                    }
                    else
                    {
                        Program.ChangeHope(-1);
                        nextScene = new BridgeScene();
                    }
                    break;
                case "3":
                    nextScene = new StayInRoomScene();
                    break;
                case "4":
                    nextScene = new DiaryScene();
                    break;
                case "5":
                    // Wir müssen die Bedingung auch hier prüfen, falls der Spieler 5 eingibt, obwohl es nicht sichtbar war.
                    if (Program.hopeLevel > 1 && !Program.momHasBeenCalled)
                    {
                        nextScene = new CallMomScene();
                    }
                    else
                    {
                        GameHelper.TypeText("You reach for the phone, but your hand stops. There's nothing more to say right now.");
                        Console.ReadLine();
                        nextScene = this;
                    }
                    break;
                default:
                    nextScene = this; 
                    break;
            }
            nextScene.Load();
        }
    }
}
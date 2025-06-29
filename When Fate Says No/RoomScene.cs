using System;

public class RoomScene : IScene
{
    public void Load()
    {
        Console.Clear();
        Console.WriteLine($"[DEBUG: Hope={Program.hopeLevel} | Injured={Program.isInjured} | BridgeBlocked={Program.bridgeIsBlocked} | TrainVisited={Program.trainTracksVisited} | HasDog={Program.hasDog} | MomCalled={Program.momHasBeenCalled}]");
        Console.WriteLine();

        if (Program.isInjured)
        {
            // Die Logik für den verletzten Zustand bleibt unverändert dominant.
            GameHelper.TypeText("You are back in your room. The only thing you can focus on is the throbbing, sharp pain in your ankle.");
            GameHelper.TypeText("Going anywhere is impossible right now. You are trapped here.");
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
                case "1": nextScene = new DiaryScene(); break;
                case "2": nextScene = new WaitInBedScene(); break;
                default: nextScene = this; break;
            }
            nextScene.Load();
        }
        else
        {
            // --- Logik für den unverletzten Zustand ---
            if (Program.hopeLevel > 0) { GameHelper.TypeText("The room is quiet. A blank canvas."); }
            else if (Program.hopeLevel < 0) { GameHelper.TypeText("The room is suffocating. The silence has a physical weight to it."); }
            else { GameHelper.TypeText("The room is quiet. Too quiet."); }
            if (Program.hasDog) { GameHelper.TypeText("A small, furry creature watches you with trusting eyes from the corner of the room."); }
            GameHelper.TypeText("The weight of everything presses down.");
            Console.WriteLine();
            Console.WriteLine("What do you do?");
            Console.WriteLine("--------------------------");

            // NEUE PRÜFUNG FÜR OPTION 1
            if (Program.trainTracksVisited)
            {
                Console.WriteLine("1. (You've already been to the train tracks. There's no reason to go back.)");
            }
            else
            {
                Console.WriteLine("1. Go to the train tracks on the edge of town.");
            }
            
            if (Program.bridgeIsBlocked) { Console.WriteLine("2. (The bridge feels... watched now. You can't go back there.)"); }
            else { Console.WriteLine("2. Go to the old, forgotten bridge."); }

            Console.WriteLine("3. Just... stay here. See what happens.");
            Console.WriteLine("4. Look at the diary on the desk.");
            if (Program.hopeLevel > 1 && !Program.momHasBeenCalled) { Console.WriteLine("5. Pick up the phone and call Mom."); }

            Console.WriteLine();
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
            IScene nextScene;
            switch (choice)
            {
                case "1":
                    // NEUE PRÜFUNG FÜR AUSWAHL 1
                    if (Program.trainTracksVisited)
                    {
                        GameHelper.TypeText("You think about the tracks, but the memory is a dead end. No point in going back.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        nextScene = this;
                    }
                    else
                    {
                        Program.ChangeHope(-1);
                        nextScene = new TrainTracksScene();
                    }
                    break;
                case "2":
                    if (Program.bridgeIsBlocked)
                    {
                        GameHelper.TypeText("No. You can't go back there. Not now. Maybe not ever.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        nextScene = this;
                    }
                    else { Program.ChangeHope(-1); nextScene = new BridgeScene(); }
                    break;
                case "3":
                    nextScene = new StayInRoomScene();
                    break;
                case "4": nextScene = new DiaryScene(); break;
                case "5":
                    if (Program.hopeLevel > 1 && !Program.momHasBeenCalled) { nextScene = new CallMomScene(); }
                    else
                    {
                        GameHelper.TypeText("You reach for the phone, but your hand stops. There's nothing more to say right now.");
                        Console.ReadLine();
                        nextScene = this;
                    }
                    break;
                default: nextScene = this; break;
            }
            nextScene.Load();
        }
    }
}
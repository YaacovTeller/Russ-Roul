using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    class Update
    {
        public static string userMessage = "";
        public static void action()
        {
            ConsoleKeyInfo digit = Console.ReadKey();
            Console.WriteLine();
            if (digit.KeyChar == 'r') { Gun.chamberRound(); }
            else if (digit.KeyChar == 's') { Gun.spinBarrel(); }
            else if (digit.KeyChar == 'e') { Gun.emptyBarrel(); }
            else if (digit.KeyChar == 'h') { Gun.pullBackHammer(); }
            else if (digit.KeyChar == 'f') { Gun.pullTrigger(); }
            else if (digit.Key == ConsoleKey.Spacebar) { Gun.putGuntoHead(); }
            else
            {
                userMessage = "select a valid action";
            }
            updater();
        }
        public static void updater()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string loadedStatus = Gun.loaded ? "loaded" : "empty";
            Console.WriteLine("Gun {0}", loadedStatus);
            string hammerStatus = Gun.hammer ? "back" : "down";
            Console.WriteLine("Hammer {0}", hammerStatus);
            string pointStatus = Gun.gunToHead ? "Dangerous" : "Safe";
            Console.WriteLine(pointStatus);
            Console.WriteLine("Chamber {0}", Gun.chamber);
            Console.WriteLine();
            foreach (var i in Gun.gunBarell)
            {
                Console.Write(i.ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
            if (Gun.dead == false)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Press 'r' to chamber a round");
                Console.WriteLine("Press 's' to spin gun barrel");
                Console.WriteLine("Press 'h' to pull back the hammer");
                Console.WriteLine("Press 'e' to empty the gun");
                Console.WriteLine("Press 'f' to pull the trigger");
                Console.WriteLine("Press 'space' to put the gun to your head");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                colourChecker();
                Console.WriteLine(userMessage);
                Console.WriteLine();
                action();
            }
            else
            {
                userMessage = "You're dead";
                Console.WriteLine(userMessage);
                deadLoop();
            }
           
        }
        public static void colourChecker()
        {
            if (Gun.shotFired == true)
            {
                Gun.shotFired = false;
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
        static int num = 0;
        public static void deadLoop()
        {
            if (num == 4) { num = 1; }
            else num++;
            ConsoleKeyInfo digit = Console.ReadKey(true);
            if (digit.KeyChar == 'f') { userMessage = "Glutton for punishment are you?"; }
            else if (digit.Key == ConsoleKey.Spacebar) { userMessage = "The damage is done, i'm afraid."; }
            else
            {
                switch (num)
                {
                    case 1:
                        userMessage = "Dude, you can't do anything, you're dead.";
                        break;
                    case 2:
                        userMessage = "That really wont help, you know. Nothing will.";
                        break;
                    case 3:
                        userMessage = "Yup, still dead.";
                        break;
                    case 4:
                        userMessage = "You weren't paying attention, were you?.";
                        break;
                };
            }
            Console.WriteLine(userMessage);
            deadLoop();
        }
    }
}

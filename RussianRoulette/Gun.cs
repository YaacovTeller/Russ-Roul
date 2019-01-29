using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    static class Gun
    {
        public static int[] gunBarell = new int[6] {0,0,0,0,0,0};
        public static int chamber = 1;
        public static int roundsLoaded = 0;
        public static bool loaded = false;
        public static bool hammer = false;
        public static bool gunToHead = false;
        public static bool dead = false;
        public static bool shotFired = false;
        public static int persistance = 0;
        public static int bullet;

        public static void pullBackHammer()
        {
            if (hammer == false)
            {
                hammer = true;
                cycleBarrel();
                Update.userMessage = "You pulled back the hammer";
                Update.updater();
            }
            else
            {
                Update.userMessage = "Your gun is already cocked";
                Update.updater();
            }
        }
        public static void randGen()
        {
            Random rand = new Random();
            bullet = rand.Next(1, 7);
        }
        public static void chamberRound()
        {
            switch (roundsLoaded)
            {
                case 0:
                    do { randGen(); }
                    while (gunBarell[bullet - 1] == 1);
                    gunBarell[bullet - 1] = 1;
                    loaded = true;
                    roundsLoaded++;
                    Update.userMessage = "Round chambered";
                    break;
                case 1:
                    if (persistance < roundsLoaded)
                    {
                        Update.userMessage = "You have one round in already, more than that reduces your chances of survival significantly";
                            persistance++;
                            Update.updater();
                    }
                    else
                    {
                        do { randGen(); }
                        while (gunBarell[bullet - 1] == 1);
                        gunBarell[bullet - 1] = 1;
                        roundsLoaded++;
                        Update.userMessage = "It's your funeral";
                    }
                    break;
                case 2:
                    if (persistance < roundsLoaded)
                    {
                        Update.userMessage = "Are you sure this is a great idea?";
                        persistance++;
                        Update.updater();
                    } 
                    else
                    {
                        do { randGen(); }
                        while (gunBarell[bullet - 1] == 1);
                        gunBarell[bullet - 1] = 1;
                        roundsLoaded++;
                        Update.userMessage = "This wont end well, you know";
                    }
                    break;
                case 3:
                case 4:
                case 5:
                    do { randGen(); }
                    while (gunBarell[bullet - 1] == 1);
                    gunBarell[bullet - 1] = 1;
                    roundsLoaded++;
                    Update.userMessage = "A fully loaded gun kind of removes the risk factor here";
                    break;
                case 6:
                    Update.userMessage = "Your gun is fully loaded, psychopath";
                    break;
            }
            Update.updater();
        }
        public static void emptyBarrel()
        {  
            if (loaded == true)
            {
                loaded = false;
                for (int i = 0; i < 6; i++)
                {
                    gunBarell[i] = 0;
                }
                Update.userMessage = "";
                for (int i = 1; i <= roundsLoaded; i++)
                {
                    Update.userMessage += "*ting* ";
                }
                roundsLoaded = 0;
            }
            else Update.userMessage = "your gun is empty, fool";
            Update.updater();
        }
        public static void spinBarrel()
        {
            Random rand = new Random();
            chamber = rand.Next(1,7);
            Update.userMessage = "ttzzzzzzzzzzch";
            Update.updater();
        }
        public static void pullTrigger() {
            if (hammer == true)
            {
             //   System.Media.SystemSounds.Beep.Play();
                if (gunBarell[chamber - 1] == 1)
                {
                    gunBarell[chamber - 1] = 0;
                    loaded = false;
                    roundsLoaded--;
                    Update.userMessage = "BANG!";
                    shotFired = true;
                    if (gunToHead == true)
                    {
                        dead = true;
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                }
                else Update.userMessage = "*click*";
                hammer = false;
            }
            else Update.userMessage = "Your gun isn't cocked";
            Update.updater();
        }
        public static void cycleBarrel()
        {
            if (chamber == 6)
            {
                chamber = 1;
            }
            else chamber++;
        }
        public static void putGuntoHead()
        {
            if (gunToHead == false)
            {
                gunToHead = true;
            }
            else gunToHead = false;
        }
    }
}

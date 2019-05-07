using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
     class Menu
    {

        public static Pet myPet = new Pet();
        public static Save newSave = new Save();
        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            Console.WriteLine("Hello! Welcome to VirtualPet version 2.0");
            synth.Speak("Hello! Welcome to Virtual Pet version 2.0");

            string title = @"--   _   _ _      _               _  ______    _    
--  | | | (_)    | |             | | | ___ \  | |   
--  | | | |_ _ __| |_ _   _  __ _| | | |_/ /__| |_  
--  | | | | | '__| __| | | |/ _` | | |  __/ _ \ __| 
--  \ \_/ / | |  | |_| |_| | (_| | | | | |  __/ |_  
--   \___/|_|_|   \__|\__,_|\__,_|_| \_|  \___|\__| 
--                                                  
--                                                  
 ";
            Console.WriteLine(title);

            bool quit = true;
            int choice = 1;
            myPet.name = "Georgi";


            while (quit)
            {
                choice = Show();

                switch (choice)
                {
                    case 0:  // quit game
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Thank you for playing Virtual Pet 2.0");
                        synth.Speak("Thank you for playing Virtual Pet 2.0");
                        Console.WriteLine("Press \"Enter\" to exit the game.");
                        synth.Speak("Press \"Enter\" to exit the game.");
                        Console.ReadLine();
                        quit = false;
                        break;
                    case 1:
                        Console.WriteLine($"You talk to {myPet.name}.");
                        synth.Speak($"You talk to {myPet.name}.");
                        myPet.talk();
                        break;
                    case 2:
                        Console.WriteLine($"You feed {myPet.name}.");
                        synth.Speak($"You feed {myPet.name}");
                        myPet.eat();
                        break;
                    case 3:
                        Console.WriteLine($"You play with {myPet.name}.");
                        synth.Speak($"You play with {myPet.name}.");

                        myPet.play();
                        break;
                    case 4:
                        Console.WriteLine("Oh, so you don't like my name, huh?");
                        synth.Speak("Oh, so you don't like my name, huh?");
                        Console.WriteLine("Then what do you think it should be?");
                        synth.Speak("Then what do you think it should be?");
                        myPet.name = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine($"Very well, My name is {myPet.name} now.");
                        synth.Speak($"Very well, My name is {myPet.name}");
                        break;
                    case 5:
                        newSave.MakeSave();
                        break;
                    case 6:
                        newSave.LoadSave();
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        synth.Speak("Invalid selection");
                        Console.WriteLine("Please enter 0, 1, 2, 3 or 4");
                        synth.Speak("Please enter 0, 1, 2, 3 or 4");

                        break;
                } // end switch
            } // end while loop
        } // end main method

        static int Show()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            int input = 1;

            Console.WriteLine();
            Console.WriteLine();
            if (myPet.age == 1)
            {
                Console.WriteLine($"{myPet.name} the chinchilla is 1 year old.");
                synth.Speak($"{myPet.name} the chinchilla is 1 year old.");
                
            }
            else
            {
                Console.WriteLine($"{myPet.name} the chinchilla is {myPet.age} years old.");
                synth.Speak($"{myPet.name} the chinchilla is {myPet.age} years old.");
            } // end if
            Console.WriteLine();
            Console.WriteLine("0) Exit the program");
            Console.WriteLine($"1) Talk to {myPet.name}.");
            Console.WriteLine($"2) Feed {myPet.name}.");
            Console.WriteLine($"3) Play with {myPet.name}.");
            Console.WriteLine($"4) Rename {myPet.name}.");
            Console.WriteLine("5) Save your game.");
            Console.WriteLine("6) Load your saved game.");
            Console.Write(": ");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid entry.");
                synth.Speak("Invalid entry");
                Console.WriteLine("Please enter 0, 1, 2, 3 or 4");
                synth.Speak("Please enter 0, 1, 2, 3, or 4");
                
            } // end try

            // age the pet
            myPet.age += 1;
            myPet.happy -= 1;
            myPet.hungry -= 1;

            if (myPet.hungry < 1)
            {
                Console.Clear();
                Console.WriteLine($"You walk in to find {myPet.name} lying motionless on the floor.");
                synth.Speak($"You walk in to find {myPet.name} lying motionless on the floor.");
                Console.WriteLine("He is skin and bones and flies are buzzing over him.");
                synth.Speak("He is skin and bones and flies are buzzing over him.");
                Console.WriteLine("You should keep a closer eye on him next time.");
                synth.Speak("You should keep a closer eye on him next time.");
                return 0;
            }
            else if (myPet.happy < 1)
            {
                Console.Clear();
                Console.WriteLine($"You walk in, whistling and calling for {myPet.name} but ");
                synth.Speak($"You walk in, whistling and calling for {myPet.name} but ");
                Console.WriteLine("you can't find him anywhere.  On the table, you ");
                synth.Speak("you can't find him anywhere.  On the table, you ");
                Console.WriteLine($"find a note from {myPet.name} saying that he is running ");
                synth.Speak($"find a note from {myPet.name} saying that he is running");
                Console.WriteLine("away.  You should spend more time with him next time.");
                synth.Speak("away. You should spend more time with him next time");
                return 0;
            }
            else
            {
                return input;
            } // end if
        } // end show method
    } // end class
} // end namespace
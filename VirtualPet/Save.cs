using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    
    class Save
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        public static String PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public void MakeSave()

        {
            

            string[] saveData = { Menu.myPet.name, Convert.ToString(Menu.myPet.age), Convert.ToString(Menu.myPet.hungry), Convert.ToString(Menu.myPet.happy) };
            System.IO.File.WriteAllLines(PersonalFolder + @"\virtualpet.sav", saveData);
            Console.WriteLine();
            Console.WriteLine("Your game has been saved successfully.");
            synth.Speak("Your game has been saved successfully.");
            Console.WriteLine();
            Console.WriteLine("Press \"Enter\" to return to the game");
            synth.Speak("Press \"Enter\" to return to the game");
            Console.ReadLine();
        } // end make save method

        public void LoadSave()
        {
            bool success = false;
            try
            {
                string[] loadData = System.IO.File.ReadAllLines(PersonalFolder + @"\virtualpet.sav");
                string Lname = loadData[0];
                int Lage = Convert.ToInt32(loadData[1]);
                int Lhungry = Convert.ToInt32(loadData[2]);
                int Lhappy = Convert.ToInt32(loadData[3]);
                Menu.myPet.name = Lname;
                Menu.myPet.age = Lage;
                Menu.myPet.hungry = Lhungry;
                Menu.myPet.happy = Lhappy;
                success = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine();
                Console.WriteLine("You must save a game before you can load one.");
                synth.Speak("You must save a game before you can load one.");
            }
            finally
            {
                if (success)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your game has been loaded successfully.");
                    synth.Speak("Your game has been loaded successfully.");
                }// end if handle
            } // end exception handle

            

            Console.WriteLine();
            Console.WriteLine("Press \"Enter\" to return to the game");
            synth.Speak("Press \"Enter\" to return to the game");
            Console.ReadLine();
           

        } // end loadsave method
    } // end save class
} // end namespace

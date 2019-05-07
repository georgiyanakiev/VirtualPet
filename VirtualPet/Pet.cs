using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet
{
    class Pet
    {

        public int age = 0;
        public int happy = 10;
        public int hungry = 10;
        public string name;

        public void talk()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            if (happy > 9)
            {
                Console.WriteLine("I couldn't be any happier!");
                synth.Speak("I couldn't be any happier!");
                
                
            }
            else if (happy > 5)
            {
                Console.WriteLine("Hey! I'm down here. Play with me!");
                synth.Speak("Hey! I'm down here. Play with me!");
            }
            else
            {
                Console.WriteLine($"{name} sits in the corner, afraid to look in your direction");
                synth.Speak($"{name} sits in the corner, afraid to look in your direction");
            } // end happy if

            if (hungry > 9)
            {
                Console.WriteLine("I'm stuffed!  I can't eat another bite!");
                synth.Speak("I'm stuffed!  I can't eat another bite!");
            }
            else if (hungry > 5)
            {
                Console.WriteLine($"{name} eyes the bag of pet food on the shelf");
                synth.Speak($"{name} eyes the bag of pet food on the shelf");
            }
            else
            {
                Console.WriteLine($"You hear {name}'s stomach rumbling from across the room");
                synth.Speak($"You hear {name}'s stomach rumbling from across the room");
            } // end hungry if
        } // end talk method

        public void eat()
        {
            hungry += 4;
        } // end eat method

        public void play()
        {
            happy += 3;
        } // end play method
    } // end Pet class
} // end namespace

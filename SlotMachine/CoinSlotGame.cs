using System;

namespace SlotMachine
{
    class MainClass
    {
        static string answer;
        static int amount;
        public static void Main(string[] args)
        {   
            // Initialise game
            Console.WriteLine("Hello there! How much money would you like to deposit?");
            receiveInputAmount();

            Player aPlayer = new Player(amount);
            Machine aMachine = new Machine();
            // play the game while the user has money
            while (aPlayer.hasBalance()) {
                aPlayer.spin(aMachine);
            }
        }







        // Additional: Check that the user input is a number
        public static void receiveInputAmount() {
            answer = Console.ReadLine();

            if (int.TryParse(answer, out amount)) {
                //
            }
            else {
                Console.WriteLine("Please enter a number!");
                receiveInputAmount();
            }
        }
    }
}

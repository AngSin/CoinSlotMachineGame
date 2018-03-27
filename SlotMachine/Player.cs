using System;
namespace SlotMachine
{
    public class Player
    {
        double balance;
        double stake;

        public Player(int deposit)
        {   
            balance  = deposit;
        }
        public bool hasBalance() {
            return (balance > 0);
        }

        public void spin(Machine aMachine) {
            Console.WriteLine("Please enter an amount to stake/bet on:");
            string answer = Console.ReadLine();
            if (double.TryParse(answer, out stake)) {
                //
            }
            else {
                Console.WriteLine("Please enter a number!");
                return;
            }

            if (stake > balance) {
                Console.WriteLine("Bet within your means mate!");
                return;
            }
            aMachine.displayResult();
            double winAmount = aMachine.calcWinAmount(stake);

            Console.WriteLine("You have won: " + winAmount);

            balance = (balance - stake) + winAmount;
            balance = Math.Truncate(balance * 100) / 100;    

            Console.WriteLine("Current balance: " + balance.ToString("C2"));
        }
    }
}

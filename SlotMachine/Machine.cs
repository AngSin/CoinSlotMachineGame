using System;
namespace SlotMachine
{
    public class Machine
    {
        char a = 'A';
        char b = 'B';
        char p = 'P';
        char wildcard = '*';

        double coefficientA = 0.4;
        double coefficientB = 0.6;
        double coefficientP = 0.8;
        //double coefficientWildcard;

        int probabilityA = 45; // we are going to add these later for calc
        int probabilityB = 35;
        int probabilityP = 15;
        // int probabilitywildcard = 5; not needed since 100 - sum = 5

        Random random = new Random();

        string[] machineRows = new string[4];

        char addSymbol() {
            int randomPercentile = random.Next(0, 100);
            if (randomPercentile < probabilityA)
                return a;
            if (randomPercentile < (probabilityA + probabilityB))
                return b;
            if (randomPercentile < (probabilityA + probabilityB + probabilityP))
                return p;
            
                return wildcard;
        }

        public void displayResult() {
            machineRows = new string[4];
            for (int i = 0; i < machineRows.Length; i++) {
                machineRows[i] += addSymbol();
                machineRows[i] += addSymbol();
                machineRows[i] += addSymbol();
                string row = machineRows[i];
                Console.WriteLine(row);
            }
        }

        double calcRowWin(string row) {
            int counterOfSameSymbol = 0;
            char symbol = '*';
            for (int i = 0; i < row.Length - 1; i++) {
                char[] chars = row.ToCharArray();
                char current = chars[i];
                // if the current char isn't '*', add to the counter
                if (current != wildcard) {
                    symbol = current;
                    counterOfSameSymbol++;
                }
                // if the next character is not the current symbol, return 0,
                // provided that the current symbol variable isn't '*'
                if (chars[i + 1] != symbol && chars[i + 1] != wildcard && symbol != wildcard) {
                    return 0.0;
                }
                // add to the counter if the last char is the same symbol 
                // (since this for loop's pointer will never reach the last element)
                if (((i + 1) == row.Length - 1) && chars[i + 1] == symbol) {
                    counterOfSameSymbol++;
                }
                // or add to the counter if we only got * so far 
                // and the last char is a symbol and can't be reached due to loop limit
                if (((i + 1) == row.Length - 1) && counterOfSameSymbol == 0 && chars[i + 1] != wildcard) {
                    symbol = chars[i + 1];
                    counterOfSameSymbol++;
                }
            }
            if (symbol == a)
                return (coefficientA * counterOfSameSymbol);
            if (symbol == b)
                return (coefficientB * counterOfSameSymbol);
            if (symbol == p)
                return (coefficientP * counterOfSameSymbol);
            return 0.0;
        }

        public double calcWinAmount(double stake)
        {
            double totalWinCoefficients = 0.0;
            for (int i = 0; i < machineRows.Length; i++)
            {
                string row = machineRows[i];
                totalWinCoefficients += calcRowWin(row);
            }
            return (totalWinCoefficients * stake);
        }
    }
}

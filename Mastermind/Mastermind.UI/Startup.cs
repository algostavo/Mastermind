using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind
{
    public class Startup
    {
/*
 * The randomly generated answer should be four (4) digits in length, with each digit ranging from 1 to 6. 
 * After the player enters a combination,
 * a minus (-) sign should be printed for every digit that is correct * but in the wrong position,
 * and a plus (+) sign should be printed for every digit that is both correct and in the correct position. 
 * Print all plus signs first, all minus signs second, and nothing for incorrect digits. 
 * The player has ten (10) attempts to guess the number correctly before receiving a message that they have lost.
 */
        public void Run()
        {
            Console.WriteLine("************************************************");
            Console.WriteLine("Your random four digit number has been generated!");
            Console.WriteLine("************************************************");
            var guessCounter = 0;
            var random = new Random();
            var randomFourDigits = random.Next(1111,6666).ToString();
            var ruleEngine = new RuleEngine();
            var guessResult = new Tuple<List<string>, int>(item1:new List<string>(),item2: 0);
            while (guessCounter != 10)
            {
                guessCounter++;
                Console.WriteLine("\nPlease type your four digit guess (" + guessCounter + " of 10)");
                var userGuess = Console.ReadLine();
                guessResult = ruleEngine.Validator(randomFourDigits, userGuess);
                foreach (var s in guessResult.Item1.OrderByDescending(x =>x.Equals("+")))
                {
                    Console.Write("{0}\t", s);
                } 
            }

            var total = guessResult.Item2 > 0 ? "\nYou win! :)" : "\nYou lose! :(";
            Console.WriteLine(total);
        }
    }
}
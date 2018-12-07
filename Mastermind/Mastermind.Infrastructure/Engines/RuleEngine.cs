using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class RuleEngine
    {
        public Tuple<List<string>,int> Validator(string randomFourDigits, string userGuessedDigits)
        {
            var wins = 0;
            const string minus = "-";
            const string plus = "+";
            var rf = randomFourDigits.ToCharArray();
            var ug = userGuessedDigits; 
            var result = new List<string>();
            var resultsWithWins = new Tuple<List<string>, int>(item1: result, item2: wins);
            if (randomFourDigits.Equals(userGuessedDigits)) wins++;
            for (var i = 0; i < rf.Length; i++)
            {
                if (rf[i] == ug[i])
                {
                    resultsWithWins.Item1.Add(plus);
                }
                if (rf[i] != ug[i] &&
                    randomFourDigits.Contains(ug[i].ToString()))
                {
                    resultsWithWins.Item1.Add(minus);
                }
            }
            return resultsWithWins;
        }
    }
}
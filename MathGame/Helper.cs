﻿using System.Configuration;

namespace MathGame
{
    public static class Helper
    {
        public static string ConnValue(string name)
        {
            // Returns connectionString from App.config
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        static internal string[] chooseView()
        {
            // Asking the user for inputs on what they want to view in the game history.
            var choices = new string[2];
            var inputCorrect1 = false;
            var inputCorrect2 = false;
            string order = "";
            string type = "";

            Console.WriteLine(@"Would you like to view:
H - Highest Scores
L - Lowest Scores");

            while (!inputCorrect1)
            {
                var highOrLow = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(highOrLow) || highOrLow.ToLower().Trim() != "h" && highOrLow.ToLower().Trim() != "l")
                {
                    Console.WriteLine("Please input either H or L.");
                }
                else
                {
                    inputCorrect1 = true;
                    order = highOrLow;
                }
            }

            Console.WriteLine(@"Which game type would you like to view:
A - Addition
S - Subtraction
M - Multiplication
D - Division
G - All Game Types");


            while (!inputCorrect2)
            {
                var gameType = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(gameType) || gameType.ToLower().Trim() != "a" && gameType.ToLower().Trim() != "s"
                    && gameType.ToLower().Trim() != "m" && gameType.ToLower().Trim() != "d" && gameType.ToLower().Trim() != "g")
                {
                    Console.WriteLine("Please input either A,S,M,D or G.");
                }
                else
                {
                    inputCorrect2 = true;
                    type = gameType;
                }
            }
            choices[0] = order;
            choices[1] = type;
            return choices;
        }
    }
}

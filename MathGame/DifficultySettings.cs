using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal static class DifficultySettings
    {

        internal static void DifficultyMessage()
        {
            Console.Clear();
            Console.WriteLine(@"--------------------- EASY -----------------------
Only single digit numbers (including 10) will be used in the questions.
There is absolutely no possibility for negative numbers.");
            Console.WriteLine();
            Console.WriteLine(@"-------------------- MEDIUM ----------------------
Some double digit numbers will be thrown in there.
The subtraction game may have negative numbers.");
            Console.WriteLine();
            Console.WriteLine(@"--------------------- HARD -----------------------
Only double digit numbers will be used.
The subtraction game may have negative numbers");

            Console.WriteLine();
            Console.WriteLine(@"Which settings would you like to choose?
E - Easy
M - Medium
H - Hard");
        }

        internal static int[] SetDifficultyEasy(string gameType)
        {
            var random = new Random();
            if (gameType == "a" || gameType == "m")
            {
                var numbers = new int[2];
                numbers[0] = random.Next(0, 10);
                numbers[1] = random.Next(0, 10);
                return numbers;
            }
            else if (gameType == "d")
            {
                var firstNumber = random.Next(0, 10);
                var secondNumber = random.Next(1, 10);
                var divisibleNumbers = new int[2];

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(0, 10);
                    secondNumber = random.Next(1, 10);
                }

                divisibleNumbers[0] = firstNumber;
                divisibleNumbers[1] = secondNumber;
                return divisibleNumbers;
            }
            else if (gameType == "s")
            {
                var firstNumber = random.Next(0, 10);
                var secondNumber = random.Next(0, 10);
                var subtractNumbers = new int[2];

                while (firstNumber < secondNumber)
                {
                    firstNumber = random.Next(0, 10);
                    secondNumber = random.Next(0, 10);
                }

                subtractNumbers[0] = firstNumber;
                subtractNumbers[1] = secondNumber;
                return subtractNumbers;
            }
            else { return null; }

        }
        internal static int[] SetDifficultyMedium(string gameType)
        {
            var random = new Random();
            if (gameType == "a" || gameType == "m" || gameType == "s")
            {
                var numbers = new int[2];
                numbers[0] = random.Next(10, 100);
                numbers[1] = random.Next(2, 10);
                return numbers;
            }
            else if (gameType == "d")
            {
                var firstNumber = random.Next(10, 100);
                var secondNumber = random.Next(2, 10);
                var divisibleNumbers = new int[2];

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(10, 100);
                    secondNumber = random.Next(2, 10);
                }

                divisibleNumbers[0] = firstNumber;
                divisibleNumbers[1] = secondNumber;
                return divisibleNumbers;
            }
            else { return null; }

        }
        internal static int[] SetDifficultyHard(string gameType)
        {
            var random = new Random();
            if (gameType == "a" || gameType == "m" || gameType == "s")
            {
                var numbers = new int[2];
                numbers[0] = random.Next(10, 100);
                numbers[1] = random.Next(10, 100);
                return numbers;
            }
            else if (gameType == "d")
            {
                var firstNumber = random.Next(10, 100);
                var secondNumber = random.Next(10, 100);
                var divisibleNumbers = new int[2];

                while (firstNumber % secondNumber != 0 || firstNumber == secondNumber)
                {
                    firstNumber = random.Next(10, 100);
                    secondNumber = random.Next(10, 100);
                }

                divisibleNumbers[0] = firstNumber;
                divisibleNumbers[1] = secondNumber;
                return divisibleNumbers;
            }
            else { return null; }

        }

        internal static int[] DifficultySetter(string difficulty, string gameType)
        {
            var difficultyNum = new int[2];

            if (difficulty == "e")
            {
                difficultyNum = DifficultySettings.SetDifficultyEasy(gameType);
            }
            else if (difficulty == "m")
            {
                difficultyNum = DifficultySettings.SetDifficultyMedium(gameType);
            }
            else if (difficulty == "h")
            {
                difficultyNum = DifficultySettings.SetDifficultyHard(gameType);
            }
            return difficultyNum;
        }



    }
}

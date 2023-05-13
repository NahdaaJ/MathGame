using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class GameOperations
    {
        internal void AdditionGame()
        {
            var databaseOPS = new DatabaseOperations();
            var random = new Random();
            int firstNumber;
            int secondNumber;
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                string input = "";
                var inputType = false;
                firstNumber = random.Next(0, 100);
                secondNumber = random.Next(0, 100);
                correctAnswer = firstNumber + secondNumber;

                while (!inputType)
                {
                    Console.WriteLine($"{firstNumber} + {secondNumber} =");
                    var result = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(result) || !int.TryParse(result, out _))
                    {
                        Console.Clear();
                        Console.WriteLine("Please input a number.");
                    }
                    else
                    {
                        inputType = true;
                        input = result;
                    }
                }

                if (int.Parse(input) == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"That's incorrect, the correct answer was {correctAnswer}.");
                }
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine("-------------------------------------------------------");
                if (i != 9)
                {
                    Console.WriteLine("Press enter for next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press enter to see final score.");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine($"Your final score for the Addition Game was {score}/10 .");

            var gameType = "Addition";
            databaseOPS.AddGameHistory(gameType, score);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();
        }
        internal void SubtractionGame()
        {
            var databaseOPS = new DatabaseOperations();
            var random = new Random();
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();

                var nonNegative = Helper.GetSubtractionNumbers();
                correctAnswer = nonNegative[0] - nonNegative[1];
                string input="";
                var inputType = false;

                while (!inputType)
                {
                    Console.WriteLine($"{nonNegative[0]} - {nonNegative[1]} =");
                    var result = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(result) || !int.TryParse(result,out _))
                    {
                        Console.Clear();
                        Console.WriteLine("Please input a number.");
                    }
                    else
                    {
                        inputType = true;
                        input = result;
                    }
                }
                
                if (int.Parse(input) == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"That's incorrect, the correct answer was {correctAnswer}.");
                }
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine("-------------------------------------------------------");

                if (i != 9)
                {
                    Console.WriteLine("Press enter for next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press enter to see final score.");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine($"Your final score was {score}/10");

            var gameType = "Subtraction";
            databaseOPS.AddGameHistory(gameType, score);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();
        }
        internal void MultiplicationGame()
        {
            var databaseOPS = new DatabaseOperations();
            var random = new Random();
            int firstNumber;
            int secondNumber;
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                firstNumber = random.Next(0, 10);
                secondNumber = random.Next(0, 20);
                correctAnswer = firstNumber * secondNumber;
                string input = "";
                var inputType = false;

                while (!inputType)
                {
                    Console.WriteLine($"{firstNumber} x {secondNumber} =");
                    var result = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(result) || !int.TryParse(result, out _))
                    {
                        Console.Clear();
                        Console.WriteLine("Please input a number.");
                    }
                    else
                    {
                        inputType = true;
                        input = result;
                    }
                }

                if (int.Parse(input) == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"That's incorrect, the correct answer was {correctAnswer}.");
                }
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine("-------------------------------------------------------");
                if (i != 9)
                {
                    Console.WriteLine("Press enter for next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press enter to see final score.");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine($"Your final score was {score}/10");

            var gameType = "Multiplication";
            databaseOPS.AddGameHistory(gameType, score);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();
        }
        internal void DivisionGame()
        {
            var databaseOPS = new DatabaseOperations();
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                string input = "";
                var inputType = false;
                var divisibleNumbers = Helper.GetDivisionNumbers();
                correctAnswer = divisibleNumbers[0] / divisibleNumbers[1];


                while (!inputType)
                {
                    Console.WriteLine($"{divisibleNumbers[0]} ÷ {divisibleNumbers[1]} =");
                    var result = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(result) || !int.TryParse(result, out _))
                    {
                        Console.Clear();
                        Console.WriteLine("Please input a number.");
                    }
                    else
                    {
                        inputType = true;
                        input = result;
                    }
                }

                if (int.Parse(input) == correctAnswer)
                {
                    Console.WriteLine("That's correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine($"That's incorrect, the correct answer was {correctAnswer}.");
                }
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine("-------------------------------------------------------");
                if (i != 9)
                {
                    Console.WriteLine("Press enter for next question.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press enter to see final score.");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine($"Your final score was {score}/10");

            var gameType = "Division";
            databaseOPS.AddGameHistory(gameType, score);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();

        }
    }
}

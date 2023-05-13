using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Menu
    {
        internal void ShowMenu()
        {
            var date = DateTime.Now;
            var isGameOn = true;

            // do while loops will run at least once since condition evaluation is at the end.
            // while loops only run if condition is true from the start.
            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Hello player, it's {date.DayOfWeek}!");

                // Displaying multiline text to the console using @.
                Console.WriteLine($@"What game would you like to play?
A - Addition
S - Subtraction
M - Multiplication
D - Division
V - View Game History
Q - Quit Game");
                Console.WriteLine("-------------------------------------------------------");

                var gameSelected = Console.ReadLine();
                var gameEngine = new GameOperations();
                var databaseOPS = new DatabaseOperations();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        gameEngine.AdditionGame();
                        break;
                    case "s":
                        gameEngine.SubtractionGame();
                        break;
                    case "m":
                        gameEngine.MultiplicationGame();
                        break;
                    case "d":
                        gameEngine.DivisionGame();
                        break;
                    case "v":
                        databaseOPS.PrintGameHistory();
                        break;
                    case "q":
                        Console.WriteLine($"Thank you for playing Nahdaa!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            } while (isGameOn);
        }
    }
}

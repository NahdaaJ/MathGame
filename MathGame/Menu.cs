namespace MathGame
{
    internal class Menu
    {
        internal void ShowMenu()
        {
            var date = DateTime.Now;
            var isGameOn = true;

            var difficulty = "e";
            var diff = "Easy";
           
            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Hello player, it's {date.DayOfWeek}!");

                Console.WriteLine($@"What game would you like to play?
A - Addition
S - Subtraction
M - Multiplication
D - Division

Game is currently in '{diff}' mode!
C - Change Difficulty 
V - View Game History
Q - Quit Game");
                Console.WriteLine("-------------------------------------------------------");

                var gameSelected = Console.ReadLine();
                var gameEngine = new GameOperations();
                var databaseOPS = new DatabaseOperations();
                string input;

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        gameEngine.AdditionGame(difficulty);
                        break;
                    case "s":
                        gameEngine.SubtractionGame(difficulty);
                        break;
                    case "m":
                        gameEngine.MultiplicationGame(difficulty);
                        break;
                    case "d":
                        gameEngine.DivisionGame(difficulty);
                        break;
                    case "v":
                        databaseOPS.PrintGameHistory();
                        break;
                    case "c":
                        DifficultySettings.DifficultyMessage();
                        difficulty = Console.ReadLine().Trim().ToLower();
                        while (difficulty != "e" && difficulty != "m" && difficulty != "h" || String.IsNullOrWhiteSpace(difficulty))
                        {
                            Console.WriteLine("Invalid Input, press enter to try again.");
                            Console.ReadLine();
                            DifficultySettings.DifficultyMessage();
                            difficulty = Console.ReadLine();
                        }
                        if (difficulty == "e")
                            diff = "Easy";
                        else if (difficulty == "m")
                            diff = "Medium";
                        else if (difficulty == "h")
                            diff = "Hard";
                        break;
                    case "q":
                        Console.WriteLine($"Thank you for playing!");
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

namespace MathGame
{
    internal class GameOperations
    {
        internal void AdditionGame(string difficulty)
        {
            var databaseOPS = new DatabaseOperations();
            var random = new Random();
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                string input = "";
                var inputType = false;
                var difficultyNum = new int[2];
                difficultyNum = DifficultySettings.DifficultySetter(difficulty, "a");

                correctAnswer = difficultyNum[0] + difficultyNum[1];

                while (!inputType)
                {
                    Console.WriteLine($"{difficultyNum[0]} + {difficultyNum[1]} =");
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

                if (i != 9) // Displays a different message if it's the last round.
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
            databaseOPS.AddGameHistory(gameType, score, difficulty);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();
        }
        internal void SubtractionGame(string difficulty)
        {
            var databaseOPS = new DatabaseOperations();
            var random = new Random();
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                string input="";
                var inputType = false;
                var difficultyNum = DifficultySettings.DifficultySetter(difficulty, "s");
                correctAnswer = difficultyNum[0] - difficultyNum[1];

                while (!inputType)
                {
                    Console.WriteLine($"{difficultyNum[0]} - {difficultyNum[1]} =");
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

                if (i != 9) // Displays a different message if it's the last round.
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
            databaseOPS.AddGameHistory(gameType, score, difficulty);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();
        }
        internal void MultiplicationGame(string difficulty)
        {
            var databaseOPS = new DatabaseOperations();
            var random = new Random();
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                string input = "";
                var inputType = false;
                var difficultyNum = DifficultySettings.DifficultySetter(difficulty, "m");
                correctAnswer = difficultyNum[0] * difficultyNum[1];

                while (!inputType)
                {
                    Console.WriteLine($"{difficultyNum[0]} x {difficultyNum[1]} =");
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

                if (i != 9) // Displays a different message if it's the last round.
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
            databaseOPS.AddGameHistory(gameType, score, difficulty);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();
        }
        internal void DivisionGame(string difficulty)
        {
            var databaseOPS = new DatabaseOperations();
            int correctAnswer;
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                string input = "";
                var inputType = false;
                var difficultyNum = DifficultySettings.DifficultySetter(difficulty, "d");
                correctAnswer = difficultyNum[0] / difficultyNum[1];


                while (!inputType)
                {
                    Console.WriteLine($"{difficultyNum[0]} ÷ {difficultyNum[1]} =");
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

                if (i != 9) // Displays a different message if it's the last round.
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
            databaseOPS.AddGameHistory(gameType, score, difficulty);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadLine();

        }
    }
}

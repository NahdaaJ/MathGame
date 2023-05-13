using MathGame;
using MySqlConnector;

Menu();

// Separation of Concerns - you want each method to do one specific thing.
// Makes code more organised, easy to read, easy to maintain.

void Menu()
{
    var date = DateTime.Now;
    var isGameOn = true;

    // do while loops will run at least once since condition evaluation is at the end.
    // while loops only run if condition is true from the start.
    do
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine($"Hello Nahdaa. It's {date.DayOfWeek}!");

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

        switch (gameSelected.Trim().ToLower())
        {
            case "a":
                AdditionGame();
                break;
            case "s":
                SubtractionGame();
                break;
            case "m":
                MultiplicationGame();
                break;
            case "d":
                DivisionGame();
                break;
            case "v":
                PrintGameHistory() ;
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
void AdditionGame()
{
    var random = new Random();
    int firstNumber;
    int secondNumber;
    int correctAnswer;
    int score = 0;

    for(int i=0; i < 10; i++)
    {
        Console.Clear();
        firstNumber = random.Next(0, 100);
        secondNumber = random.Next(0, 100);
        correctAnswer = firstNumber + secondNumber;


        Console.WriteLine($"{firstNumber} + {secondNumber} =");
        var result = Console.ReadLine();

        if (int.Parse(result) == correctAnswer)
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
    AddGameHistory(gameType, score);

    Console.WriteLine("Press any key to return to main menu.");
    Console.ReadLine();
}
void SubtractionGame()
{
    var random = new Random();
    int firstNumber;
    int secondNumber;
    int correctAnswer;
    int score = 0;

    for (int i = 0; i < 10; i++)
    {
        Console.Clear();

        var nonNegative = GetSubtractionNumbers();
        correctAnswer = nonNegative[0] - nonNegative[1];


        Console.WriteLine($"{nonNegative[0]} - {nonNegative[1]} =");
        var result = Console.ReadLine();

        if (int.Parse(result) == correctAnswer)
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
    AddGameHistory(gameType, score);

    Console.WriteLine("Press any key to return to main menu.");
    Console.ReadLine();
}
void MultiplicationGame()
{
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


        Console.WriteLine($"{firstNumber} x {secondNumber} =");
        var result = Console.ReadLine();

        if (int.Parse(result) == correctAnswer)
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
    AddGameHistory(gameType, score);

    Console.WriteLine("Press any key to return to main menu.");
    Console.ReadLine();
}
void DivisionGame()
{
    int correctAnswer;
    int score = 0;

    for (int i = 0;i < 10;i++)
    {
        Console.Clear();
        var divisibleNumbers = GetDivisionNumbers();
        correctAnswer = divisibleNumbers[0] / divisibleNumbers[1];
        Console.WriteLine($"{divisibleNumbers[0]} ÷ {divisibleNumbers[1]} =");
        var result = Console.ReadLine();

        if (int.Parse(result) == correctAnswer)
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
    AddGameHistory(gameType, score);

    Console.WriteLine("Press any key to return to main menu.");
    Console.ReadLine();

}

MySqlConnection connectDB()
{
    var conn = Helper.ConnValue("mathgame_db");
    var con = new MySqlConnection(conn);
    con.Open();
    return con;
}

MySqlCommand commandDB()
{
    var con = connectDB();
    var cmd = new MySqlCommand();
    cmd.Connection = con;

    cmd.CommandText = "DELETE FROM game_history WHERE game_date < now() - interval 30 DAY;";
    cmd.ExecuteNonQuery();
    return cmd;
}
void AddGameHistory(string gameType, int score)
{
    var cmd = commandDB();
    var date = DateTime.Now.ToString("yyyy-MM-dd");
    string insertString = $"INSERT INTO game_history (game_date, game_type, score) VALUES('{date}','{gameType}',{score});";
    cmd.CommandText = insertString;
    cmd.ExecuteNonQuery();
}
string[] chooseView()
{
    var choices = new string[2];

    Console.WriteLine(@"Would you like to view:
H - Highest Scores
L - Lowest Scores");
    var highOrLow = Console.ReadLine();

    Console.WriteLine(@"Which game type would you like to view:
A - Addition
S - Subtraction
M - Multiplication
D - Division
G - All Game Types");
    var gameType = Console.ReadLine();

    choices[0] = highOrLow;
    choices[1] = gameType;

    return choices;
}
string ViewGameHistory(string highOrLow, string gameType)
{
    string ascOrDesc;
    string type;

    if (highOrLow.Trim().ToLower() != "h") // CHANGE THESE
        ascOrDesc = "ORDER BY game_date DESC, score ASC";
    else  
        ascOrDesc = "ORDER BY game_date DESC, score DESC";


    if (gameType.Trim().ToLower() == "a")
        type = "WHERE game_type = 'Addition'";
    else if (gameType.Trim().ToLower() == "s")
        type = "WHERE game_type = 'Subtraction'";
    else if (gameType.Trim().ToLower() == "m")
        type = "WHERE game_type = 'Multiplication'";
    else if (gameType.Trim().ToLower() == "d")
        type = "WHERE game_type = 'Division'";
    else { type = ""; }

    var viewString = $"SELECT * FROM game_history\n{type}\n{ascOrDesc};";
    return viewString;
}
void PrintGameHistory()
{
    var con = connectDB();
    var cmd = commandDB();
    var choices = chooseView();
    var viewString = ViewGameHistory(choices[0], choices[1]);

    using var cmd1 = new MySqlCommand(viewString, con);
    using MySqlDataReader rdr = cmd1.ExecuteReader();
    Console.WriteLine();
    Console.WriteLine("---------------- Game History ----------------");
    Console.WriteLine();
    Console.WriteLine("   Date           Game Type           Score   ");
    Console.WriteLine("----------     ---------------     -----------");
    while (rdr.Read())
    {
        // Console.WriteLine($"Date: {rdr.GetDateOnly(0)} Game: {rdr.GetString(1)} Score: {rdr.GetInt32(2)}");
        Console.WriteLine("{0}{1,20}{2,10}", rdr.GetDateOnly(0), rdr.GetString(1), rdr.GetInt32(2));
    }

    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("Press enter to return to main menu.");
    Console.ReadLine();
}
int[] GetDivisionNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(0, 100);
    var secondNumber = random.Next(1, 100);
    var divisibleNumbers = new int[2];

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(0, 100);
        secondNumber = random.Next(1, 100);
    }

    divisibleNumbers[0] = firstNumber;
    divisibleNumbers[1] = secondNumber;
    return divisibleNumbers;
}
int[] GetSubtractionNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(0, 100);
    var secondNumber = random.Next(1, 100);
    var divisibleNumbers = new int[2];

    while (firstNumber < secondNumber)
    {
        firstNumber = random.Next(0, 100);
        secondNumber = random.Next(1, 100);
    }

    divisibleNumbers[0] = firstNumber;
    divisibleNumbers[1] = secondNumber;
    return divisibleNumbers;

}
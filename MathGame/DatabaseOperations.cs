﻿using MySqlConnector;
using System.Drawing;

namespace MathGame
{
    internal class DatabaseOperations
    {

        internal MySqlConnection connectDB()
        {
            var conn = Helper.ConnValue("mathgame_db");
            var con = new MySqlConnection(conn);
            con.Open();
            return con;
        }
        internal MySqlCommand commandDB()
        {
            var con = connectDB();
            var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DELETE FROM game_history WHERE game_date < now() - interval 30 DAY;";
            cmd.ExecuteNonQuery();
            return cmd;
        }
        internal void AddGameHistory(string gameType, int score, string difficulty)
        {
            var cmd = commandDB();
            var date = DateTime.Now.ToString("yyyy-MM-dd"); // Changing the date format so that it fits MySQL syntax.
            string diff="";
            if (difficulty == "e")
                diff = "Easy";
            else if (difficulty == "m")
                diff = "Medium";
            else if (difficulty == "h")
                diff = "Hard";
            string insertString = $"INSERT INTO game_history (game_date, game_type, score, game_difficulty) VALUES('{date}','{gameType}',{score},'{diff}');";
            cmd.CommandText = insertString;
            cmd.ExecuteNonQuery();
        }
        internal string ViewGameHistory(string highOrLow, string gameType)
        {
            string ascOrDesc;
            string type;

            if (highOrLow.Trim().ToLower() != "h")
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
        internal void PrintGameHistory()
        {
            var con = connectDB();
            var cmd = commandDB();
            var choices = Helper.chooseView();
            var viewString = ViewGameHistory(choices[0], choices[1]);

            using var cmd1 = new MySqlCommand(viewString, con);
            using MySqlDataReader rdr = cmd1.ExecuteReader();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("----------------------- Game History -----------------------");
            Console.WriteLine();
            Console.WriteLine("   Date           Game Type          Score       Difficulty");
            Console.WriteLine("----------     ---------------     ---------     ----------");
            while (rdr.Read())
            {
                Console.WriteLine("{0}{1,20}{2,10}{3,15}", rdr.GetDateOnly(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3));
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
        }
    }
}

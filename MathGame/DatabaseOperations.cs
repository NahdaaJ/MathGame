using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal void AddGameHistory(string gameType, int score)
        {
            var cmd = commandDB();
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            string insertString = $"INSERT INTO game_history (game_date, game_type, score) VALUES('{date}','{gameType}',{score});";
            cmd.CommandText = insertString;
            cmd.ExecuteNonQuery();
        }
        internal string ViewGameHistory(string highOrLow, string gameType)
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
    }
}

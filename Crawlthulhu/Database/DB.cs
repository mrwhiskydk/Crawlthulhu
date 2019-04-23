using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class DB
    {
        private const String CONNECTIONSTRING = @"Data Source=Crawlthulhu.db;version=3;New=true;Compress=true";
        private SQLiteConnection connection = new SQLiteConnection(CONNECTIONSTRING);

        public DB()
        {
            connection.Open();

            List<string> createDatabse = new List<string>();
            createDatabse.Add("CREATE TABLE IF NOT EXISTS Bruger (navn VARCHAR(50) primary key);");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS Highscore (id integer primary key, score integer, navn VARCHAR(50));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS Collection (id integer primary key, navn VARCHAR(50));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS Figur (id integer primary key, navn VARCHAR(50));");
            SQLiteCommand cmd = connection.CreateCommand();
            foreach (var sql in createDatabse)
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public int[] GetFigure(string navn)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT id FROM Figur where navn={navn}";
            cmd.CommandText = sql;

            int[] result = new int[4];
            SQLiteDataReader reader = cmd.ExecuteReader();

            for (int i = 0; i <= reader.FieldCount+1; i++)
            {
                result[i] = reader.GetInt32(0);
            }

            connection.Close();
            return result;
        }

        public int[] GetUnlockedCharacter(string navn)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT id FROM karakter WHERE navn = {navn}";
            int[] result = new int[4];
            SQLiteDataReader reader = cmd.ExecuteReader();

            for (int i = 0; i <= reader.FieldCount+1; i++)
            {
                result[i] = reader.GetInt32(0);
            }

            connection.Close();
            return result;
        }

        public string[] GetHighscoreTop10()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = "SELECT * FROM highscore";
            cmd.CommandText = sql;
            string[] array = new string[10];
            SQLiteDataReader reader = cmd.ExecuteReader();

            for (int i = 0; i <= reader.FieldCount+1; i++)
            {
                reader.Read();
                array[i] = $"{reader.GetInt32(0).ToString()} {reader.GetInt32(1).ToString()} {reader.GetString(2)}";
            }
            /*foreach (var item in array)
            {
                Console.WriteLine(item);
            }*/
            connection.Close();
            return array;
        }

        public int[] GetCollection(string navn)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT * FROM collection WHERE navn = {navn}";
            cmd.CommandText = sql;
            int[] result = new int[10];
            SQLiteDataReader reader = cmd.ExecuteReader();

            for (int i = 0; i <= reader.FieldCount+1; i++)
            {
                reader.Read();
                result[i] = reader.GetInt32(0);
            }

            connection.Close();
            return result;
        }

        public void Login(string navn)
        {
            connection.Open();
            string sql = "INSERT OR IGNORE INTO bruger (navn) VALUES ('"+navn+"');";
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}

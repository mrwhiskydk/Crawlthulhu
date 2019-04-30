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
        private const string CONNECTIONSTRING = @"Data Source=Crawlthulhu.db;version=3;New=true;Compress=true";
        private SQLiteConnection connection = new SQLiteConnection(CONNECTIONSTRING);

        public DB()
        {
            connection.Open();

            List<string> createDatabse = new List<string>();
            createDatabse.Add("CREATE TABLE IF NOT EXISTS user (name VARCHAR(12) primary key CHECK(name is not null AND length(name) <= 12));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS highscore (id integer primary key, score integer, name VARCHAR(12) CHECK(name is not null AND length(name) <= 12));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS collection (id integer primary key, name VARCHAR(12) CHECK(name is not null AND length(name) <= 12));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS figure (id integer primary key, name VARCHAR(12) CHECK(name is not null AND length(name) <= 12));");
            SQLiteCommand cmd = connection.CreateCommand();
            foreach (var sql in createDatabse)
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public int[] GetFigure(string name)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT id FROM Figure where name={name}";
            cmd.CommandText = sql;

            int[] result = new int[4];
            SQLiteDataReader reader = cmd.ExecuteReader();

            int counter = 0;
            while (reader.Read())
            {
                result[counter] = reader.GetInt32(0);
                counter++;
            }

            connection.Close();
            return result;
        }

        public int[] GetUnlockedCharacter(string name)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT id FROM character WHERE name = {name}";
            int[] result = new int[4];
            SQLiteDataReader reader = cmd.ExecuteReader();

            int counter = 0;
            while (reader.Read())
            {
                result[counter] = reader.GetInt32(0);
                counter++;
            }

            connection.Close();
            return result;
        }

        public void SetUnlockedCharacter(string name, int nr)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"INSERT INTO ";
        }

        public string[] GetHighscoreTop10()
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = "SELECT score, name FROM highscore ORDER BY score DESC";
            cmd.CommandText = sql;
            string[] result = new string[10];
            SQLiteDataReader reader = cmd.ExecuteReader();

            int counter = 0;
            while (reader.Read())
            {
                result[counter] = $"{counter + 1} {reader.GetInt32(0).ToString()} {reader.GetString(1)}";
                counter++;
            }

            
            /*foreach (var item in array)
            {
                Console.WriteLine(item);
            }*/
            connection.Close();
            return result;
        }

        public int[] GetCollection(string name)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT * FROM collection WHERE name = {name}";
            cmd.CommandText = sql;
            int[] result = new int[10];
            SQLiteDataReader reader = cmd.ExecuteReader();

            int counter = 0;
            while (reader.Read())
            {
                result[counter] = reader.GetInt32(0);
                counter++;
            }

            connection.Close();
            return result;
        }

        public void Login(string name)
        {
            connection.Open();
            string sql = "INSERT OR IGNORE INTO user (name) VALUES ('"+name+"');";
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}

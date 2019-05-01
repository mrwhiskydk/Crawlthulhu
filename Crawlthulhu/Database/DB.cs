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
            createDatabse.Add("CREATE TABLE IF NOT EXISTS user (name VARCHAR(12) primary key CHECK(name is not null AND length(name) <= 12 AND length(name) >= 1));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS highscore (id integer NOT NULL PRIMARY KEY, score integer, name VARCHAR(12) CHECK(name is not null AND length(name) <= 12 AND length(name) >= 1));");
            createDatabse.Add("CREATE TABLE IF NOT EXISTS collection (name VARCHAR(12) CHECK(name is not null AND length(name) <= 12 AND length(name) >= 1), id integer NOT NULL, PRIMARY KEY (name, id));");
            //createDatabse.Add("CREATE TABLE IF NOT EXISTS figure (name VARCHAR(12) primary key CHECK(name is not null AND length(name) <= 12 AND length(name) >= 1), id integer primary key);");
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

            string sql = $"SELECT id FROM Figure where name = '"+name+"'";
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

            string sql = $"SELECT id FROM character WHERE name = '"+name+"'";
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

        public void InsertHighscore(string name, int score)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"INSERT INTO highscore (score, name) VALUES ({score}, '"+name+"')";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public int[] GetCollection(string name)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            string sql = $"SELECT * FROM collection WHERE name = '"+name+"'";
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

        public void InsertCollection(string name, int[] array)
        {
            connection.Open();
            SQLiteCommand cmd = connection.CreateCommand();

            foreach (var item in array)
            {
                string sql = $"INSERT OR IGNORE INTO collection (name, id) VALUES ('"+name+"')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public void Login(string name)
        {
            connection.Open();

            string sql = "INSERT OR IGNORE INTO user (name) VALUES ('"+name+"');";
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}

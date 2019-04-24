using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class Controller
    {
        DB db;

        public Controller()
        {
            db = new DB();
        }

        public int[] GetFigure(string name)
        {
            return db.GetFigure(name);
        }

        public int[] GetUnlockedCharacter(string name)
        {
            return db.GetUnlockedCharacter(name);
        }

        public string[] GetHighscoreTop10()
        {
            return db.GetHighscoreTop10();
        }

        public int[] GetCollection(string name)
        {
            return db.GetCollection(name);
        }

        public void Login(string name)
        {
            db.Login(name);
        }
    }
}

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

        public int[] GetFigure(string navn)
        {
            return db.GetFigure(navn);
        }

        public int[] GetUnlockedCharacter(string navn)
        {
            return db.GetUnlockedCharacter(navn);
        }

        public string[] GetHighscoreTop10()
        {
            return db.GetHighscoreTop10();
        }

        public int[] GetCollection(string navn)
        {
            return db.GetCollection(navn);
        }

        public void Login(string navn)
        {
            db.Login(navn);
        }
    }
}

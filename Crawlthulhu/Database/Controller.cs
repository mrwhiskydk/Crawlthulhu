using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class Controller
    {
        private static Controller instance;
        DB db;
        UI ui;

        public static Controller Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        private Controller()
        {
            db = new DB();
            ui = GameWorld.Instance.ui;
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

        public void InsertHighscore(string name, int score)
        {
            db.InsertHighscore(name, score);
        }

        public int[] GetCollection(string name)
        {
            return db.GetCollection(name);
        }

        public void Login(string name)
        {
            GameWorld.Instance.playerName = name;
            ui.ChangeState(ui.stateIngame);
        }
    }
}

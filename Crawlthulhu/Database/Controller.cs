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

        /*public int[] GetFigure(string name)
        {
            return db.GetFigure(name);
        }*/

        /*public int[] GetUnlockedCharacter(string name)
        {
            return db.GetUnlockedCharacter(name);
        }*/

        public string[] GetHighscoreTop10()
        {
            return db.GetHighscoreTop10();
        }

        public void InsertHighscore(string name, int score)
        {
            db.InsertHighscore(name, score);
        }

        public void GetCollection(string name)
        {
            List<int> result = db.GetCollection(name);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            GameWorld.Instance.collectables = result;
            if (result.Count > 0)
            {
                OtherObjectFactory.Instance.collectableList = result.Max() + 1;
            }
        }

        public void InsertCollection(string name, int id)
        {
            db.InsertCollection(name, id);
        }

        public void Login(string name)
        {
            if (name == "")
            {
                name = "noob";
            }
            db.Login(name);
            GameWorld.Instance.playerName = name;
            ui.ChangeState(ui.stateIngame);
        }
    }
}

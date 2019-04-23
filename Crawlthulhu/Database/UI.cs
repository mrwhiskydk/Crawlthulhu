using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class UI
    {
        Controller controller;

        string[] highscore;
        public UI()
        {
            controller = new Controller();
            highscore = controller.GetHighscoreTop10();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameWorld.fontBig,
                $"{highscore[0]}\n{highscore[1]}\n{highscore[2]}\n{highscore[3]}\n{highscore[4]}\n{highscore[5]}\n{highscore[6]}\n{highscore[7]}\n{highscore[8]}\n{highscore[9]}\n",
                new Vector2(10, 10), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }
    }
}

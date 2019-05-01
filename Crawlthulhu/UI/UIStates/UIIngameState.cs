using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class UIIngameState : IUIState
    {
        List<GameObject> elements = new List<GameObject>();

        public UIIngameState(ContentManager content)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void Enter()
        {
            
        }

        public void Execute(GameTime gameTime)
        {
            foreach (GameObject element in elements)
            {
                element.Update(gameTime);
            }
        }

        public void Exit()
        {
            
        }
    }
}

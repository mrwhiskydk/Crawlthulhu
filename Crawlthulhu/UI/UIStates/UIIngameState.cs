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
            elements.Add(UIFactory.Instance.CreateSprite("bone_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.4f), 8));
            elements.Add(UIFactory.Instance.CreateSprite("ancient_scroll_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.4f), 8));
            elements.Add(UIFactory.Instance.CreateSprite("black_pearl_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.4f), 8));
            elements.Add(UIFactory.Instance.CreateSprite("blood_of_cthulu_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.4f), 8));
            elements.Add(UIFactory.Instance.CreateSprite("coin_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.4f), 8));

            foreach (GameObject gameObject in elements)
            {
                gameObject.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject element in elements)
            {
                element.Draw(spriteBatch);
            }
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

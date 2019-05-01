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
        List<GameObject> collectables = new List<GameObject>();
        List<GameObject> collected = new List<GameObject>();

        public UIIngameState(ContentManager content)
        {
            collectables.Add(UIFactory.Instance.CreateSprite("bone_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.95f, GameWorld.Instance.worldSize.Y * 0.1f), 8));
            collectables.Add(UIFactory.Instance.CreateSprite("ancient_scroll_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.95f, GameWorld.Instance.worldSize.Y * 0.15f), 8));
            collectables.Add(UIFactory.Instance.CreateSprite("black_pearl_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.95f, GameWorld.Instance.worldSize.Y * 0.2f), 8));
            collectables.Add(UIFactory.Instance.CreateSprite("blood_of_cthulu_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.95f, GameWorld.Instance.worldSize.Y * 0.25f), 8));
            collectables.Add(UIFactory.Instance.CreateSprite("coin_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.95f, GameWorld.Instance.worldSize.Y * 0.3f), 8));
            collectables.Add(UIFactory.Instance.CreateSprite("cursed_skull_ani", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.95f, GameWorld.Instance.worldSize.Y * 0.35f), 8));

            foreach (GameObject gameObject in elements)
            {
                gameObject.LoadContent(content);
            }

            foreach (GameObject gameObject in collectables)
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

            foreach (GameObject element in collected)
            {
                element.Draw(spriteBatch);
            }
        }

        public void Enter()
        {
            UpdateCollectables();
        }

        public void UpdateCollectables()
        {
            collected.Clear();
            foreach (var item in GameWorld.Instance.collectables)
            {
                collected.Add(collectables[item]);
                Console.WriteLine(item);
            }
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

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
    public class UI
    {
        public static IUIState currentState;
        public UIMainMenuState stateMainMenu;
        UICharacterSelectState stateCharacterSelect;
        public UIIngameState stateIngame;
        List<GameObject> elementsPersistent = new List<GameObject>();

        public UI()
        {
            
        }

        public void ChangeState(IUIState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            
            currentState = newState;
            currentState.Enter();
        }

        public void Update(GameTime gameTime)
        {
            currentState.Execute(gameTime);
        }

        public void LoadContent(ContentManager content)
        {
            stateMainMenu = new UIMainMenuState(content);
            stateCharacterSelect = new UICharacterSelectState(content);
            stateIngame = new UIIngameState(content);
            ChangeState(stateMainMenu);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject element in elementsPersistent)
            {
                element.Draw(spriteBatch);
            }

            if (currentState != null)
            {
                currentState.Draw(spriteBatch);
            }
            //test
            //ayylmao
            //Random rnd = new Random();
            //Color[] colors = { Color.Gold, Color.Red, Color.Blue, Color.Black, Color.Purple, Color.Pink, Color.HotPink, Color.Green };
            //for (int i = 0; i < 5000; i++)
            //{
            //    spriteBatch.DrawString(GameWorld.font, "Error", new Vector2(rnd.Next(0, (int)GameWorld.Instance.worldSize.X), rnd.Next(0, (int)GameWorld.Instance.worldSize.Y)), colors[rnd.Next(0, 8)], 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            //}
        }
    }
}

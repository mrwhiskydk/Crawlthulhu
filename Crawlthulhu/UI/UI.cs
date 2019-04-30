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
        IUIState currentState;
        UIMainMenuState stateMainMenu;
        UICharacterSelectState stateCharacterSelect;
        UIIngameState stateIngame;
        List<GameObject> elements = new List<GameObject>();
        List<GameObject> elementsPersistent = new List<GameObject>();

        public UI()
        {
            //ChangeState(stateMainMenu);
        }

        public void ChangeState(IUIState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            elements = currentState.Enter();
        }

        public void Update(GameTime gameTime)
        {
            currentState.Execute();
        }

        public void LoadContent(ContentManager content)
        {
            stateMainMenu = new UIMainMenuState(content);
            stateCharacterSelect = new UICharacterSelectState(content);
            stateIngame = new UIIngameState(content);
            //ChangeState(stateMainMenu);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject element in elements)
            {
                element.Draw(spriteBatch);
            }

            if (currentState != null)
            {
                currentState.Draw(spriteBatch);
            }
        }
    }
}

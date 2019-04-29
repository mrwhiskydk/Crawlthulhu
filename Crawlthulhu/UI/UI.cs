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
        List<Sprite> elements = new List<Sprite>();
        
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
            elements.Clear();
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
            ChangeState(stateMainMenu);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite element in elements)
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

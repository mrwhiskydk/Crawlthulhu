using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crawlthulhu
{
    public class UIMainMenuState : IUIState
    {
        //EventHandler<TextInputEventArgs> onTextEntered;
        List<GameObject> elements = new List<GameObject>();
        static StringBuilder stringBuilder = new StringBuilder(12, 12);
        string[] highscore;

        public UIMainMenuState(ContentManager content)
        {
            //subscribe to monogames key/text event
            GameWorld.Instance.Window.TextInput += HandleTextInput;

            elements.Add(UIFactory.Instance.Create("sprite", "TextBox", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.4f)));
            elements.Add(UIFactory.Instance.Create("button", "buttonlogin", 0.99f, new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.7f)));

            foreach (GameObject gameObject in elements)
            {
                gameObject.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Display text input for the users name
            spriteBatch.DrawString(GameWorld.font4x, stringBuilder.ToString(), new Vector2(GameWorld.Instance.worldSize.X * 0.4f, GameWorld.Instance.worldSize.Y * 0.36f), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            //Display highscore
            spriteBatch.DrawString(GameWorld.font2x,
                $"{highscore[0]}\n{highscore[1]}\n{highscore[2]}\n{highscore[3]}\n{highscore[4]}\n{highscore[5]}\n{highscore[6]}\n{highscore[7]}\n{highscore[8]}\n{highscore[9]}\n",
                new Vector2(10, 10), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1);
        }

        public List<GameObject> Enter()
        {
            highscore = Controller.Instance.GetHighscoreTop10();
            return elements;
        }

        public void Execute()
        {
            /*Keys[] keys = Keyboard.GetState().GetPressedKeys();
            //if any key is pressed
            if (keys.Length > 0)
            {
                //append the first key in the array to our stringbuilder
                stringBuilder.Append(keys[0]);
            }*/
        }

        public void Exit()
        {
            
        }

        public void HandleTextInput(object sender, TextInputEventArgs e)
        {
            if (e.Character == (char)Keys.Back && stringBuilder.Length > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            else if (stringBuilder.Length < stringBuilder.MaxCapacity && GameWorld.font4x.Characters.Contains(e.Character))
            {
                stringBuilder.Append(e.Character);
            }
        }
    }
}

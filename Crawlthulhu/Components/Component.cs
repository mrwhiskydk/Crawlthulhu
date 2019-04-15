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
    public abstract class Component
    {
        private GameObject gameObject;

        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
            set
            {
                this.gameObject = value;
            }
        } 

        /// <summary>
        /// Attaches the Components to current GameObject
        /// </summary>
        /// <param name="gameObject"></param>
        public virtual void Attach(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        /// <summary>
        /// Loads the content of current Component, to the game 
        /// </summary>
        /// <param name="content"></param>
        public virtual void LoadContent(ContentManager content)
        {

        }

        /// <summary>
        /// Updates current Component's game logic
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Used for drawing out current component to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}

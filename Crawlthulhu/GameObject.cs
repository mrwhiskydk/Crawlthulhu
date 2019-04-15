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
    public class GameObject
    {
        private List<Component> components = new List<Component>();


        /// <summary>
        /// GameObject's Constructor
        /// </summary>
        public GameObject()
        {

        }

        public void LoadContent(ContentManager content)
        {
            foreach(Component component in components)
            {
                component.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Component component in components)
            {
                component.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Component component in components)
            {
                component.Draw(spriteBatch);
            }
        }

        public void AddComponent(Component component)
        {
            component.Attach(this);
            components.Add(component);
        }

        public Component GetComponent(string component)
        {
            return components.Find(x => x.GetType().Name == component);
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

    }
}

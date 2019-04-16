using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class Player : Component
    {
        private static Player instance;

        private Vector2 position;

        private Transform transform;

        private float movementspeed = 20;

        public static Player Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Player(Vector2.Zero);
                }
                return instance;
            }
        }

        private Player(Vector2 startposition)
        {
            position = startposition;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Movement(gameTime);
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            gameObject.Transform.Position = position;
        }

        public void Movement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //GameObject.Transform.Translate
            }
        }

    }
}

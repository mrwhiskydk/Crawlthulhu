using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class Crosshair : Component
    {
        private static Crosshair instance;

        public Vector2 Position { get; set; }

        public static Crosshair Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Crosshair(Vector2.Zero);
                }
                return instance;
            }
        }

        private Crosshair(Vector2 startPos)
        {
            startPos = new Vector2(GameWorld.Instance.worldSize.X * 0.7f, GameWorld.Instance.worldSize.Y * 0.7f);
        }

        public override void Update(GameTime gameTime)
        {
            GameObject.Transform.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            base.Update(gameTime);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            //check for collisions with buttons
            
        }
    }
}

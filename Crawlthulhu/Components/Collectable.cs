using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawlthulhu
{
    public class Collectable : Component
    {

        private bool followPlayer = false;

        public Collectable()
        {
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            int distance = (int)Vector2.Distance(GameObject.Transform.Position, Player.Instance.GameObject.Transform.Position);
            Vector2 direction = Player.Instance.GameObject.Transform.Position - GameObject.Transform.Position;
            direction.Normalize();

            if (distance < 150)
            {
                followPlayer = true;
            }

            if (followPlayer)
            {
                GameObject.Transform.Position += direction * 4;
            }
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            if (other == Player.Instance.GameObject.GetComponent("Collider"))
            {
                GameWorld.Instance.RemoveObjects.Add(GameObject);
            }
        }
    }
}

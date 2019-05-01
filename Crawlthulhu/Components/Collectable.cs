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

        public void Reset()
        {
            OtherObjectFactory.Instance.CollectableType = null;
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
                int id = 0;
                GameWorld.Instance.Score += 150;
                Door.Instance.GameObject.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 38);
                DoorTrigger.Instance.GameObject.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, -50);
                Player.Instance.Health += 2;
                if (OtherObjectFactory.Instance.collectableList == 1)
                {
                    GameWorld.Instance.collectables[0] = 1;
                    id = 1;
                }
                else if (OtherObjectFactory.Instance.collectableList == 2)
                {
                    GameWorld.Instance.collectables[1] = 2;
                    id = 2;
                }
                else if (OtherObjectFactory.Instance.collectableList == 3)
                {
                    GameWorld.Instance.collectables[2] = 3;
                    id = 3;
                }
                else if (OtherObjectFactory.Instance.collectableList == 4)
                {
                    GameWorld.Instance.collectables[3] = 4;
                    id = 4;
                }
                else if (OtherObjectFactory.Instance.collectableList == 5)
                {
                    GameWorld.Instance.collectables[4] = 5;
                    id = 5;
                }
                else if (OtherObjectFactory.Instance.collectableList == 6)
                {
                    GameWorld.Instance.collectables[5] = 6;
                    id = 6;
                }
                OtherObjectFactory.Instance.collectableList++;
                GameWorld.Instance.RemoveObjects.Add(GameObject);
                GameWorld.Instance.ui.stateIngame.UpdateCollectables();
                Controller.Instance.InsertCollection(GameWorld.Instance.playerName, id);
            }
        }
    }
}

﻿using System;
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
                if (OtherObjectFactory.Instance.collectableList == 1)
                {
                    GameWorld.Instance.collectables[0] = new string[3] {"1", "Bone of death", "bone_ani" };
                }
                else if (OtherObjectFactory.Instance.collectableList == 2)
                {
                    GameWorld.Instance.collectables[1] = new string[3] { "2", "Page of the Necronomicon", "ancient_scroll_ani" };
                }
                else if (OtherObjectFactory.Instance.collectableList == 3)
                {
                    GameWorld.Instance.collectables[2] = new string[3] { "3", "Orb of destruction", "black_pearl_ani" };
                }
                else if (OtherObjectFactory.Instance.collectableList == 4)
                {
                    GameWorld.Instance.collectables[3] = new string[3] { "4", "Blood of Cthulhu", "blood_of_cthulu_ani" };
                }
                else if (OtherObjectFactory.Instance.collectableList == 5)
                {
                    GameWorld.Instance.collectables[4] = new string[3] { "5", "Coin of destiny", "coin_ani" };
                }
                GameWorld.Instance.RemoveObjects.Add(GameObject);
            }
        }
    }
}

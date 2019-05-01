using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyProjectile : Component
    {
        private float speed;

        private Vector2 direction;
        private Vector2 target = Vector2.Zero;

        public EnemyProjectile(float speed)
        {
            this.speed = speed;
        }

        public void Reset()
        {
            direction = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            if (GameObject.Transform.Position.X > 1920 || GameObject.Transform.Position.X < 0 || GameObject.Transform.Position.Y > 1080 || GameObject.Transform.Position.Y < 0)
            {
                SpellPool.Instance.ReleaseObject(GameObject);
            }
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public void Move()
        {
            if (direction == Vector2.Zero)
            {
                target = Player.Instance.GameObject.Transform.Position;
                direction = target - GameObject.Transform.Position;
            }

            direction.Normalize();

            direction *= speed;

            GameObject.Transform.Position += (direction * GameWorld.Instance.deltaTime);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            if(other == Player.Instance.GameObject.GetComponent("Collider"))
            {
                Player.Instance.Health -= 1;
                Player.Instance.takenDMG = true;
                SpellPool.Instance.ReleaseObject(GameObject);
            }
            else
            {
                return;
            }
        }
    }
}

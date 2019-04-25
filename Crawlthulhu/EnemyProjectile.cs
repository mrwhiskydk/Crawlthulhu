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
        private static EnemyProjectile instance;

        public static EnemyProjectile Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EnemyProjectile();
                }
                return instance;
            }
        }

        private float speed;

        private Vector2 direction;
        private Vector2 startPos;
        private Vector2 target;

        private EnemyProjectile()
        {
            speed = 250; 
        }

        public override void Update(GameTime gameTime)
        {
            Move();

            base.Update(gameTime);
        }

        public void Move()
        {
            if(direction == Vector2.Zero)
            {
                target = Player.Instance.GameObject.Transform.Position;
                direction = target - GameObject.Transform.Position;
            }

            direction.Normalize();
            direction *= speed;

            GameObject.Transform.Position += (direction * GameWorld.Instance.deltaTime);
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            GameObject.Transform.Position = startPos;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);
        }
    }
}

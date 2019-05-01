using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class Projectile : Component
    {

        private Vector2 target = Vector2.Zero;

        private Vector2 velocity;

        public Vector2 startPos;

        private float speed;


        public Projectile(float speed)
        {
            this.speed = speed;
        }

        public void Reset()
        {
            velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            if (GameObject.Transform.Position.X > 1920 || GameObject.Transform.Position.X < 0 || GameObject.Transform.Position.Y > 1080 || GameObject.Transform.Position.Y < 0)
            {
                ProjectilePool.Instance.ReleaseObject(GameObject);
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
            if (velocity == Vector2.Zero)
            {
                target = Crosshair.Instance.GameObject.Transform.Position;
                velocity = target - GameObject.Transform.Position;
            }

            velocity.Normalize();

            velocity *= speed;

            GameObject.Transform.Position += (velocity * GameWorld.Instance.deltaTime);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            //if (other.GameObject.GetComponent("EnemyMelee") != null || other.GameObject.GetComponent("EnemyRanged") != null)
            //{
            //    ProjectilePool.Instance.ReleaseObject(GameObject);

            //}
            //else
            //{
            //    return;
            //}

        }
    }
}

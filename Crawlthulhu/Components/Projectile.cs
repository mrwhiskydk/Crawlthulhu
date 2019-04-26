﻿using Microsoft.Xna.Framework;
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
        private static Projectile instance;

        private Vector2 target = Vector2.Zero;

        private Vector2 velocity;

        public Vector2 startPos;

        private float speed;

        public static Projectile Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Projectile(1000);
                }
                return instance;
            }
        }

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

            //if (other.GameObject.GetComponent("EnemyMelee") == GameObject.GetComponent("Collider"))
            //{
            //    ProjectilePool.Instance.ReleaseObject(GameObject);
            //}
            foreach (Collider col in GameWorld.Instance.Colliders)
            {
                other = col;

                if (other != this.GameObject.GetComponent("Collider"))
                {
                    if (other == Player.Instance.GameObject.GetComponent("Collider"))
                    {
                        ProjectilePool.Instance.ReleaseObject(GameObject);
                    }
                    if (other == Enemy.Instance.GameObject.GetComponent("Collider"))
                    {
                        other.DoCollisionChecks = true;
                        Enemy.Instance.enemyHealth -= Player.Instance.dmg;
                    }
                }
            }

        }
    }
}

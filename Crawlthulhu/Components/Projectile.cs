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
        //private static Projectile instance;

        private Vector2 target = Vector2.Zero;

        private Vector2 velocity;

        private Vector2 startPos;

        private float speed;

        //public static Projectile Instance
        //{
        //    get
        //    {
        //        if (instance is null)
        //        {
        //            instance = new Projectile();
        //        }
        //        return instance;
        //    }
        //}

        public Projectile(float speed)
        {
            this.speed = speed;
        }

        public void Reset()
        {
            GameObject.Transform.Position = Player.Instance.GameObject.Transform.Position;
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
            gameObject.Transform.Position = startPos;
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
    }
}

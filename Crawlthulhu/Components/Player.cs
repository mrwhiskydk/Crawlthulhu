using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        public Vector2 velocity;

        private float shootCooldown = 0;

        public float fireRate = 0.5f;

        public bool takenDMG = false;

        private float dmgTimer;

        private float movementspeed = 500;

        public int health;

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
            health = 10;
        }

        public void Shoot()
        {
            if (shootCooldown > fireRate)
            {
                GameWorld.Instance.NewObjects.Add(ProjectilePool.Instance.GetObject());
                shootCooldown = 0;
            }
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Movement(Vector2.Zero);
            ImmortalTime();
            shootCooldown += GameWorld.Instance.deltaTime;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Shoot();
            }
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            gameObject.Transform.Position = position;
        }

        public void Movement(Vector2 velocity)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= movementspeed;

            GameObject.Transform.Translate(velocity * GameWorld.Instance.deltaTime);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            //if (other == Enemy.Instance.GameObject.GetComponent("Collider") && takenDMG is false)
            //{
            //    health -= 1;
            //    takenDMG = true;
            //}
        }

        public void ImmortalTime()
        {
            if (takenDMG)
            {
                dmgTimer += GameWorld.Instance.deltaTime;
                if (dmgTimer > 1)
                {
                    takenDMG = false;
                }
            }
        }

    }
}

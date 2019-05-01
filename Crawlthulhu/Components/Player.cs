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
    delegate void DeadEventHandlerPlayer(GameObject player);

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

        private int health;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health <= 0)
                {
                    OnDeadEvent();
                }
            }
        }

        public int dmg;

        private DeadEventHandlerPlayer DeadEvent;

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
            dmg = 1;
        }

        protected virtual void OnDeadEvent()
        {
            if (DeadEvent != null)
            {
                DeadEvent(GameObject);
            }
        }

        private void ReactToDead(GameObject player)
        {
            GameWorld.Instance.ui.ChangeState(GameWorld.Instance.ui.stateMainMenu);

            GameWorld.Instance.Score = 0;
        }

        public void Shoot()
        {
            if (shootCooldown > fireRate)
            {
                GameObject bullet = ProjectilePool.Instance.GetObject();
                bullet.Transform.Position = GameObject.Transform.Position;
                GameWorld.Instance.NewObjects.Add(bullet);
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
            Vector2[] steps = new Vector2[5];

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    Vector2 points = new Vector2(GameObject.Transform.Position.X + steps[i].X, 0);

                    if(points.X < GameWorld.Instance.worldSize.X * 0.98f)
                    {
                        velocity += new Vector2(1, 0);
                    }
                    else
                    {
                        return;
                    }
                }               
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    Vector2 points = new Vector2(GameObject.Transform.Position.X - steps[i].X, 0);

                    if(points.X > GameWorld.Instance.worldSize.X * 0.02f)
                    {
                        velocity += new Vector2(-1, 0);
                    }
                    else
                    {
                        return;
                    }
                }              
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    Vector2 points = new Vector2(0, GameObject.Transform.Position.Y - steps[i].Y);

                    if(points.Y > GameWorld.Instance.worldSize.Y * 0.04f)
                    {
                        velocity += new Vector2(0, -1);
                    }
                    else
                    {
                        return;
                    }
                }               
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    Vector2 points = new Vector2(0, GameObject.Transform.Position.Y + steps[i].Y);

                    if(points.Y < GameWorld.Instance.worldSize.Y * 0.85f)
                    {
                        velocity += new Vector2(0, 1);
                    }
                    else
                    {
                        return;
                    }
                }

                
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

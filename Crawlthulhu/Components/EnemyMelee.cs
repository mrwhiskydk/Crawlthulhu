using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyMelee : Component
    {
        //private static EnemyMelee instance;

        //public static EnemyMelee Instance
        //{
        //    get
        //    {
        //        if(instance == null)
        //        {
        //            instance = new EnemyMelee(150f, 3);
        //        }
        //        return instance;
        //    }
        //}

        private float enemySpeed;
        public int enemyHealth { get; set; }

        private Vector2 startPos;
        public Vector2 velociy;

        private IEnemyState currentState;

        public EnemyMelee(float speed, int health)
        {
            this.enemySpeed = speed;
            this.enemyHealth = health;

            ChangeState(new EnemyIdleState());
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Execute();

            if(enemyHealth <= 0)
            {
                MeleeEnemyPool.Instance.ReleaseObject(GameObject);
            }

            base.Update(gameTime);
        }

        public void Reset()
        {

        }

        public void ChangeState(IEnemyState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter(this, null);
        }

        public void MeleeMovement()
        {
            int distance = (int)Vector2.Distance(GameObject.Transform.Position, Player.Instance.GameObject.Transform.Position);

            velociy = Player.Instance.GameObject.Transform.Position - GameObject.Transform.Position;
            velociy.Normalize();

            if (distance <= 250)
            {
                velociy *= enemySpeed * 2;
            }
            else if (distance > 250)
            {
                velociy *= enemySpeed;
            }

            GameObject.Transform.Position += (velociy * GameWorld.Instance.deltaTime);
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            gameObject.Transform.Position = startPos;
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            if (other == Player.Instance.GameObject.GetComponent("Collider"))
            {
                Player.Instance.health -= 1;
                Player.Instance.takenDMG = true;
                ChangeState(new EnemyIdleState());
            }
            else if (other.GameObject.GetComponent("Projectile") != null)
            {
                enemyHealth -= 1;
                //ProjectilePool.Instance.ReleaseObject(other.GameObject);
            }
            else
            {
                return;
            }


        }

    }
}

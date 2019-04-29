using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawlthulhu
{
    public class EnemyRanged : Component
    {
        //private static EnemyRanged instance;

        //public static EnemyRanged Instance
        //{
        //    get
        //    {
        //        if(instance == null)
        //        {
        //            instance = new EnemyRanged(100, 3);
        //        }
        //        return instance;
        //    }
        //}

        private float fireTime;
        private float fireCD = 0.5f;

        private float enemySpeed;
        private int enemyHealth { get; set; }

        private Vector2 startPos;
        public Vector2 velociy;

        private IEnemyState currentState;

        public EnemyRanged(float speed, int health)
        {
            this.enemySpeed = speed;
            this.enemyHealth = health;

            ChangeState(new EnemyRangedState());
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Execute();

            fireTime += GameWorld.Instance.deltaTime;

            if(fireTime >= fireCD)
            {
                RangedShoot();
                fireTime = 0;
            }

            if (enemyHealth <= 0)
            {
                RangedEnemyPool.Instance.ReleaseObject(GameObject);
            }

            base.Update(gameTime);
        }

        public void ChangeState(IEnemyState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter(null, this);
        }

        public void Reset()
        {

        }

        public void RangedMovement()
        {
            velociy.Normalize();

            velociy *= enemySpeed;

            GameObject.Transform.Position += (velociy * GameWorld.Instance.deltaTime);
        }

        private void RangedShoot()
        {
            GameObject bullet = SpellPool.Instance.GetObject();
            bullet.Transform.Position = GameObject.Transform.Position;
            GameWorld.Instance.NewObjects.Add(bullet);
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

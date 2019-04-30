using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawlthulhu
{
    delegate void DeadEventHandlerRanged(GameObject enemyRanged);

    public class EnemyRanged : Component
    {

        private float fireTime;
        private float fireCD = 0.5f;

        private float enemySpeed;

        private int enemyHealth;

        public int EnemyHealth
        {
            get
            {
                return enemyHealth;
            }
            set
            {
                enemyHealth = value;
                if(enemyHealth <= 0)
                {
                    OnDeadEvent();
                }
            }
        }

        public Vector2 velociy;

        private event DeadEventHandlerRanged DeadEvent;

        private IEnemyState currentState;

        public EnemyRanged(float speed, int health)
        {
            this.enemySpeed = speed;
            this.enemyHealth = health;

            ChangeState(new EnemyRangedState());

            DeadEvent += ReactToDead;
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
            enemyHealth = 3;
        }

        protected virtual void OnDeadEvent()
        {
            if(DeadEvent != null)
            {
                DeadEvent(GameObject);
            }
        }

        private void ReactToDead(GameObject enemyRanged)
        {
            GameWorld.Instance.Score += 5;
            GameWorld.Instance.RemoveColliders.Add((Collider)GameObject.GetComponent("Collider"));
            RangedEnemyPool.Instance.ReleaseObject(enemyRanged);
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
                EnemyHealth -= 1;              
            }
            else
            {
                return;
            }

        }

    }
}

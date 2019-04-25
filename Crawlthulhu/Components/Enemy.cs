using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawlthulhu
{
    public class Enemy : Component
    {
        protected float enemySpeed;

        private static Enemy instance;

        protected int enemyHealth;

        private int testEr;

        public static Enemy Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Enemy();
                }
                return instance;
            }
        }

        protected Vector2 startPos;
        public Vector2 velociy;

        protected IEnemyState currentState;
  
        
        protected Enemy()
        {
   
        }

        public override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }

        /// <summary>
        /// Handles the MeleeEnemy running functionality, making it chase/and run towards the Player's current position each frame
        /// </summary>
        public virtual void MeleeMovement()
        {
            
        }

        /// <summary>
        /// Handles the RangedEnemy running functionality, making it run back and fourth while remaining in the RangedRunState
        /// </summary>
        public virtual void RangedMovement()
        {

        }

        public virtual void SpellCast()
        {

        }

        public virtual void ChangeState(IEnemyState newState)
        {
            if(currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter(this);
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            gameObject.Transform.Position = startPos;
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);
            //if (other == Projectile.Instance.GameObject.GetComponent("Collider"))
            //{
            //    enemyHealth -= Player.Instance.dmg;
            //}
        }

    }
}

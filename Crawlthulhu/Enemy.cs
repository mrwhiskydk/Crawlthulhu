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
        private float moveSpeed;

        private Vector2 position;

        private IEnemyState currentState;

        private int enemyHealth;

        public int EnemyHealth
        {
            get
            {
                return enemyHealth;
            }
            set
            {
                this.enemyHealth = value;
            }
        }

        
        public Enemy(float speed, Vector2 startPos)
        {
            this.moveSpeed = speed;
            this.position = startPos;
            enemyHealth = 10;

            
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Execute();

            base.Update(gameTime);
        }

        public void EnemyMovement()
        {

        }

        public void ChangeState(IEnemyState newState)
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
            gameObject.Transform.Position = position;
        }



    }
}

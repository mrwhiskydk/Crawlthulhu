using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class Enemy : Component
    {
        private float moveSpeed;

        private Vector2 velocity;
        private Vector2 startPos;

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
            this.startPos = startPos;
            enemyHealth = 10;

            ChangeState(new EnemyIdleState());
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

    }
}

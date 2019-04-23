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

        private static Enemy instance;

        public static Enemy Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Enemy(10, new Vector2(GameWorld.Instance.worldSize.X * 0.4f, GameWorld.Instance.worldSize.Y * 0.4f));
                }
                return instance;
            }
        }
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

        
        private Enemy(float speed, Vector2 startPos)
        {
            this.moveSpeed = speed;
            this.position = startPos;
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

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
            gameObject.Transform.Position = position;
        }



    }
}

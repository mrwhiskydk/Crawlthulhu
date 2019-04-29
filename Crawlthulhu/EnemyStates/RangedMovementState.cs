using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class RangedMovementState : IEnemyState
    {
        private EnemyRanged enemyRanged;

        private float stateTime;
        private float stateDuration;


        public void Enter(EnemyMelee enemyMelee, EnemyRanged enemyRaged)
        {
            this.enemyRanged = enemyRaged;

            stateDuration = 1f;


            if (enemyRanged.GameObject.Transform.Position.X <= GameWorld.Instance.worldSize.X * 0.8f && enemyRanged.GameObject.Transform.Position.Y < GameWorld.Instance.worldSize.Y * 0.2f)
            {
                enemyRanged.velociy = new Vector2(enemyRanged.GameObject.Transform.Position.X, 0);
            }
            else if (enemyRanged.GameObject.Transform.Position.X > GameWorld.Instance.worldSize.X * 0.8f && enemyRanged.GameObject.Transform.Position.Y <= GameWorld.Instance.worldSize.Y * 0.8f)
            {
                enemyRanged.velociy = new Vector2(0, enemyRanged.GameObject.Transform.Position.Y);
            }
            else if (enemyRanged.GameObject.Transform.Position.Y > GameWorld.Instance.worldSize.Y * 0.8f && enemyRanged.GameObject.Transform.Position.X >= GameWorld.Instance.worldSize.X * 0.2f)
            {
                enemyRanged.velociy = new Vector2(-enemyRanged.GameObject.Transform.Position.X, 0);
            }
            else if (enemyRanged.GameObject.Transform.Position.X < GameWorld.Instance.worldSize.X * 0.2f && enemyRanged.GameObject.Transform.Position.Y >= GameWorld.Instance.worldSize.Y * 0.2f)
            {
                enemyRanged.velociy = new Vector2(0, -enemyRanged.GameObject.Transform.Position.Y);
            }


        }

        public void Execute()
        {
            enemyRanged.RangedMovement();

            Moving();
        }

        public void Exit()
        {
            stateTime = 0;
        }


        private void Moving()
        {
            stateTime += GameWorld.Instance.deltaTime;

            if(stateTime >= stateDuration)
            {
                enemyRanged.ChangeState(new EnemyRangedState());
            }
        }
    }
}

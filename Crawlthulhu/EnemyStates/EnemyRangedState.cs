using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyRangedState : IEnemyState
    {
        private EnemyRanged enemyRanged;

        private float stateTime;
        private float stateDuration;


        public void Enter(EnemyMelee enemyMelee, EnemyRanged enemyRanged)
        {
            this.enemyRanged = enemyRanged;

            stateDuration = 0.2f;
        }

        public void Execute()
        {
            Ranged();
        }

        public void Exit()
        {
            stateTime = 0;
        }

        private void Ranged()
        {
            stateTime += GameWorld.Instance.deltaTime;

            if(stateTime >= stateDuration)
            {
                enemyRanged.ChangeState(new RangedMovementState());
            }
        }
    }
}

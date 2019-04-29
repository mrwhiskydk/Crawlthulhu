using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyIdleState : IEnemyState
    {
        private EnemyMelee enemyMelee;

        private float idleTime;
        private float idleDuration;

        public void Enter(EnemyMelee enemyMelee, EnemyRanged enemyRanged)
        {
            this.enemyMelee = enemyMelee;

            idleDuration = 1f;
        }

        public void Execute()
        {
            Idle();
        }

        public void Exit()
        {
            idleTime = 0;
        }


        private void Idle()
        {
            idleTime += GameWorld.Instance.deltaTime;

            if (idleTime >= idleDuration)
            {
                enemyMelee.ChangeState(new EnemyRunState());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyRunState : IEnemyState
    {
        private EnemyMelee enemyMelee;

        

        public void Enter(EnemyMelee enemyMelee, EnemyRanged enemyRanged)
        {
            this.enemyMelee = enemyMelee;
        }

        public void Execute()
        {
            enemyMelee.MeleeMovement();

        }

        public void Exit()
        {
           
        }

    }
}

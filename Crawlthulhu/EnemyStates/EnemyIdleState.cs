using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu.EnemyStates
{
    public class EnemyIdleState : IEnemyState
    {
        private Enemy enemy;


        public void Enter(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void Execute()
        {
           
        }

        public void Exit()
        {
           
        }
    }
}

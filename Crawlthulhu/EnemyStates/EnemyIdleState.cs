using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyIdleState : IEnemyState
    {
        private Enemy enemy;

        private float idleTime;
        private float idleDuration;

        public void Enter(Enemy enemy)
        {
            this.enemy = enemy;

            idleDuration = 2f;
        }

        public void Execute()
        {
            Idle();
        }

        public void Exit()
        {
           
        }

        private void Idle()
        {
            
        }
    }
}

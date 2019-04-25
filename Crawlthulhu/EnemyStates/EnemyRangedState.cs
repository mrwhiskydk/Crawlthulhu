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
        private Enemy enemy;

        private float stateTime;
        private float stateDuration;


        public void Enter(Enemy enemy)
        {
            this.enemy = enemy;

            stateDuration = 1f;
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
                enemy.ChangeState(new RangedMovementState());
            }
        }
    }
}

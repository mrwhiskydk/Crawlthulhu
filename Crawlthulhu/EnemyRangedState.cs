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

            stateDuration = 4f;
        }

        public void Execute()
        {
            int distance = (int)Vector2.Distance(enemy.GameObject.Transform.Position, Player.Instance.GameObject.Transform.Position);

            if (distance <= 250)
            {
                enemy.ChangeState(new RangedChaseState());
            }

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
                enemy.ChangeState(new EnemyRangedState());
            }
        }
    }
}

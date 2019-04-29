using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public interface IEnemyState
    {
        void Enter(EnemyMelee enemyMelee, EnemyRanged enemyRanged);
        void Execute();
        void Exit();
    }
}

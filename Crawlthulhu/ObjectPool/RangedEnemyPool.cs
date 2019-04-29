using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class RangedEnemyPool : ObjectPool
    {

        private static RangedEnemyPool instance;

        public static RangedEnemyPool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new RangedEnemyPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return EnemyFactory.Instance.Create("ranged");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("EnemyRanged") as EnemyRanged).Reset();
        }
    }
}

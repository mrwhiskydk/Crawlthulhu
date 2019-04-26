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
            return ProjectileFactory.Instance.Create("default");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("EnemyRanged") as EnemyRanged).Reset();
        }
    }
}

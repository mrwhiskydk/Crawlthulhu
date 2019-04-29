using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class MeleeEnemyPool : ObjectPool
    {

        private static MeleeEnemyPool instance;

        public static MeleeEnemyPool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new MeleeEnemyPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return EnemyFactory.Instance.Create("melee");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("EnemyMelee") as EnemyMelee).Reset();
        }
    }
}

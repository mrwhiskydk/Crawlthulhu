using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class SpellPool : ObjectPool
    {
        private static SpellPool instance;

        public static SpellPool Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SpellPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return ProjectileFactory.Instance.Create("spell");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("EnemyProjectile") as EnemyProjectile).Reset();
        }
    }
}

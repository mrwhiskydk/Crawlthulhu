using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class CollectablePool : ObjectPool
    {
        private static CollectablePool instance;

        public static CollectablePool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new CollectablePool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return OtherObjectFactory.Instance.Create("collectable");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("Collectable") as Collectable).Reset();
        }
    }
}

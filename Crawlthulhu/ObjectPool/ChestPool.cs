using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class ChestPool : ObjectPool
    {
        private static ChestPool instance;

        public static ChestPool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ChestPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return OtherObjectFactory.Instance.Create("chest");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("Chest") as Chest).Reset();
        }
    }
}

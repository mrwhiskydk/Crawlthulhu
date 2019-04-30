using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class DoorPool : ObjectPool
    {
        private static DoorPool instance;

        public static DoorPool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DoorPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return OtherObjectFactory.Instance.Create("doorway");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("Door") as Door).Reset();
        }
    }
}

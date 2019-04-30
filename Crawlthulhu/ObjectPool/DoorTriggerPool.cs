using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class DoorTriggerPool : ObjectPool
    {
        private static DoorTriggerPool instance;

        public static DoorTriggerPool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DoorTriggerPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return OtherObjectFactory.Instance.Create("doorTrigger");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("DoorTrigger") as DoorTrigger).Reset();
        }
    }
}

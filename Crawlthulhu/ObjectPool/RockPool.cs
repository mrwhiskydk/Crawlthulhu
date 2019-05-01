using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class RockPool : ObjectPool
    {
        private static RockPool instance;

        public static RockPool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new RockPool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return MapFactory.Instance.Create("rocks");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("BackgroundStuff") as BackgroundStuff).Reset();
        }
    }
}

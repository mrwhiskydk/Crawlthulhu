using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class DoorTrigger : Component
    {
        private static DoorTrigger instance;

        public static DoorTrigger Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DoorTrigger();
                }
                return instance;
            }
        }

        private DoorTrigger()
        {
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }
    }
}

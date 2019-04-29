using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class Collectable : Component
    {
        private static Collectable instance;

        public static Collectable Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Collectable();
                }
                return instance;
            }
        }

        private Collectable()
        {
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }
    }
}

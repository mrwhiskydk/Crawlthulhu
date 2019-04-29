using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu.Components
{
    class Wall : Component
    {
        private static Wall instance;

        public static Wall Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Wall();
                }
                return instance;
            }
        }

        private Wall()
        {
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class Door : Component
    {
        private static Door instance;

        public static Door Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Door();
                }
                return instance;
            }
        }

        private Door()
        {
        }

        public void Reset()
        {

        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);
        }
    }
}

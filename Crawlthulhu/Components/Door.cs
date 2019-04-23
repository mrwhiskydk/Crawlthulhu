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

        private Vector2 position;

        public static Door Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Door(Vector2.Zero);
                }
                return instance;
            }
        }

        private Door(Vector2 startPos)
        {
            position = startPos;
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class BackgroundStuff : Component
    {
        private static BackgroundStuff instance;

        public static BackgroundStuff Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new BackgroundStuff();
                }
                return instance;
            }
        }

        private BackgroundStuff()
        {
        }

        public void Reset()
        {

        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }
    }
}

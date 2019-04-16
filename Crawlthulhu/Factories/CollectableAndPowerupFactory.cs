using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class CollectableAndPowerupFactory : Factory
    {
        private static CollectableAndPowerupFactory instance;

        public static CollectableAndPowerupFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new CollectableAndPowerupFactory();
                }
                return instance;
            }
        }

        private CollectableAndPowerupFactory()
        {

        }

        public override GameObject Create(string type)
        {
            throw new NotImplementedException();
        }
    }
}

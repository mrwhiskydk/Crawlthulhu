using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class MapFactory : Factory
    {
        private static MapFactory instance;

        public static MapFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new MapFactory();
                }
                return instance;
            }
        }

        private MapFactory()
        {

        }

        public override GameObject Create(string type)
        {
            throw new NotImplementedException();
        }
    }
}

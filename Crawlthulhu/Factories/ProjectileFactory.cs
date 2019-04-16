using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class ProjectileFactory : Factory
    {
        private static ProjectileFactory instance;

        public static ProjectileFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ProjectileFactory();
                }
                return instance;
            }
        }

        private ProjectileFactory()
        {

        }

        public override GameObject Create(string type)
        {
            throw new NotImplementedException();
        }
    }
}

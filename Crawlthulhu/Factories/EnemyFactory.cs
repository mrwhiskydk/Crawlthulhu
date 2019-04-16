using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class EnemyFactory : Factory 
    {
        private static EnemyFactory instance;

        public static EnemyFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        }

        private EnemyFactory()
        {

        }

        public override GameObject Create(string type)
        {
            throw new NotImplementedException();
        }
    }
}

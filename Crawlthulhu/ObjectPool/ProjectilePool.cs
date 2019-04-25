using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Crawlthulhu
{
    class ProjectilePool : ObjectPool
    {
        private static ProjectilePool instance;

        public static ProjectilePool Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ProjectilePool();
                }
                return instance;
            }
        }

        public override GameObject Create()
        {
            return ProjectileFactory.Instance.Create("default");
        }

        public override void Reset(GameObject gameObject)
        {
            (gameObject.GetComponent("Projectile") as Projectile).Reset();
        }
    }
}

using Microsoft.Xna.Framework;
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
            GameObject go = new GameObject();
            switch (type)
            {
                default:
                    go.AddComponent(Enemy.Instance);
                    //go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.5f)));
                    go.AddComponent(new SpriteRenderer("RatQueen"));
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

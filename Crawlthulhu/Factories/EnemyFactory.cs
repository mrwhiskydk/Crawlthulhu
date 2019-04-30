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
            int rndX = GameWorld.Instance.rnd.Next(100, 1800);
            int rndY = GameWorld.Instance.rnd.Next(100, 900);

            switch (type)
            {
                //default:
                //    go.AddComponent(Enemy.Instance);
                //    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.2f, GameWorld.Instance.worldSize.Y * 0.2f)));
                //    go.AddComponent(new SpriteRenderer("RatQueen", 1, 1));
                //    go.AddComponent(new Collider());
                //    break;
                case "melee":
                    go.AddComponent(new EnemyMelee(150, 3));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(rndX, rndY)));
                    go.AddComponent(new SpriteRenderer("RatQueen", 1, 1));
                    go.AddComponent(new Collider());
                    break;
                case "ranged":
                    go.AddComponent(new EnemyRanged(100, 3));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(/*rndX, rndY*/rndX, GameWorld.Instance.worldSize.Y * 0.2f)));
                    go.AddComponent(new SpriteRenderer("CultEnemy", 20, 20));
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

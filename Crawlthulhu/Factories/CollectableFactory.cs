using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawlthulhu.Factories
{
    class CollectableFactory : Factory
    {
        private static CollectableFactory instance;

        public static CollectableFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new CollectableFactory();
                }
                return instance;
            }

        }

        private CollectableFactory()
        {

        }


        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();

            switch (type)
            {
                default:
                    go.AddComponent(new Collectable());
                    go.AddComponent(new SpriteRenderer("bone_ani", 9, 9));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.3f, GameWorld.Instance.worldSize.Y * 0.3f)));
                    go.AddComponent(new Collider());
                    break;
                case "scroll":
                    go.AddComponent(new Collectable());
                    go.AddComponent(new SpriteRenderer("bone_ani", 9, 9));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.3f, GameWorld.Instance.worldSize.Y * 0.3f)));
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

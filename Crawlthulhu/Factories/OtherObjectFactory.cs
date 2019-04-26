using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class OtherObjectFactory : Factory
    {
        private static OtherObjectFactory instance;

        private string CollectableType;

        public static OtherObjectFactory Instance
        {   
            get
            {
                if (instance is null)
                {
                    instance = new OtherObjectFactory();
                }
                return instance;
            }
        }

        private OtherObjectFactory()
        {

        }

        public override GameObject Create(string type)
        {

            GameObject go = new GameObject();
            int rndCollectable = GameWorld.Instance.rnd.Next(1, 6);
            if (rndCollectable == 1)
            {
                CollectableType = "bone_ani";
            }
            else if (rndCollectable == 2)
            {
                CollectableType = "ancient_scroll_ani";
            }
            else if (rndCollectable == 3)
            {
                CollectableType = "black_pearl_ani";
            }
            else if (rndCollectable == 4)
            {
                CollectableType = "blood_of_cthulu_ani";
            }
            else if (rndCollectable == 5)
            {
                CollectableType = "coin_ani";
            }

            switch (type)
            {
                case "crosshair":
                    go.AddComponent(Crosshair.Instance);
                    go.AddComponent(new SpriteRenderer("crosshair", 1, 1));
                    go.AddComponent(new Collider());
                    break;
                case "Doorway":
                    go.AddComponent(Door.Instance);
                    go.AddComponent(new SpriteRenderer("Doorway", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 38)));
                    go.AddComponent(new Collider());
                    break;
                case "Collectable":
                    go.AddComponent(Collectable.Instance);
                    go.AddComponent(new SpriteRenderer(CollectableType, 8, 8));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.2f, GameWorld.Instance.worldSize.Y * 0.2f)));
                    go.AddComponent(new Collider());

                    break;
            }

            return go;
        }
    }
}

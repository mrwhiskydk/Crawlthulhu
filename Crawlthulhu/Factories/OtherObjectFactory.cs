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

        public int collectableList = 0;

        public string CollectableType;

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
            if (GameWorld.Instance.chest)
            {
                if (collectableList == 0)
                {
                    CollectableType = "bone_ani";
                }
                else if (collectableList == 1)
                {
                    CollectableType = "ancient_scroll_ani";
                }
                else if (collectableList == 2)
                {
                    CollectableType = "black_pearl_ani";
                }
                else if (collectableList == 3)
                {
                    CollectableType = "blood_of_cthulu_ani";
                }
                else if (collectableList == 4)
                {
                    CollectableType = "coin_ani";
                }
                else if (collectableList == 5)
                {
                    CollectableType = "cursed_skull_ani";
                }
            }
           
            switch (type)
            {
                case "crosshair":
                    go.AddComponent(Crosshair.Instance);
                    go.AddComponent(new SpriteRenderer("crosshair", 1, 1, 1));
                    go.AddComponent(new Collider());
                    break;
                case "doorway":
                    go.AddComponent(Door.Instance);
                    go.AddComponent(new SpriteRenderer("Doorway", 1, 1, 0.9f));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, -500)));
                    break;
                case "collectable":
                    go.AddComponent(new Collectable());
                    go.AddComponent(new SpriteRenderer(CollectableType, 8, 8, 0.9f));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 330)));
                    go.AddComponent(new Collider());
                    break;
                case "doorTrigger":
                    go.AddComponent(DoorTrigger.Instance);
                    go.AddComponent(new SpriteRenderer("doorTrigger", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, -500)));
                    go.AddComponent(new Collider());
                    break;
                case "stone":
                    go.AddComponent(BackgroundStuff.Instance);
                    go.AddComponent(new SpriteRenderer("Rocks", 1, 1));
                    break;
                case "chest":
                    go.AddComponent(new Chest());
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 350)));
                    go.AddComponent(new SpriteRenderer("OpenChest", 1, 1, 0.7f));
                    break;
            }

            return go;
        }
    }
}

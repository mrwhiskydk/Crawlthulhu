using Crawlthulhu.Components;
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

        public int collectableList = 1;

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
            if (collectableList == 1)
            {
                CollectableType = "bone_ani";
                collectableList++;
            }
            else if (collectableList == 2)
            {
                CollectableType = "ancient_scroll_ani";
                collectableList++;
            }
            else if (collectableList == 3)
            {
                CollectableType = "black_pearl_ani";
                collectableList++;
            }
            else if (collectableList == 4)
            {
                CollectableType = "blood_of_cthulu_ani";
                collectableList++;
            }
            else if (collectableList == 5)
            {
                CollectableType = "coin_ani";
                collectableList++;
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
                    go.AddComponent(new SpriteRenderer("Doorway", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 38)));
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
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, -50)));
                    go.AddComponent(new Collider());
                    break;
                case "horizontalWallTop1":
                    go.AddComponent(new Wall());
                    go.AddComponent(new SpriteRenderer("horizontalWall", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(450, -15)));
                    go.AddComponent(new Collider());
                    break;
                case "horizontalWallTop2":
                    go.AddComponent(new Wall());
                    go.AddComponent(new SpriteRenderer("horizontalWall", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(1465, -15)));
                    go.AddComponent(new Collider());
                    break;
                case "horizontalWallBot":
                    go.AddComponent(new Wall());
                    go.AddComponent(new SpriteRenderer("horizontalWallLong", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 1095)));
                    go.AddComponent(new Collider());
                    break;
                case "verticalWallLeft":
                    go.AddComponent(new Wall());
                    go.AddComponent(new SpriteRenderer("verticalWall", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(-43, GameWorld.Instance.worldSize.Y * 0.5f)));
                    go.AddComponent(new Collider());
                    break;
                case "verticalWallRight":
                    go.AddComponent(new Wall());
                    go.AddComponent(new SpriteRenderer("verticalWall", 1, 1));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(1963, GameWorld.Instance.worldSize.Y * 0.5f)));
                    go.AddComponent(new Collider());
                    break;
                case "stone":
                    go.AddComponent(BackgroundStuff.Instance);
                    go.AddComponent(new SpriteRenderer("Rocks", 1, 1));
                    break;
                case "chest":
                    go.AddComponent(new Chest());
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 350)));
                    go.AddComponent(new SpriteRenderer("OpenChest", 1, 1));
                    break;
            }

            return go;
        }
    }
}

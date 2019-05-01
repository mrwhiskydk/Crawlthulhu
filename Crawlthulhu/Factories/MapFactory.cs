using Microsoft.Xna.Framework;
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
            GameObject go = new GameObject();

            int rndX = GameWorld.Instance.rnd.Next(150, 1770);
            int rndY = GameWorld.Instance.rnd.Next(250, 750);

            switch (type)
            {
                case "rocks":
                    go.AddComponent(BackgroundStuff.Instance);
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(rndX, rndY)));
                    go.AddComponent(new SpriteRenderer("Rocks", 1, 1));
                    break;
            }
            return go;
        }
    }
}

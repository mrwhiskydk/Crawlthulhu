using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class PlayerFactory : Factory
    {
        private static PlayerFactory instance;

        public static PlayerFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new PlayerFactory();
                }
                return instance;
            }
        }

        private PlayerFactory()
        {

        }

        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            switch (type)
            {
                default:
                    go.AddComponent(Player.Instance);
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, GameWorld.Instance.worldSize.Y * 0.7f)));
                    go.AddComponent(new SpriteRenderer("chara2 back", 3, 3, 0.89f));
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

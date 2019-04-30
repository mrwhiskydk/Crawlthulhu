using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class UIFactory : Factory
    {
        private static UIFactory instance;

        public static UIFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new UIFactory();
                }
                return instance;
            }
        }

        private UIFactory()
        {

        }

        public override GameObject Create(string type)
        {
            return Create(type, "default", 0.9f, Vector2.Zero);
        }

        public GameObject Create(string type, string sprite, float depth, Vector2 position)
        {
            GameObject go = new GameObject();
            switch (type)
            {
                case "sprite":
                    go.AddComponent(new Transform(go.Transform.Position = position));
                    go.AddComponent(new SpriteRenderer(sprite, 1, 1, depth));
                    break;
            }
            return go;
        }

        public GameObject CreateButtonAdvanced(string type, string sprite, string spriteHover, float depth, Vector2 position)
        {
            GameObject go = new GameObject();
            switch (type)
            {
                case "button":
                    go.AddComponent(new Transform(position));
                    go.AddComponent(new SpriteRenderer(sprite, 1, 1, depth));
                    go.AddComponent(new Button());
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }


    }
}

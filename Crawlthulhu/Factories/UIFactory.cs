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

        public override GameObject Create(string sprite)
        {
            return CreateSprite(sprite, 0.9f, Vector2.Zero);
        }

        public GameObject CreateSprite(string sprite, float depth, Vector2 position, int frameCount = 1, float animationFPS = 0)
        {
            GameObject go = new GameObject();
            go.AddComponent(new Transform(go.Transform.Position = position));
            go.AddComponent(new SpriteRenderer(sprite, frameCount, animationFPS, depth));
            return go;
        }

        public GameObject CreateButton(string sprite, float depth, Vector2 position, IButton button)
        {
            GameObject go = new GameObject();
            go.AddComponent(new Transform(go.Transform.Position = position));
            go.AddComponent(new SpriteRenderer(sprite, 1, 1, depth));
            go.AddComponent(new Collider());
            go.AddComponent(new Button(button));
            return go;
        }
    }
}

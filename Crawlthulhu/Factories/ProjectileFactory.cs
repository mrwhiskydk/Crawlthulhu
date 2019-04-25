using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class ProjectileFactory : Factory
    {
        private static ProjectileFactory instance;

        public static ProjectileFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ProjectileFactory();
                }
                return instance;
            }
        }

        private ProjectileFactory()
        {

        }

        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();

            switch (type)
            {
                default:
                    go.AddComponent(new Projectile(400));
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(Player.Instance.GameObject.Transform.Position.X, Player.Instance.GameObject.Transform.Position.Y)));
                    go.AddComponent(new SpriteRenderer("Bullet", 1, 1));
                    go.AddComponent(new Collider());
                    break;
                case "spell":
                    go.AddComponent(EnemyProjectile.Instance);
                    go.AddComponent(new SpriteRenderer("Bullet", 1, 1));
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

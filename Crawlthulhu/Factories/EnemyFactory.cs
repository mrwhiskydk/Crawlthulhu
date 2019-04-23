﻿using Microsoft.Xna.Framework;
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
            switch (type)
            {
                default:
                    go.AddComponent(Enemy.Instance);
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.2f, GameWorld.Instance.worldSize.Y * 0.2f)));
                    go.AddComponent(new SpriteRenderer("RatQueen", 1, 1));
                    go.AddComponent(new Collider());
                    break;
                case "melee":
                    go.AddComponent(new EnemyMelee());
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.2f, GameWorld.Instance.worldSize.Y * 0.2f)));
                    go.AddComponent(new SpriteRenderer("RatQueen", 1, 1));
                    go.AddComponent(new Collider());
                    break;
                case "ranged":
                    go.AddComponent(new EnemyRanged());
                    go.AddComponent(new Transform(go.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.6f, GameWorld.Instance.worldSize.Y * 0.2f)));
                    go.AddComponent(new SpriteRenderer("RatQueen", 1, 1));
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

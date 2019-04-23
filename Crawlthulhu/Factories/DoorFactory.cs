﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class DoorFactory : Factory
    {
        private static DoorFactory instance;

        private Random rnd;

        private Vector2 rndPos;

        public static DoorFactory Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DoorFactory();
                }
                return instance;
            }
        }

        private DoorFactory()
        {

        }

        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            rndPos = new Vector2(GameWorld.Instance.worldSize.X * 0.1f, GameWorld.Instance.worldSize.Y* 0.1f);
            switch (type)
            {
                default:
                    go.AddComponent(Door.Instance);
                    go.AddComponent(new Transform(go.Transform.Position = rndPos));
                    go.AddComponent(new SpriteRenderer("PlayerArm", 1, 1)); 
                    go.AddComponent(new Collider());
                    break;
            }
            return go;
        }
    }
}

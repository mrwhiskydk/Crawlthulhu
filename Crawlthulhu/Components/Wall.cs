using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu.Components
{
    class Wall : Component
    {
        //private static Wall instance;

        //public static Wall Instance
        //{
        //    get
        //    {
        //        if (instance is null)
        //        {
        //            instance = new Wall();
        //        }
        //        return instance;
        //    }
        //}

        public Wall()
        {

        }

        //public void Reset()
        //{

        //}

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);
        }
    }
}

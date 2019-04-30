using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class DoorTrigger : Component
    {
        private static DoorTrigger instance;

        public static DoorTrigger Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DoorTrigger();
                }
                return instance;
            }
        }

        private DoorTrigger()
        {
        }

        public void Reset()
        {

        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);
        }

        public override void OnCollisionEnter(Collider other)
        {
            base.OnCollisionEnter(other);

            if (other == Player.Instance.GameObject.GetComponent("Collider"))
            {
                GameWorld.Instance.resetLevel = true;
                if (GameWorld.Instance.rnd.Next(1, 6) == 1 && OtherObjectFactory.Instance.collectableList < 6)
                {
                    GameWorld.Instance.chest = true;
                }
            }
            else
            {
                return;
            }
        }
    }
}

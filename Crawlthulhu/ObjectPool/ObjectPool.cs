using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Crawlthulhu
{
    public abstract class ObjectPool
    {

        protected List<GameObject> inactive = new List<GameObject>();
        protected List<GameObject> active = new List<GameObject>();

        public GameObject GetObject()
        {
            GameObject gameObject = null;
           

            if (inactive.Count > 0)
            {
                gameObject = inactive[0];
                active.Add(gameObject);
                inactive.RemoveAt(0);
            }
            else
            {
                gameObject = Create();
                gameObject.LoadContent(GameWorld.Instance.MyContent);
                active.Add(gameObject);
            }
            return gameObject;
        }

        public void ReleaseObject(GameObject gameObject)
        {
            CleanUp(gameObject);

            inactive.Add(gameObject);

            active.Remove(gameObject);
        }

        public void CleanUp(GameObject gameObject)
        {
            Reset(gameObject);
            
            GameWorld.Instance.RemoveObjects.Add(gameObject);          
        }

        public abstract GameObject Create();

        public abstract void Reset(GameObject gameObject);
    }
}


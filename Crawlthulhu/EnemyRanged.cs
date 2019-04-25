using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawlthulhu
{
    public class EnemyRanged : Enemy
    {

        public EnemyRanged()
        {
            enemySpeed = 400f;

            ChangeState(new EnemyRangedState());
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Execute();

            

            base.Update(gameTime);
        }

        public override void ChangeState(IEnemyState newState)
        {
            base.ChangeState(newState);
        }


        public override void RangedMovement()
        {
            velociy.Normalize();

            velociy *= enemySpeed;

            GameObject.Transform.Position += (velociy * GameWorld.Instance.deltaTime);
        }

        public override void SpellCast()
        {
            GameWorld.Instance.gameObjects.Add(ProjectileFactory.Instance.Create("spell"));
            
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
                Player.Instance.health -= 1;
                Player.Instance.takenDMG = true;
            }
        }

    }
}

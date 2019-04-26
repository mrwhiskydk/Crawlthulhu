using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class EnemyMelee : Enemy
    {


        public EnemyMelee()
        {
            enemySpeed = 150f;

            enemyHealth = 3;

            ChangeState(new EnemyIdleState());
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Execute();

            if(enemyHealth <= 0)
            {
                GameWorld.Instance.RemoveObjects.Add(GameObject);
            }

            base.Update(gameTime);
        }

        public override void ChangeState(IEnemyState newState)
        {
            base.ChangeState(newState);
        }

        public override void MeleeMovement()
        {
            int distance = (int)Vector2.Distance(GameObject.Transform.Position, Player.Instance.GameObject.Transform.Position);

            velociy = Player.Instance.GameObject.Transform.Position - GameObject.Transform.Position;
            velociy.Normalize();

            if (distance <= 250)
            {
                velociy *= enemySpeed * 2;
            }
            else if (distance > 250)
            {
                velociy *= enemySpeed;
            }

            GameObject.Transform.Position += (velociy * GameWorld.Instance.deltaTime);
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
                ChangeState(new EnemyIdleState());
            }

            //foreach (Collider col in GameWorld.Instance.Colliders)
            //{
            //    other = col;

            //    if(other == GameObject.GetComponent("Projectile").GameObject.GetComponent("Collider"))
            //    {
            //        enemyHealth -= 1;
            //    }
            //    //if (other == Projectile.Instance.GameObject.GetComponent("Collider"))
            //    //{
            //    //    //enemyHealth -= Player.Instance.dmg;
            //    //}
            //}
        }

    }
}

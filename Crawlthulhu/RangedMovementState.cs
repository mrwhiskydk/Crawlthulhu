﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class RangedMovementState : IEnemyState
    {
        private Enemy enemy;

        private float stateTime;
        private float stateDuration;

        private Random randomMove;

        public void Enter(Enemy enemy)
        {
            this.enemy = enemy;

            stateDuration = 0.5f;

            randomMove = new Random();

            float ran = (float)randomMove.NextDouble();

            if (ran > 0.5f)
            {
                if(enemy.GameObject.Transform.Position.X <= GameWorld.Instance.worldSize.X * 0.8f && enemy.GameObject.Transform.Position.Y <= GameWorld.Instance.worldSize.Y * 0.2f)
                {
                    enemy.velociy = new Vector2(enemy.GameObject.Transform.Position.X, enemy.GameObject.Transform.Position.Y);
                }
                else
                {
                    enemy.velociy = new Vector2(-enemy.GameObject.Transform.Position.X, enemy.GameObject.Transform.Position.Y);
                }
            }
            else
            {
                if(enemy.GameObject.Transform.Position.X >= GameWorld.Instance.worldSize.X * 0.2f && enemy.GameObject.Transform.Position.Y <= GameWorld.Instance.worldSize.Y * 0.8f)
                {
                    enemy.velociy = new Vector2(-enemy.GameObject.Transform.Position.X, -enemy.GameObject.Transform.Position.Y);
                }
                else
                {
                    enemy.velociy = new Vector2(enemy.GameObject.Transform.Position.X, -enemy.GameObject.Transform.Position.Y);
                }
            }
        }

        public void Execute()
        {
            enemy.RangedMovement();

            Moving();
        }

        public void Exit()
        {
            stateTime = 0;
        }

        private void Moving()
        {
            stateTime += GameWorld.Instance.deltaTime;

            if(stateTime >= stateDuration)
            {
                enemy.ChangeState(new EnemyRangedState());
            }
        }
    }
}
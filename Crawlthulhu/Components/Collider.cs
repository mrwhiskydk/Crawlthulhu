﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class Collider : Component
    {
        public SpriteRenderer spriteRenderer { get; private set; }

        public bool DoCollisionChecks { get; set; }

        private Texture2D texture;

        private HashSet<Collider> otherColliders = new HashSet<Collider>();

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle
                    (
                        (int)(GameObject.Transform.Position.X - spriteRenderer.animationRectangles[0].Width * 0.5f),
                        (int)(GameObject.Transform.Position.Y - spriteRenderer.animationRectangles[0].Height * 0.5f),
                        spriteRenderer.animationRectangles[0].Width,
                        spriteRenderer.animationRectangles[0].Height
                    );
            }
        }

        public override void Attach(GameObject gameObject)
        {
            base.Attach(gameObject);

            DoCollisionChecks = true; //default was set true

            spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");

            GameWorld.Instance.Colliders.Add(this);
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("CollisionTexture");
        }

        public override void Update(GameTime gameTime)
        {
            CheckCollision();

            //if (DoCollisionChecks)
            //{
            //    DoCollisionChecks = false;
            //}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
#if DEBUG
            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y, 1, CollisionBox.Height);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y, 1, CollisionBox.Height);

            spriteBatch.Draw(texture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
#endif
        }

        private void CheckCollision()
        {
            if (DoCollisionChecks)
            {
                foreach (Collider other in GameWorld.Instance.Colliders)
                {
                    if (other != this)
                    {
                        if (CollisionBox.Intersects(other.CollisionBox))
                        {
                            if (!otherColliders.Contains(other))
                            {
                                otherColliders.Add(other);
                                GameObject.OnCollisionEnter(other);
                            }
                        }
                        else if (otherColliders.Contains(other))
                        {
                            otherColliders.Remove(other);
                            //end collision
                        }
                    }
                }
            }
        }
    }
}

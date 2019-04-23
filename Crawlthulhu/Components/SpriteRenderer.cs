using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class SpriteRenderer : Component
    {
        public Texture2D sprite;
        //public Vector2 origin { get; set; }
        public Rectangle[] animationRectangles;
        //public Rectangle Rectangle { get; set; }
        private string spriteName;

        private float animationFPS; // default is 10
        private int frameCount;
        private int currentAnimationIndex = 0; // default is 0
        private double timeElapsed = 0; // default is 0



        public SpriteRenderer(string spriteName, int frameCount, float animationFPS)
        {
            this.spriteName = spriteName;
            this.animationFPS = animationFPS;
            this.frameCount = frameCount;
            animationRectangles = new Rectangle[frameCount];
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeElapsed += GameWorld.Instance.deltaTime;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if (currentAnimationIndex > animationRectangles.Count() - 1)
            {
                currentAnimationIndex = 0;
                timeElapsed = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GameObject.Transform.Position, animationRectangles[currentAnimationIndex], Color.White, 0, new Vector2(animationRectangles[currentAnimationIndex].Width * 0.5f, animationRectangles[currentAnimationIndex].Height * 0.5f), 1f, SpriteEffects.None, 0);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);

            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle(i * (sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;

            //this.Rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);

            //origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

    }
}

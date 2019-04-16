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
    public class Animator : Component
    {
        public Texture2D sprite;
        public Rectangle[] animationRectangles;
        private string spriteName;

        private float animationFPS = 10;
        private int currentAnimationIndex = 0;
        private double timeElapsed = 0;


        public Animator(int frameCount, float animationFPS, string spriteName)
        {
            this.animationFPS = animationFPS;
            animationRectangles = new Rectangle[frameCount];

            for (int i = 0; i < frameCount; i++)
            {
                animationRectangles[i] = new Rectangle(i * (sprite.Width / frameCount), 0, (sprite.Width / frameCount), sprite.Height);
            }
            currentAnimationIndex = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeElapsed += GameWorld.Instance.deltaTime;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);

            if(currentAnimationIndex > animationRectangles.Count() - 1)
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
        }

    }
}

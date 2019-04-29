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
    public class Sprite
    {
        private Texture2D sprite;
        private Vector2 position;
        private float depth;

        public Sprite(string spriteName, Vector2 position, float depth, ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
            this.position = position;
            this.depth = depth;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, SpriteEffects.None, depth);
        }
    }
}

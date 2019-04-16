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
        public Vector2 origin { get; set; }
        public Rectangle Rectangle { get; set; }
        private string spriteName;

        public SpriteRenderer(string spriteName)
        {
            this.spriteName = spriteName;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GameObject.Transform.Position, Rectangle, Color.White, 0, origin, 1, SpriteEffects.None, 0);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);

            this.Rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);

            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    public class Button : Component
    {
        IButton button;
        Collider col;

        public Button(IButton button)
        {
            this.button = button;
        }

        public void OnClick()
        {
            button.OnClick();
        }

        public override void LoadContent(ContentManager content)
        {
            col = (Collider)GameObject.GetComponent("Collider");
        }

        public override void Update(GameTime gameTime)
        {
            if (col.CollisionBox.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                OnClick();
            }
        }
    }
}

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
    public interface IUIState
    {
        void Enter();
        void Draw(SpriteBatch spriteBatch);
        void Execute(GameTime gameTime);
        void Exit();
    }
}

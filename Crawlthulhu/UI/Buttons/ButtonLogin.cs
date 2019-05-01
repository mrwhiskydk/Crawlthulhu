using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawlthulhu
{
    class ButtonLogin : Component, IButton
    {
        public void OnClick()
        {
            Controller.Instance.Login(UIMainMenuState.stringBuilder.ToString());
            Door.Instance.GameObject.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, 38);
            DoorTrigger.Instance.GameObject.Transform.Position = new Vector2(GameWorld.Instance.worldSize.X * 0.5f, -50);
        }
    }
}

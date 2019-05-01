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
        }
    }
}

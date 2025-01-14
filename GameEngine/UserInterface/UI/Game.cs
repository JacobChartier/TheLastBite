using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.UserInterface.Graphics;

namespace GameEngine.UserInterface.UI
{
    internal class Game
    {
        static Label label_Time = new Label("00 : 00 . 00", 100, 100, Application.Font_RobotoBlack, white, transparent);

        public static void Show()
        {
            label_Time.Show();
        }
    }
}

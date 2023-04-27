using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.UserInterface.Graphics;

namespace GameEngine.UserInterface.UI
{
    internal class Pause
    {
        static Label label_Pause = new Label("GAME PAUSED", 0, 75, Application.Font_RobotoBlack, Graphics.white, Graphics.backgroundColor, 15);

        static Button button_Resume = new Button("Resume", 0, 300, Application.Font_TheImpostor, Graphics.btn_white, Graphics.btn_hover, Graphics.buttonBackground, 15);
        static Button button_Settings = new Button("Settings", 0, 350, Application.Font_TheImpostor, Graphics.btn_white, Graphics.btn_hover, Graphics.buttonBackground, 15);
        static Button button_Leave = new Button("Quit", 0, 400, Application.Font_TheImpostor, Graphics.btn_white, Graphics.btn_hover, Graphics.buttonBackground, 15);

        public static void Show()
        {
            SetWindowBackColor(backgroundColor);

            label_Pause.CenterX();
            label_Pause.Show();

            button_Resume.CenterX();
            button_Resume.Show();
            if (button_Resume.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Graphics.state = Graphics.GameState.Game;
            }

            button_Settings.CenterX();
            button_Settings.Show();
            if (button_Settings.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Graphics.state = Graphics.GameState.Settings;
                Settings.LastState = GameState.Pause;
            }

            button_Leave.CenterX();
            button_Leave.Show();
            if (button_Leave.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Graphics.state = Graphics.GameState.Menu;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameEngine.UserInterface.Graphics;

namespace GameEngine.UserInterface.UI
{
    public class Menu
    {
        static Panel panel = new Panel(Align.CENTERED, Align.CENTERED, 75, 502, Graphics.color_red);
        static Label label_Title = new Label("The last bite", 0, 50, Application.Font_TheImpostorTitle, white, transparent);
        static Label label_SubTitle = new Label("M A I N  M E N U", 0, 125, Application.Font_RobotoBlack, white, transparent);

        static Button button_Start = new Button("Start", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, btn_white, btn_hover, buttonBackground, 15);
        static Button button_Settings = new Button("Settings", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, btn_white, btn_hover, buttonBackground, 15);
        static Button button_Credit = new Button("Credit", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, btn_white, btn_hover, buttonBackground, 15);

        public static void UI()
        {
            SetWindowBackColor(backgroundColor);


            label_Title.CenterX();
            label_Title.Show();

            label_SubTitle.CenterX();
            label_SubTitle.Show();

            button_Start.CenterX();
            button_Start.MoveY((Application.WINDOW_HEIGHT / 2) - (button_Start.height / 2 + 50) + 100);
            button_Start.Show();
            if (button_Start.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Audio.PlaySound(Application.Music_Click);
                state = GameState.Game;
            }

            button_Settings.CenterX();
            button_Settings.MoveY((Application.WINDOW_HEIGHT / 2) - (button_Settings.height / 2) + 100);
            button_Settings.Show();
            if (button_Settings.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Audio.PlaySound(Application.Music_Click);
                Settings.LastState = GameState.Menu;
                state = GameState.Settings;
            }

            button_Credit.CenterX();
            button_Credit.MoveY((Application.WINDOW_HEIGHT / 2) - (button_Start.height / 2 - 50) + 100);
            button_Credit.Show();
            if (button_Credit.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Audio.PlaySound(Application.Music_Click);
                state = GameState.Credit;
            }
        }
    }
}

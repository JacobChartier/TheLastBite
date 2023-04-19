using static GameEngine.UserInterface.Graphics;

namespace GameEngine.UserInterface.UI
{
    internal class Settings
    {
        static byte volume = 100;

        static bool debugLayer = true;

        static Label label_Title = new Label("The last bite", 0, 50, Application.Font_TheImpostorTitle, white, transparent);
        static Label label_SubTitle = new Label("S E T T I N G S", 0, 125, Application.Font_RobotoBlack, white, transparent);

        static Label label_Audio = new Label("Audio", 0, 250, Application.Font_RobotoBlack, white, transparent);
        static Label label_MasterVolume = new Label($"Master volume {volume}%", 0, 300, Application.Font_RobotoRegular, white, transparent);
        static Button button_SoundUp = new Button(" + ", 0, 300, Application.Font_RobotoBlackSub, btn_white, btn_hover, buttonBackground, 10);
        static Button button_SoundDown = new Button(" - ", 0, 300, Application.Font_RobotoBlackSub, btn_white, btn_hover, buttonBackground, 10);

        static Label label_Error = new Label("No settings available", 0, 325, Application.Font_RobotoRegular, error, transparent);

        static Label label_Video = new Label("Video", 0, 250, Application.Font_RobotoBlack, white, transparent);

        static Label label_Other = new Label("Other", 0, 250, Application.Font_RobotoBlack, white, transparent);

        static Label label_DebugLayer = new Label("Debug", 0, 300, Application.Font_RobotoRegular, white, transparent);
        static Label label_test = new Label("Test", 0, 325, Application.Font_RobotoRegular, white, transparent);
        static CheckBox checkbox_DebugLayer = new CheckBox(0, 300, 20, debugLayer, btn_white, backgroundColor, white, chk_selected, 2);
        static CheckBox checkbox_test = new CheckBox(0, 325, 20, debugLayer, btn_white, backgroundColor, white, chk_selected, 2);

        static Button button_Back = new Button("Go back", 50, 0, Application.Font_TheImpostor, btn_white, btn_hover, buttonBackground, 15);
        static Button button_Save = new Button("Save", 200, 0, Application.Font_TheImpostor, btn_white, btn_hover, buttonBackground, 15);

        public static void UI()
        {
            label_MasterVolume = new Label($"Master volume {volume}%", 0, 300, Application.Font_RobotoRegular, white, transparent);
            SetWindowBackColor(backgroundColor);

            label_Title.CenterX();
            label_Title.Show();

            label_SubTitle.CenterX();
            label_SubTitle.Show();

            label_Audio.MoveX(((Application.WINDOW_WIDTH / 3) / 2) - (label_Audio.width / 2));
            label_Audio.Show();

            label_MasterVolume.MoveX(((Application.WINDOW_WIDTH / 3) / 2) - (label_Audio.width / 2) - 100);
            label_MasterVolume.Show();
            button_SoundUp.MoveX(((Application.WINDOW_WIDTH / 3) / 2) - (label_Audio.width / 2) + 175);
            button_SoundUp.Show();
            if (button_SoundUp.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                volume++;
                Audio.SetVolume(volume);
                Audio.PlaySound(Application.Music_Click);
            }
            button_SoundDown.MoveX(((Application.WINDOW_WIDTH / 3) / 2) - (label_Audio.width / 2) + 145);
            button_SoundDown.Show();
            if (button_SoundDown.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                volume--;
                Audio.SetVolume(volume);
                Audio.PlaySound(Application.Music_Click);
            }

            label_Video.CenterX();
            label_Video.Show();

            label_Error.CenterX();
            label_Error.Show();

            label_Other.MoveX(((Application.WINDOW_WIDTH / 5) * 4) - (label_Other.width / 2));
            label_Other.Show();

            label_DebugLayer.MoveX(((Application.WINDOW_WIDTH / 5) * 4) - (label_Other.width / 2) - 100);
            label_DebugLayer.Show();
            label_test.MoveX(((Application.WINDOW_WIDTH / 5) * 4) - (label_Other.width / 2) - 100);
            label_test.Show();

            checkbox_DebugLayer.MoveX(((Application.WINDOW_WIDTH / 5) * 4) - (label_Other.width / 2) + 150);
            checkbox_DebugLayer.Show();
            if (checkbox_DebugLayer.Clicked())
            {
                checkbox_DebugLayer.state = !checkbox_DebugLayer.state;
                Inputs.MouseLeftButtonClicked = false;
            }

            checkbox_test.MoveX(((Application.WINDOW_WIDTH / 5) * 4) - (label_Other.width / 2) + 150);
            checkbox_test.Show();
            if (checkbox_test.Clicked())
            {
                checkbox_test.state = !checkbox_test.state;
                Inputs.MouseLeftButtonClicked = false;
            }

            button_Back.MoveY(Application.WINDOW_HEIGHT - 50);
            button_Back.Show();
            if (button_Back.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Menu;
            }

            button_Save.MoveY(Application.WINDOW_HEIGHT - 50);
            button_Save.Show();
        }
    }
}

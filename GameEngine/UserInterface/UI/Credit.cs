using static GameEngine.UserInterface.Graphics;

namespace GameEngine.UserInterface.UI
{
    public class Credit
    {
        static Label label_Title = new Label("The last bite", 0, 50, Application.Font_TheImpostorTitle, white, transparent);
        static Label label_SubTitle = new Label("C R E D I T S", 0, 125, Application.Font_RobotoBlack, white, transparent);

        static Label label_QH = new Label("Quoc Huy Ly", 0, 250, Application.Font_RobotoBlackSub, white, transparent);
        static Label label_JM = new Label("Jaime Meza Uribe", 0, 275, Application.Font_RobotoBlackSub, white, transparent);
        static Label label_JC = new Label("Jacob Chartier", 0, 300, Application.Font_RobotoBlackSub, white, transparent);

        static Label label_QH_Desc = new Label("Documentation", 0, 250, Application.Font_RobotoRegular, white, transparent);
        static Label label_JM_Desc = new Label("Art & Sound", 0, 275, Application.Font_RobotoRegular, white, transparent);
        static Label label_JC_Desc = new Label("Prototype & Art", 0, 300, Application.Font_RobotoRegular, white, transparent);

        static Button button_Back = new Button("Go back", 50, 0, Application.Font_TheImpostor, btn_white, btn_hover, buttonBackground, 15);

        public void Show()
        {
            SetWindowBackColor(backgroundColor);

            label_Title.CenterX();
            label_Title.Show();

            label_SubTitle.CenterX();
            label_SubTitle.Show();

            label_QH.MoveX((Application.WINDOW_WIDTH / 2) - label_QH.width - 10);
            label_QH.Show();

            label_QH_Desc.MoveX((Application.WINDOW_WIDTH / 2) + 10);
            label_QH_Desc.Show();

            label_JM.MoveX((Application.WINDOW_WIDTH / 2) - label_JM.width - 10);
            label_JM.Show();

            label_JM_Desc.MoveX((Application.WINDOW_WIDTH / 2) + 10);
            label_JM_Desc.Show();

            label_JC.MoveX((Application.WINDOW_WIDTH / 2) - label_JC.width - 10);
            label_JC.Show();

            label_JC_Desc.MoveX((Application.WINDOW_WIDTH / 2) + 10);
            label_JC_Desc.Show();

            button_Back.MoveY(Application.WINDOW_HEIGHT - 50);
            button_Back.Show();

            if (button_Back.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Menu;
            }
        }
    }
}

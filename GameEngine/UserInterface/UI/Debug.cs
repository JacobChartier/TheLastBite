using GameEngine.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.UserInterface.UI
{
    internal class Debug
    {
        public static GameManager manager = Graphics.manager;

        static Label label_Entity = new Label($"Entity : {manager.player.name}", 0, -25, Application.Font_RobotoDebug, Graphics.white, Graphics.transparent, 2);

        static Label label_health;

        static Label label_PosX;
        static Label label_PosY;
        static Label label_PosZ;


        static Graphics gfx = new Graphics();

        public static void Show()
        {
            label_health = new Label($"Health : {manager.player.health}", 0, -25, Application.Font_RobotoDebug, Graphics.btn_white, Graphics.transparent, 2);

            label_PosX = new Label($"X : {manager.player.position.x}", 0, -25, Application.Font_RobotoDebug, Graphics.red, Graphics.transparent, 2);
            label_PosY = new Label($"Y : {manager.player.position.y}", 0, -25, Application.Font_RobotoDebug, Graphics.green, Graphics.transparent, 2);
            label_PosZ = new Label($"Z : N/A", 0, -25, Application.Font_RobotoDebug, Graphics.blue, Graphics.transparent, 2);

            label_Entity.MoveX((int)manager.player.position.x + (manager.player.width / 2) - (label_Entity.width / 2));
            label_Entity.MoveY((int)manager.player.position.y - manager.player.height - label_health.height - label_PosX.height - 10);
            label_Entity.Show();

            label_health.MoveX((int)manager.player.position.x + (manager.player.width / 2) - label_health.width + (label_health.width / 2));
            label_health.MoveY((int)manager.player.position.y - manager.player.height - label_PosX.height - 6);
            label_health.Show();

            label_PosX.MoveX((int)manager.player.position.x + (manager.player.width / 2) - (label_PosY.width / 2) - label_PosX.width - 5);
            label_PosX.MoveY((int)manager.player.position.y - manager.player.height - 2);
            label_PosX.Show();

            label_PosY.MoveX((int)manager.player.position.x + (manager.player.width / 2) - label_PosY.width + (label_PosY.width / 2));
            label_PosY.MoveY((int)manager.player.position.y - manager.player.height - 2);
            label_PosY.Show();

            label_PosZ.MoveX((int)manager.player.position.x + (manager.player.width / 2) + (label_PosY.width / 2) + 5);
            label_PosZ.MoveY((int)manager.player.position.y - manager.player.height - 2);
            label_PosZ.Show();
        }
    }
}

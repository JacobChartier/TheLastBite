using GameEngine.GameElements;
using GameEngine.GameElements.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.UserInterface.UI
{
    internal class Debug
    {
        public static GameManager manager = Graphics.manager;

        static Label label_FPS;
        static Label label_Vel;
        static Label label_VelGoal;    
        static Label label_Entity = new Label($"Entity : {manager.player.name}", 0, -25, Application.Font_RobotoDebug, Graphics.white, Graphics.transparent, 2);

        static Label label_health;

        static Label label_PosX;
        static Label label_PosY;
        static Label label_PosZ;


        static Graphics gfx = new Graphics();

        public static void Show()
        {
            try
            {
                label_FPS = new Label($"Frame per second : {Application.averageFPS}", 0, -25, Application.Font_RobotoDebug, Graphics.white, Graphics.gray);

                label_PosX = new Label($"X : {System.Math.Round(manager.player.position.x, 2).ToString("0.00")}", 0, -25, Application.Font_RobotoDebug, Graphics.red, Graphics.gray);
                label_PosY = new Label($"Y : {System.Math.Round(manager.player.position.y, 2).ToString("0.00")}", 0, -25, Application.Font_RobotoDebug, Graphics.green, Graphics.gray);
                label_PosZ = new Label($"Z : N/A", 0, -25, Application.Font_RobotoDebug, Graphics.blue, Graphics.gray);

                label_Vel = new Label($"Velocity : X {System.Math.Round(manager.player.velocity.x, 2).ToString("0.00")}, Y {System.Math.Round(manager.player.velocity.y, 2).ToString("0.00")}", 0, -25, Application.Font_RobotoDebug, Graphics.white, Graphics.gray);
                label_VelGoal = new Label($"Vel. Goal : X {System.Math.Round(manager.player.velocityGoal.x, 2).ToString("0.00")}, Y {System.Math.Round(manager.player.velocityGoal.y, 2).ToString("0.00")}", 0, -25, Application.Font_RobotoDebug, Graphics.white, Graphics.gray);


                // FPS
                label_FPS.MoveX(25);
                label_FPS.MoveY(25);
                label_FPS.Show();

                // X, Y, Z
                label_PosX.MoveX(25);
                label_PosX.MoveY(55);
                label_PosX.Show();

                label_PosY.MoveX(40 + label_PosX.width);
                label_PosY.MoveY(55);
                label_PosY.Show();

                label_PosZ.MoveX(55 + label_PosX.width + label_PosY.width);
                label_PosZ.MoveY(55);
                label_PosZ.Show();

                // VEL, VEL_GOAL
                label_Vel.MoveX(25);
                label_Vel.MoveY(85);
                label_Vel.Show();

                label_VelGoal.MoveX(40 + label_Vel.width);
                label_VelGoal.MoveY(85);
                label_VelGoal.Show();


                label_health = new Label($"Health : {manager.player.health}", 0, -25, Application.Font_RobotoDebug, Graphics.btn_white, Graphics.transparent, 2);

                label_PosX = new Label($"X : {System.Math.Round(manager.player.position.x, 2).ToString("#.00")}", 0, -25, Application.Font_RobotoDebug, Graphics.red, Graphics.transparent, 2);
                label_PosY = new Label($"Y : {System.Math.Round(manager.player.position.y, 2).ToString("#.00")}", 0, -25, Application.Font_RobotoDebug, Graphics.green, Graphics.transparent, 2);
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
            catch (Exception exception)
            {
                Log.Fatal(exception, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

    }
}

using GameEngine.GameElements.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameElements
{
    public class GameManager : Math
    {
        public Player player { get; set; }

        Vector2D spawnPoint;

        public GameManager()
        {
            spawnPoint.x = Application.WINDOW_WIDTH / 2;
            spawnPoint.y = Application.WINDOW_HEIGHT - 100;

            player = new Player("PLAYER", 10, spawnPoint, 25, 25);
        }
    }
}

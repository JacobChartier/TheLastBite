using GameEngine.UserInterface.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.UserInterface
{
    internal sealed class Panel : UI.UI
    {
        private Rectangle borderRectangle;
        private Color borderColor = new Color { red = 0, green = 0, blue = 0, alpha = 0 };

        public Panel(int x, int y, int width, int height, Color color) : base(x, y, width, height, color)
        {
            Rectangle rectangle = new Rectangle() { x = x, y = y, width = width, height = height };
        }

        public Panel(Align x, Align y, int width, int height, Color color) : base(x, y, width, height, color)
        {
            Rectangle rectangle = new Rectangle() { x = base.rectangle.x, y = base.rectangle.y, width = width, height = height };
        }

        public override void Show()
        {
            DrawRectangle(rectangle, color);
        }
    }
}

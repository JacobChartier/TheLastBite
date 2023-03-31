using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBite
{
    internal class Player
    {
        public string name { get; private set; }
        public int health { get; set; }
        public int collectible { get; private set; }

        public Player(string name)
        {
            this.name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeRPG_Game
{
    internal class Boss : Enemy
    {
        public Boss() : base("Bowser")
        {
            Health = 150;

        }
    }
}

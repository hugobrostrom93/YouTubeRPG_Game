using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeRPG_Game
{
    internal class Enemy
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; set; }

        public Enemy(string name)
        {
            Health = 100;
            Name = name;
        }

        public void GetsHit(int hit_value)
        {
            Health = Health - hit_value;

            Console.WriteLine(Name + " was hit for " + hit_value + " damage! He now have " + Health + " hp left");

            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Console.WriteLine(Name + " has died!");
            IsDead = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeRPG_Game
{
    internal class Player
    {

        public int Health { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public bool isGuaring { get; set; }

        public Player()
        {
            Health = 100;
        }

        public void GetsHit(int hit_value)
        {
            // Check if the player was guarding
            if (isGuaring)
            {
                // Write out that the player guarded the attack
                Console.WriteLine(Name + " guarded the blow and was unharmed!");

                // Remove the guard
                isGuaring = false;

            } else
            {
                Health = Health - hit_value;

                Console.WriteLine(Name + " was hit for " + hit_value + " damage! You now have " + Health + " hp left");
            }            

            if (Health <= 0)
            {
                Die();
            }
        }

        public void Heal(int amount_to_heal)
        {
            Health = Health + amount_to_heal;
            // Gör så man inte kan heala över 100 hp
            if (Health > 100)
            {
                Health = 100;
            }
            Console.WriteLine(Name + " has healed " + amount_to_heal + " hp. You now have " + Health + " hp remaining");
        }

        private void Die()
        {
            Console.WriteLine(Name + " has died!");
            IsDead = true;
        }
    }
}

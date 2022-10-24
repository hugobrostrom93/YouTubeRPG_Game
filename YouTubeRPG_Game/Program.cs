namespace YouTubeRPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();


            Player player = new Player();

            Console.WriteLine("What is your name:");
            player.Name = Console.ReadLine();
            Console.WriteLine("Thank you for entering your name, " + player.Name + ".\n");

            Enemy firstEnemy = new Enemy("Giant Enemy Crab");

            // Perform the battle game loop
            GameLoop(firstEnemy, random, player, 5, 20);

            // Check if the player was the one who died
            if (!player.IsDead)
            {
                Boss boss = new Boss();
                // Perform the battle game loop
                GameLoop(boss, random, player, 50, 10);

                // Check if the player was the one who died
                if (!player.IsDead)
                {
                    // The player won the game
                    Console.WriteLine("Congratulations " + player.Name + " you defeted all the enemies and have won the game!");
                } else
                {
                    {
                        // The player is dead. Let the player know and end the game
                        GameOver();
                    }
                }

            } else
            {
                // The player is dead. Let the player know and end the game
                GameOver();
            }
        }

        private static void GameOver()
        {
            Console.WriteLine("GAME OVER!!!");
        }

        private static void GameLoop(Enemy enemy, Random random, Player player, int max_attack_power, int max_player_attack_power)
        {
            Console.WriteLine(player.Name + " you have encountered a " + enemy.Name + "!");


            while (!enemy.IsDead && !player.IsDead)
            {
                Console.WriteLine("What would you like to do? \n\n1. Single Attack \n2. Three Strike Attack \n3. Defend \n4. Heal");

                string playerAction = Console.ReadLine();

                switch (playerAction)
                {
                    case "1":
                        Console.WriteLine("\nYou choose to single attack the " + enemy.Name + "!");

                        // Apply the attack damage to the enemy
                        enemy.GetsHit(random.Next(1, max_player_attack_power));
                        break;

                    case "2":
                        Console.WriteLine("\nYou choose to three strike attack the " + enemy.Name + "!");
                        for (int i = 0; i < 3; i++)
                        {
                            // Apply the attack damage to the enemy
                            enemy.GetsHit(random.Next(1, max_player_attack_power));

                            // Make sure the enemy is not dead and when he is you will stop attack and move on to the next monster
                            if (enemy.IsDead)
                            {
                                break;
                            }

                        }
                        break;

                    case "3":
                        Console.WriteLine("You choose to defend!");
                        // Set that the player is guarding
                        player.isGuaring = true;
                        break;

                    case "4":
                        Console.WriteLine("You choose to heal!");
                        player.Heal(random.Next(1, 15));
                        break;

                    default:
                        Console.WriteLine("You choose something else");
                        break;
                }
                // Make sure the enemy is not dead so we dont continue to attack when he is dead if we choose 3 swing attack
                if (!enemy.IsDead)
                {
                    // Have the enemy attacke the player after the player attacks
                    player.GetsHit(random.Next(1, max_attack_power));
                }
            }
        }
    }
}
using System;

namespace YouTubeRPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gameHistory = new List<string>();


            Random random = new Random();
            Player player = new Player();

            Console.WriteLine("What is your name:");
            player.Name = Console.ReadLine();
            Console.WriteLine("Thank you for entering your name, " + player.Name + ".\n");

            Enemy firstEnemy = new Enemy("Giant Enemy Crab");

            // Perform the battle game loop
            GameLoop(firstEnemy, random, player, 5, 20, gameHistory);

            // Check if the player was the one who died
            if (!player.IsDead)
            {
                Boss boss = new Boss();
                // Perform the battle game loop
                GameLoop(boss, random, player, 50, 10, gameHistory);

                // Check if the player was the one who died
                if (!player.IsDead)
                {
                    // The player won the game
                    Console.WriteLine("Congratulations " + player.Name + " you defeted all the enemies and have won the game!");
                }
                else
                {
                    // The player is dead. Let the player know and end the game
                    GameOver();
                }

                // Let the player know this is the history
                Console.WriteLine("\n\nThis is the history of the game: \n\n");

                // Loop through the whole game history
                foreach (var history in gameHistory)
                {
                    // Write out the game history
                    Console.WriteLine(history);
                }

            }
            else // KAN JAG TA BORT DENNA!?
            {
                // The player is dead. Let the player know and end the game
                GameOver();
            }
        }

        private static void GameOver() // private static gör sa att vi kommer åt nedan kod inne i main pga den också är static 
        {
            Console.WriteLine("GAME OVER!!!");
        }

        // max_attack_power = max damge from monster 
        // max_player_attack_power = max damge from player
        private static void GameLoop(Enemy enemy, Random random, Player player, int max_attack_power, int max_player_attack_power, List<string> gameHistoryList)
        {
            // Define a list of the strings we will use to write out
            string initialText = player.Name + " you have encountered a " + enemy.Name + "!";
            string attackText = null;
            string enemyAttackText = null;

            Console.WriteLine(initialText);

            // Add the string to the game history
            gameHistoryList.Add(initialText);

            while (!enemy.IsDead && !player.IsDead)
            {
                Console.WriteLine("What would you like to do? \n\n1. Single Attack \n2. Three Strike Attack \n3. Defend \n4. Heal");

                string playerAction = Console.ReadLine();

                switch (playerAction)
                {
                    case "1":
                        // Save the attack text.
                        attackText = "\nYou choose to single attack the " + enemy.Name + "!";
                        Console.WriteLine(attackText);

                        // Add the history
                        gameHistoryList.Add(attackText);

                        // Apply the attack damage to the enemy
                        enemy.GetsHit(random.Next(1, max_player_attack_power));
                        break;

                    case "2":
                        // Save the attack text.
                        attackText = "\nYou choose to three strike attack the " + enemy.Name + "!";
                        Console.WriteLine(attackText);

                        // Add the history
                        gameHistoryList.Add(attackText);

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
                        // Save the attack text.
                        attackText = "You choose to defend!";
                        Console.WriteLine(attackText);

                        // Add the history
                        gameHistoryList.Add(attackText);

                        // Set that the player is guarding
                        player.isGuaring = true;
                        break;

                    case "4":
                        // Save the attack text.
                        attackText = "You choose to heal!";
                        Console.WriteLine(attackText);

                        // Add the history
                        gameHistoryList.Add(attackText);

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
                    enemyAttackText = "The enemy attacked the player and the player has " + player.GetsHit(random.Next(1, max_attack_power)) + " health remaining";

                    // Add to the list that the enemy attacked you 
                    gameHistoryList.Add(enemyAttackText);

                }
            }
        }
    }
}
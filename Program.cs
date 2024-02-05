using System;

namespace spaceAdventure
{
    class SpaceAdventure
    {
        static void Main(string[] args)
        {
            int lives = 0, energy = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;

            Console.Write("What is the name of your space explorer? ");
            string explorerName = Console.ReadLine()!;

            initValues(ref lives, ref energy, ref health, r);

            while (lives > 0 && energy > 0 && health > 0 && !win)
            {
                direction = chooseDirection();

                if (direction == 1)
                    spaceActions(r.Next(4), ref lives, ref energy, ref health);
                else
                    spaceActions(r.Next(10), ref lives, ref energy, ref health);

                checkResults(ref round, ref lives, ref energy, ref health, ref win);
            }

            if (win)
                Console.WriteLine($"Congratulations, {explorerName}! You've successfully completed your space adventure!");
            else if (lives <= 0)
                Console.WriteLine($"{explorerName}, you lost too many lives and did not complete your space journey");
            else if (energy <= 0)
                Console.WriteLine($"{explorerName}, you don't have any energy left and cannot continue your space adventure");
            else
                Console.WriteLine($"{explorerName}, your health is critical. Your space journey ends prematurely.");
        }

        private static int chooseDirection()
        {
            Console.WriteLine("You are at a cosmic crossroad. Enter 1 to explore left and 2 to explore right");
            int direction = int.Parse(Console.ReadLine()!);

            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number. Please enter 1 for left or 2 for right");
                direction = int.Parse(Console.ReadLine()!);
            }

            return direction;
        }

        private static void initValues(ref int lives, ref int energy, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            energy = r.Next(15) + 5;
            health = r.Next(14) + 5;
        }

        private static void spaceActions(int num, ref int lives, ref int energy, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You encountered a black hole. It drains your energy and poses a threat to your health.");
                    Console.WriteLine("You lose 2 units of energy and 1 unit of health");
                    energy -= 2;
                    health -= 1;
                    break;
                case 1:
                    Console.WriteLine("You discovered a friendly alien civilization. They share their advanced technology with you.");
                    Console.WriteLine("You gain 3 units of energy and 2 units of health");
                    energy += 3;
                    health += 2;
                    break;
                case 2:
                    Console.WriteLine("You entered a space storm. It damages your spaceship and drains your energy.");
                    Console.WriteLine("You lose 1 unit of energy and 2 units of health");
                    energy -= 1;
                    health -= 2;
                    break;
                case 3:
                    Console.WriteLine("You found a hidden space oasis with healing properties.");
                    Console.WriteLine("You gain 2 units of health and 1 unit of energy");
                    health += 2;
                    energy += 1;
                    break;
                case 4:
                    Console.WriteLine("You encountered hostile space pirates. They attack your spaceship.");
                    Console.WriteLine("You lose 1 unit of health and 2 units of energy");
                    health -= 1;
                    energy -= 2;
                    break;
                case 5:
                    Console.WriteLine("You discovered a wormhole shortcut, saving energy and time.");
                    Console.WriteLine("You gain 2 units of energy and move ahead faster.");
                    energy += 2;
                    break;
                case 6:
                    Console.WriteLine("You stumbled upon a deserted planet rich in resources.");
                    Console.WriteLine("You gain 3 units of energy and 1 unit of health");
                    energy += 3;
                    health += 1;
                    break;
                case 7:
                    Console.WriteLine("A mysterious cosmic entity grants you a power boost.");
                    Console.WriteLine("You gain 2 units of energy and 2 units of health");
                    energy += 2;
                    health += 2;
                    break;
                case 8:
                    Console.WriteLine("You encountered a malfunction in your spacesuit. Repairing it drains your energy.");
                    Console.WriteLine("You lose 2 units of energy, but manage to fix your suit.");
                    energy -= 2;
                    break;
                case 9:
                    Console.WriteLine("You reached a beautiful nebula. It rejuvenates your spirit and health.");
                    Console.WriteLine("You gain 2 units of health and a sense of wonder.");
                    health += 2;
                    break;
                default:
                    Console.WriteLine("You successfully navigated through a dense asteroid field.");
                    Console.WriteLine("You gain 1 life and 1 unit of energy");
                    lives += 1;
                    energy += 1;
                    break;
            }
        }

        private static void checkResults(ref int round, ref int lives, ref int energy, ref int health, ref bool win)
        {
            round++;
            Console.WriteLine($"\n~~~~~~~~~~~~ Space Adventure - Round {round} ~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Lives: {lives} Energy: {energy} Health: {health}\n");

            if (round >= 20)
                win = true;
        }
    }
}

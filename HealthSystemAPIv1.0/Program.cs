using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemAPIv1._0
{
    internal class Program
    {

        static int health;
        static int currentHealth;
        static int minHealth = 0;
        static int maxHealth = 100;
        static int shield;
        static int currentShield;
        static int minShield = 0;
        static int maxShield = 100;
        static int lives;
        static int defaultLives = 3;
        static int minLives = 0;
        static int maxLives = 99;
        static string healthStatus;

        static void Main(string[] args)
        {
            health = maxHealth;
            shield = maxShield;
            lives = defaultLives;

            //Shield Damage Test
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            TakeDamage(51);
            ShowHUD();
            Reset();

            //Life Damage Test
            ShowHUD();
            TakeDamage(201);
            ShowHUD();
            TakeDamage(201);
            ShowHUD();
            TakeDamage(201);
            ShowHUD();
            Reset();


        }
        
        static void ShowHUD()
        {
            ShowStatus();
            Console.WriteLine("---------------");
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Status: " + healthStatus);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("---------------");
            if (lives == minLives)
            {
                Console.WriteLine("");
                Console.WriteLine("  You Died!!!");
                Console.WriteLine("");
                Console.WriteLine("---------------");
            }
            Console.ReadKey();
            
        }

        static void ShowStatus()
        {
            if (health == maxHealth)
            {
                healthStatus = "Perfect Health.";
            }
            else if (health < maxHealth && health >= 90)
            {
                healthStatus = "Near Perfect Health.";
            }
            else if (health < 90 && health >= 80)
            {
                healthStatus = "Slightly Damaged.";
            }
            else if (health < 80 && health >= 70)
            {
                healthStatus = "Damaged.";
            }
            else if (health < 70 && health >= 60)
            {
                healthStatus = "Fairly Damaged.";
            }
            else if (health < 60 && health >= 50)
            {
                healthStatus = "Pretty Damaged.";
            }
            else if (health < 50 && health >= 40)
            {
                healthStatus = "You Might Need A Break.";
            }
            else if (health < 40 && health >= 30)
            {
                healthStatus = "Come On Rest A Bit.";
            }
            else if (health < 30 && health >= 20)
            {
                healthStatus = "Hey You Know You Don't Have To Continue Right?";
            }
            else if (health < 20 && health >= 10)
            {
                healthStatus = "Go See A Healer Now!!";
            }
            else if (health < 10 && health > 0)
            {
                healthStatus = "Stop... Get Some Help!!";
            }
            else if (health <= 0)
            {
                healthStatus = "Oh... Look Who Died.";
            }
        }

        static void TakeDamage(int damage)
        {
            Console.WriteLine("");
            Console.WriteLine("Debug: the player is about to take " + damage + " points of damage.");
            Console.WriteLine("");

            if (damage >= minShield)
            {
                currentShield = shield;
                shield = shield - damage;
                
                if (shield <= minShield)
                {
                    shield = minShield;
                    damage = damage - currentShield;
                    currentHealth = health;
                    health = health - damage;
                    if (health <= minHealth)
                    {
                        lives = lives - 1;
                        damage = damage - currentHealth;
                        Console.WriteLine("You have taken " + damage + " extra damage.");
                        Console.WriteLine("You have lost life.");
                        Console.WriteLine("");
                        shield = maxShield;
                        health = maxHealth;
                    }
                }
            }
            else if (damage < minShield)
            {
                Console.WriteLine("");
                Console.WriteLine("Error: You can't take negative damage, that would be a heal.");
                Console.WriteLine("");
            }
        }

        static void Heal(int hp)
        {
            Console.WriteLine("");
            Console.WriteLine("Debug: the player is about to heal " + hp + " points of damage.");
            Console.WriteLine("");
        }

        //static void RegenerateShield(int hp)
        //{

        //}
        
        static void Reset()
        {
            //Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("---------------");
            Console.WriteLine("");
            Console.WriteLine(" System Reset! ");
            Console.WriteLine("");
            health = maxHealth;
            shield = maxShield;
            lives = defaultLives;
        }

    }
}

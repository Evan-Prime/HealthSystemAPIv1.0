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
            TakeDamage(30);
            ShowHUD();
            TakeDamage(70);
            ShowHUD();
            Reset();

            //Health Damage Test
            ShowHUD();
            TakeDamage(100);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            TakeDamage(9);
            ShowHUD();
            Reset();

            //Life Damage Test
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            TakeDamage(237);
            ShowHUD();
            TakeDamage(579);
            ShowHUD();
            Reset();

            //Shield Regeneration Test
            ShowHUD();
            TakeDamage(100);
            ShowHUD();
            RegenerateShield(10);
            ShowHUD();
            RegenerateShield(15);
            ShowHUD();
            RegenerateShield(15);
            ShowHUD();
            RegenerateShield(10);
            ShowHUD();
            RegenerateShield(90);
            ShowHUD();
            RegenerateShield(10);
            ShowHUD();
            Reset();

            //Heal Test
            ShowHUD();
            TakeDamage(199);
            ShowHUD();
            Heal(14);
            ShowHUD();
            Heal(13);
            ShowHUD();
            Heal(30);
            ShowHUD();
            Heal(2);
            ShowHUD();
            Heal(25);
            ShowHUD();
            Heal(20);
            ShowHUD();
            Heal(11);
            ShowHUD();
            Reset();

            //1-Up Test
            ShowHUD();
            TakeDamage(200);
            ShowHUD();
            OneUp(1);
            ShowHUD();
            OneUp(5);
            ShowHUD();
            OneUp(10);
            ShowHUD();
            OneUp(4);
            ShowHUD();
            OneUp(80);
            ShowHUD();
            OneUp(3);
            Reset();

            //Error checking
            ShowHUD();
            TakeDamage(-29);
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            RegenerateShield(-35);
            ShowHUD();
            TakeDamage(100);
            ShowHUD();
            TakeDamage(-40);
            ShowHUD();
            Heal(-60);
            ShowHUD();
            TakeDamage(50);
            ShowHUD();
            OneUp(-5);
            ShowHUD();

        }
        
        static void ShowHUD()
        {
            ShowStatus();
            Console.WriteLine(" +---------------");
            Console.WriteLine(" |Shield: " + shield);
            Console.WriteLine(" |Health: " + health);
            Console.WriteLine(" |Status: " + healthStatus);
            Console.WriteLine(" |Lives: " + lives);
            Console.WriteLine(" +---------------");
            if (lives == minLives)
            {
                Console.WriteLine(" |");
                Console.WriteLine(" |  You Died!!!");
                Console.WriteLine(" |");
                Console.WriteLine(" +---------------");
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
            else if (health < 10 && health >= 0)
            {
                healthStatus = "Stop... Get Some Help!!";
            }
        }

        static void TakeDamage(int damage)
        {
            Console.WriteLine("");
            Console.WriteLine(" Debug: the player is about to take " + damage + " points of damage.");
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
                        Console.WriteLine(" You have taken " + damage + " extra damage.");
                        Console.WriteLine(" You have lost life.");
                        Console.WriteLine("");
                        shield = maxShield;
                        health = maxHealth;
                    }
                }
            }
            else if (damage < minShield)
            {
                Console.WriteLine("");
                Console.WriteLine(" Error: You can't take negative damage, that would be a heal.");
                Console.WriteLine("");
            }
        }

        static void Heal(int hp)
        {
            Console.WriteLine("");
            Console.WriteLine(" Debug: the player is about to heal " + hp + " points of damage.");
            Console.WriteLine("");
            if (hp >= minHealth && health < maxHealth)
            {
                health = health + hp;
                if (health >= maxHealth)
                {
                    health = maxHealth;
                }
            }
            else if (hp < minHealth)
            {
                Console.WriteLine("");
                Console.WriteLine(" Error: You can't negative heal, that would be a damage.");
                Console.WriteLine("");
            }
            else if (hp == maxHealth)
            {
                Console.WriteLine("");
                Console.WriteLine(" Debug: the player is already at max health.");
                Console.WriteLine("");
            }
        }

        static void RegenerateShield(int hp)
        {
            Console.WriteLine("");
            Console.WriteLine(" Debug: the player is about to regenerate " + hp + " shields.");
            Console.WriteLine("");
            if (hp >= minShield && shield < maxShield)
            {
                shield = shield + hp;
                if (shield >= maxShield)
                {
                    shield = maxShield;
                }
            }
            else if (hp < minShield)
            {
                Console.WriteLine("");
                Console.WriteLine(" Error: the player can't regenerate negative shields.");
                Console.WriteLine("");
            }
            else if (shield == maxShield)
            {
                Console.WriteLine("");
                Console.WriteLine(" Debug: the player is already at max shields.");
                Console.WriteLine("");
            }
        }
        
        static void Reset()
        {
            //Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine(" +---------------");
            Console.WriteLine(" |");
            Console.WriteLine(" | System Reset! ");
            Console.WriteLine(" |");
            health = maxHealth;
            shield = maxShield;
            lives = defaultLives;
        }

        static void OneUp(int hp)
        {
            Console.WriteLine("");
            Console.WriteLine(" Debug: the player is about to pick up " + hp + " 1-Ups.");
            Console.WriteLine("");
            if(hp > minLives && lives < maxLives)
            {
                lives = lives + hp;
                if (lives >= maxLives)
                {
                    lives = maxLives;
                }
            }
            else if (hp < minHealth)
            {
                Console.WriteLine("");
                Console.WriteLine(" Error: the player can't get negative 1-Up.");
                Console.WriteLine("");
            }
            else if (lives == maxLives)
            {
                Console.WriteLine("");
                Console.WriteLine(" Debug: the player is already at max lives.");
                Console.WriteLine("");
            }
        }
    }
}

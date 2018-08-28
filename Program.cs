using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("myHuman");
            Wizard wizard = new Wizard("myWizard");

            wizard.Heal(human);
            wizard.Heal(wizard);
            wizard.Study();
        }
    }

    public class Human
    {
        public string name;
        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= strength * 5;
            }
        }
    }

    public class Wizard : Human
    {
        public new int intelligence = 125;
        public new int health = 125;
        public Wizard(string person) : base(person) {}

        public int Heal(Human user)
        {
            Console.WriteLine($"{name} is healing {user.name}");
            int heal = intelligence/100;
            user.health += heal;
            Console.WriteLine($"{user.name} receives {heal} health and now has {user.health} health points.");
            return (int)health;
        }

        public int Study()
        {
            intelligence += 5;
            Console.Write($"{name} has delved into the mysteries of the mind, body, and world and has now increased intelligence points by 5. Total intelligence for {name} is {intelligence}");
            return intelligence;
        }

        public int Curse(Human user)
        {
            Console.WriteLine($"{name} curses {user.name}");
            Random rand = new Random();
            int damage = rand.Next(0,5)*intelligence/100;
            user.health -= damage;
            Console.WriteLine($"{user.name} loses {damage} health points from {name}'s curse.");
            if (user.health <= 0) Console.WriteLine($"{user.name} is now dead. XX");
            return user.health;
        }

    }

    public class Ninja : Human
    {
        public new int strength = 50;
        public new int dexterity = 100;
        public Ninja(string person) : base(person) {}
    }

    public class Samurai : Human
    {
        public new int strength = 75;
        public new int dexterity = 25;
        public new int health = 105;
        public Samurai(string person) : base(person) {}
    }

}

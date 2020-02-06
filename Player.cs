using System;
using System.Windows;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Player : Characters
    {
        public int maxHealthpoints;
        public int numberOfPotion;
        public Player(string name, int healthpoints, int maxHealthpoints, int numberOfPotion, List<Item> inventory, string characteristics) : base(name, healthpoints, inventory, characteristics)
        {
            this.maxHealthpoints = maxHealthpoints;
            this.numberOfPotion = numberOfPotion;
        }
        public override void DisplayCharacter()
        {

        }
        public void MakeAMove(Door _door)
        {
            //TODO 
        }
        public void ShowInventory()
        {
            foreach (Item _item in inventory)
            {
                Console.WriteLine(_item);
            }
        }
        public void DisplayCommands()
        {
            Console.WriteLine("commands (c), move north(n), move east (n), move south (s), move west (w), look (l), inventory (i), take (t) <item>, drop (d) <item>, use (u) <item> with <object>, attack (a) <character>. ask (ask) <character>, take potion (p)");
        }
        public void TakeItem(Item item)
        {
            inventory.Add(item);

        }
        public override void dropItem(Item item)
        {
            inventory.Remove(item);
        }
        public void UseItem()
        {
            Console.WriteLine("Which item do you want to use?");
        }
        public void TakePotion()
        {
            if (numberOfPotion != 0)
            {
                if (healthpoints != maxHealthpoints)
                {
                    healthpoints += (int)(healthpoints * 0.2f);
                    if (healthpoints < maxHealthpoints)
                        healthpoints = maxHealthpoints;
                    numberOfPotion--;
                }
                else
                    Console.WriteLine("You have enough live. You don't need a potion");
            }
            else
                Console.WriteLine("You don't have a potion.");

        }
        public NPC AttackNPC(NPC _nPC)
        {
            double minDamage;
            double maxDamage;
            Random random = new Random();
            if (_nPC.strength == 1)
            {
                minDamage = 0.4;
                maxDamage = 0.6f;
                double damage = random.NextDouble() * (maxDamage - minDamage) + minDamage;
                _nPC.healthpoints -= (int)(healthpoints * damage);
            }
            if (_nPC.strength == 2)
            {
                minDamage = 0.2f;
                maxDamage = 0.4f;
                double damage = random.NextDouble() * (maxDamage - minDamage) + minDamage;
                _nPC.healthpoints -= (int)(healthpoints * damage);
            }
            if (_nPC.strength == 3)
            {
                minDamage = 0.0f;
                maxDamage = 0.2f;
                double damage = random.NextDouble() * (maxDamage - minDamage) + minDamage;
                _nPC.healthpoints -= (int)(healthpoints * damage);
            }
            return _nPC;
        }

    }
}
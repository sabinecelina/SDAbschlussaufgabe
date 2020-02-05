using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Player : Characters
    {
        public int maxHealthpoints;
        public int numberOfPotion;
        public Player(string name, int healthpoints, int maxHealthpoints, int numberOfPotion, List<string> inventory, string characteristics) : base(name, healthpoints, inventory, characteristics)
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
            foreach (string _item in inventory)
            {
                Console.WriteLine(_item);
            }
        }
        public void DisplayCommands()
        {
            Console.WriteLine("commands (c), move north(n), move east (n), move south (s), move west (w), look (l), inventory (i), take (t) <item>, drop (d) <item>, use (u) <item> with <object>, attack (a) <character>. ask (ask) <character>, take potion (p)");
        }
        public void TakeItem(string item)
        {
            inventory.Add(item);

        }
        public override void dropItem(string item)
        {
            inventory.Remove(item);
        }
        public void UseItem(string item)
        {
            //TODO
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
        public void AttackNPC(NPC nPC)
        {
            //TODO
        }

    }
}
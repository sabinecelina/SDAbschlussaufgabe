using System;
using System.Windows;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Player : Characters
    {
        public int maxHealthpoints;
        public int location;
        public int numberOfPotion;

        public Player(string name, int healthpoints, int maxHealthpoints, int location, List<string> inventory, string characteristics) : base(name, healthpoints, inventory, characteristics)
        {
            this.maxHealthpoints = maxHealthpoints;
            this.location = location;
        }
        public override void DisplayCharacter()
        {
            Console.WriteLine("I am :" + name + "My characteristics are: " + characteristics);
            Console.WriteLine("I have :" + maxHealthpoints + "life and in my bag are: ");
            foreach (string _item in inventory)
            {
                Console.WriteLine(_item);
            }
        }
        public bool MakeAMove(Door _door)
        {
            bool _isOpen = false;
            for (int i = 0; i < Game._rooms.Count; i++)
            {
                if (_door.isOpen)
                {
                    this.location = _door.leadsTo.location;
                    _isOpen = true;
                }
                else if (!_door.isOpen)
                {
                    foreach (char _information in _door.informationHowToOpen)
                    {
                        if (_information == '?')
                        {
                            Console.WriteLine(_door.informationHowToOpen);
                            Console.WriteLine("Please answer the question to open the door.");
                            string input = Console.ReadLine();
                            if (input == _door.objectYouNeedToOpen)
                            {
                                _door.isOpen = true;
                                _isOpen = true;
                            }
                            this.location = _door.leadsTo.location;
                        }
                    }
                }
            }
            if (!_isOpen)
            {
                Console.WriteLine("This door is closed. You need to open it to step in.");
                Console.WriteLine(_door.informationHowToOpen);
            }
            return _isOpen;
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
        public void UseItem()
        {
            bool _doorIsOpen = false;
            Console.WriteLine("Which item do you want to use?");
            Console.Write("> ");
            string _item = Console.ReadLine();
            Console.WriteLine("On what Object you want to use it?");
            Console.Write("> ");
            string _object = Console.ReadLine();
            for (int i = 0; i < Game._rooms.Count; i++)
            {
                if (inventory[i] == _item)
                {
                    for (int j = 0; j < Game._rooms[i].doors.Count; j++)
                    {
                        if (inventory[i] == Game._rooms[i].doors[j].objectYouNeedToOpen)
                        {
                            Game._rooms[i].doors[j].isOpen = true;
                            _doorIsOpen = true;
                        }
                    }
                }
            }
            if (_doorIsOpen)
                Console.WriteLine("You used " + _item + "on" + _object + "and opened a door");
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
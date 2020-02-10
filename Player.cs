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
        public string startGameAdventure;
        public string endGameAdventure;

        public Player(string name, int healthpoints, int maxHealthpoints, int location, List<string> inventory, string characteristics) : base(name, healthpoints, inventory, characteristics)
        {
            this.maxHealthpoints = maxHealthpoints;
            this.location = location;
        }
        public override void DisplayCharacter()
        {
            Console.WriteLine("I am " + name + ", a " + characteristics + ".");
            Console.WriteLine("I have " + numberOfPotion + " potion in my secret bag which you can't see. So remember your number of potions. In my bag are: ");
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
                    this.location = _door.LeadsTo().location;
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
                            for (int j = 0; j < Game._player.inventory.Count; j++)
                            {
                                if (input == _door.objectYouNeedToOpen || Game._player.inventory[j] == "thieftool")
                                {
                                    _door.isOpen = true;
                                    _isOpen = true;
                                }
                                if (input == "q")
                                {
                                    _isOpen = false;
                                }

                            }
                            this.location = _door.LeadsTo().location;
                            Console.WriteLine("You opened a door, Gratulation");
                        }
                    }
                }
            }
            if (!_isOpen)
            {
                for (int i = 0; i <= Game._rooms.Count - 1; i++)
                {
                    for (int j = 0; j < Game._rooms[i].doors.Count - 1; j++)
                    {
                        if (Game._rooms[i].doors[j].objectYouNeedToOpen == Game._currentRoom.nameOfRoom && Game._rooms[i].doors[j].isOpen)
                        {
                            _isOpen = true;
                        }
                    }
                }
            }
            if (!_isOpen)
            {
                Console.WriteLine("This door is closed. You need to open it to step in.");
                Console.WriteLine(_door.informationHowToOpen);
            }
            Random random = new Random();
            int rnd = random.Next(0, Game._rooms.Count - 1);
            for (int i = 0; i <= Game._rooms.Count - 1; i++)
            {
                for (int j = 0; j <= Game._rooms[i].nPCs.Count - 1; j++)
                {
                    if (Game._rooms[i].nPCs[j].strength == 2)
                    {
                        Game._rooms[rnd].nPCs.Add(Game._rooms[i].nPCs[j]);
                        Game._rooms[i].nPCs.Remove(Game._rooms[i].nPCs[j]);
                    }

                }
            }
            return _isOpen;
        }
        public void ShowInventory()
        {
            Console.WriteLine("You have " + healthpoints + " healthpoints and: ");
            foreach (string _item in inventory)
            {
                Console.WriteLine(_item);
            }
        }
        public void DisplayCommands()
        {
            Console.WriteLine("commands (c): show Commands \n move north(n), move east (n), move south (s), move west (w)\n look (l)\n inventory (i)\n take (t:item) <item>\n drop (d:item) <item>\n use (u) <item> with <object>\n attack (a:nameOfCharacter) <character>.\n ask (ask:nameOfCharacter) <character>\n take potion (p)\n save (save) game\n quit (q) game");
        }
        public void TakeItem(string item)
        {
            if (inventory.Count <= 4)
            {
                inventory.Add(item);
                if (item.Equals("gift"))
                {
                    string[] _gift = new string[] { "posion", "posion", "posion", "posion" };
                    Random random = new Random();
                    int rnd = random.Next(0, 4);
                    item = _gift[rnd];
                    if (item.Equals("potion"))
                    {
                        inventory.Add(item);
                        inventory.Remove("gift");
                    }
                    if (item.Equals("posion"))
                    {
                        Console.WriteLine("hahaha, you got a posion, you lost some healthpoints");
                        Game._currentHealthpoints -= 15;
                        inventory.Remove(item);
                        inventory.Remove("gift");
                    }
                }
            }
            else
                Console.WriteLine("You already have enough in your bag. You can't take more");
            ShowInventory();
        }
        public override void dropItem(string item)
        {
            inventory.Remove(item);
            Console.WriteLine("You removed this " + item);
        }
        public void UseItem(Player _player)
        {
            bool _doorIsOpen = false;
            Console.WriteLine("Which item do you want to use?");
            Console.Write("> ");
            string _item = Console.ReadLine();
            Console.WriteLine("On what Object you want to use it?");
            Console.Write("> ");
            string _object = Console.ReadLine();
            for (int i = 0; i <= inventory.Count - 1; i++)
            {
                if (inventory[i].Equals(_item))
                {
                    for (int j = 0; j <= Game._currentRoom.doors.Count - 1; j++)
                    {
                        if (_object.Equals(Game._currentRoom.doors[j].objectYouNeedToOpen))
                        {
                            Game._currentRoom.doors[j].isOpen = true;
                            _doorIsOpen = true;
                            Game._player.inventory.Remove(_item);
                            Game._player.inventory.Remove(_object);
                            Game._currentRoom.inventory.Remove(_object);
                        }
                    }
                    for (int m = 0; m < Game._currentRoom.nPCs.Count; m++)
                    {
                        if (_object.Equals(Game._currentRoom.nPCs[m].name))
                        {
                            Game._currentRoom.nPCs[m].isAlive = false;
                        }
                    }
                }
            }
            if (_doorIsOpen)
                Console.WriteLine("You used " + _item + " on " + _object + " and opened a door");
        }
        public int TakePotion(int _currentHealthpoints)
        {
            for (int i = 0; i <= inventory.Count - 1; i++)
            {
                if (inventory[i] == "potion")
                    numberOfPotion++;
            }
            if (numberOfPotion != 0)
            {
                if (_currentHealthpoints != maxHealthpoints)
                {
                    _currentHealthpoints += 35;
                    if (_currentHealthpoints > maxHealthpoints)
                        _currentHealthpoints = maxHealthpoints;
                    numberOfPotion--;
                    try
                    {
                        inventory.Remove("potion");
                    }
                    catch (Exception)
                    {
                    }
                    Console.WriteLine("You drank your potion. Your healthpoints now are: " + _currentHealthpoints);
                }
                else
                    Console.WriteLine("You have enough live. You don't need a potion");
            }
            else
                Console.WriteLine("You don't have a potion.");
            return _currentHealthpoints;
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
            Console.WriteLine("You attacked " + _nPC.name + ". His healthpoints now are: " + _nPC.healthpoints);
            if (_nPC.healthpoints <= 0)
                _nPC.isAlive = false;
            return _nPC;
        }

    }
}
using System;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
namespace AdventureGame
{
    public class NPC : Characters
    {
        public int strength;
        public bool isAlive = true;
        public bool isGood;
        private string information;
        public NPC(string name, int healthpoints, List<string> inventory, string characteristics, int strength, bool isGood, string information) : base(name, healthpoints, inventory, characteristics)
        {
            this.strength = strength;
            this.isGood = isGood;
            this.information = information;
        }

        public override void DisplayCharacter()
        {
            Console.WriteLine("I am :" + name + "My characteristics are: " + characteristics);
            //TODO name: the warrior, the lucky one, the thief
        }
        public override void dropItem(string item)
        {
            if (IsAlive())
            {
                Game._player.inventory.Add(item);
                inventory.Remove(item);
            }
        }
        public Player AttackPlayer(Player _player)
        {
            double minDamage;
            double maxDamage;
            Random random = new Random();
            if (IsAlive())
            {
                if (this.strength == 1)
                {
                    minDamage = 0.0;
                    maxDamage = 0.2;
                    double damage = random.NextDouble() * (maxDamage - minDamage) + minDamage;
                    _player.healthpoints -= (int)(healthpoints * damage);
                }
                if (this.strength == 2)
                {
                    minDamage = 0.2f;
                    maxDamage = 0.4f;
                    double damage = random.NextDouble() * (maxDamage - minDamage) + minDamage;
                    _player.healthpoints -= (int)(healthpoints * damage);
                }
                if (this.strength == 3)
                {
                    minDamage = 0.4f;
                    maxDamage = 0.6f;
                    double damage = random.NextDouble() * (maxDamage - minDamage) + minDamage;
                    _player.healthpoints -= (int)(healthpoints * damage);
                }

            }
            else if (!IsAlive())
            {
                Console.WriteLine("You killed him");
                for (int i = 0; i <= Game._rooms.Count - 1; i++)
                {
                    for (int j = 0; j <= Game._rooms[i].nPCs.Count - 1; j++)
                    {
                        if (Game._rooms[i].nPCs[j].strength == 2)
                        {
                            Game._rooms[i].nPCs.Remove(Game._rooms[i].nPCs[j]);
                        }

                    }
                }
            }
            Console.WriteLine("You got attackted. You have now: " + _player.healthpoints + " healthpoints");
            return _player;
        }
        public Player AttackPlayerAfterHeJoinedRoom(Player _player)
        {
            if (Game._makeAMove)
            {
                AttackPlayer(_player);
            }
            return _player;
        }
        public bool IsAlive()
        {
            if (healthpoints <= 0)
                return !isAlive;
            else
                return isAlive;
        }
        public void GiveInformation()
        {
            if (isGood)
            {
                DisplayCharacter();
                Console.WriteLine(information);
            }
            else if (!isGood)
            {
                Console.WriteLine("hahaha, you wish");
                AttackPlayer(Game._player);
            }
        }
    }
}

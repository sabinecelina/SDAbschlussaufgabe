using System;
using System.Collections.Generic;
namespace AdventureGame
{
    public class NPC : Characters
    {
        public int strength;
        public bool isAlive = true;
        private string information;
        public NPC(string name, int healthpoints, List<string> inventory, string characteristics, int strength, string information) : base(name, healthpoints, inventory, characteristics)
        {
            this.strength = strength;
            this.information = information;
        }

        public override void DisplayCharacter()
        {
            Console.WriteLine("I am :" + name + "My characteristics are: " + characteristics);
            //TODO name: the warrior, the lucky one, the thief
        }
        public override void dropItem(string item)
        {
            //TODO
        }
        public void AttackPlayer(Player player)
        {
            //TODO
        }
        public void changeRoom()
        {
            //TODO
        }
        public void GiveInformation()
        {
            Console.WriteLine(information);
        }
    }
}
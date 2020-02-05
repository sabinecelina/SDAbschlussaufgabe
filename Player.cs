using System.Collections.Generic;

namespace AdventureGame
{
    public class Player : Characters
    {
        public int maxHealthpoints;
        public Player(string name, int healthpoints, int maxHealthpoints, List<string> inventory, string characteristics) : base(name, healthpoints, inventory, characteristics)
        {
            this.maxHealthpoints = maxHealthpoints;
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
            //TODO list inventory
        }
        public void DisplayCommands()
        {
            //TODO
        }
        public void TakeItem(string item)
        {
            //TODO
        }
        public override void dropItem(string item)
        {
            //TODO
        }
        public void UseItem(string item)
        {
            //TODO
        }
        public void AttackNPC(NPC nPC)
        {
            //TODO
        }

    }
}
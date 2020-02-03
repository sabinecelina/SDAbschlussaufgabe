using System.Collections.Generic;
namespace AdventureGame
{
    public class NPC : Characters
    {
        private int strength;
        private string information;
        public NPC(string name, int healthpoints, List<string> inventory, string characteristics, int strength, string information) : base(name, healthpoints, inventory, characteristics)
        {
            this.strength = strength;
            this.information = information;
        }
        public override void DisplayCharacter()
        {

        }
    }
}
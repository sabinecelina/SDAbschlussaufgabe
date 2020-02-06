using System.Collections.Generic;

namespace AdventureGame
{
    public abstract class Characters
    {
        public string name;
        public int healthpoints;
        public List<string> inventory;
        public string characteristics;
        public abstract void DisplayCharacter();
        public abstract void dropItem(string item);
        public Characters(string name, int healthpoints, List<string> inventory, string characteristics)
        {
            this.name = name;
            this.healthpoints = healthpoints;
            this.inventory = inventory;
            this.characteristics = characteristics;
        }
    }
}
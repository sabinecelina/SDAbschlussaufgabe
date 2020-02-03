using System.Collections.Generic;

namespace AdventureGame
{
    public abstract class Characters
    {
        private string name;
        private int healthpoints;
        private string characteristics;
        private List<string> inventory;
        public abstract void DisplayCharacter(); 
    }
}
using System.Collections.Generic;

namespace AdventureGame
{
    public abstract class Characters
    {
        private string name;
        private int healthpoints;
        private List<string> inventory;
        private string characteristics;
        public abstract void DisplayCharacter();
    }
}
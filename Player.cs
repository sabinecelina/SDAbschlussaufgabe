using System.Collections.Generic;

namespace AdventureGame
{
    public class Player : Characters
    {
        public Player(string name, int healthpoints, List<string> inventory, string characteristics) : base(name, healthpoints, inventory, characteristics)
        {
        }
        public override void DisplayCharacter()
        {

        }
    }
}
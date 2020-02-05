namespace AdventureGame
{
    public class Door
    {
        public string doorDirection;
        public bool isOpen;
        public Room leadsTo;
        public string howToOpen;
        public Door(string doorDirection, bool isOpen, Room leadsTo, string howToOpen)
        {
            this.doorDirection = doorDirection;
            this.isOpen = isOpen;
            this.leadsTo = leadsTo;
            this.howToOpen = howToOpen;
        }
    }
}
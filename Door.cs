namespace AdventureGame
{
    public class Door
    {
        public string doorDirection;
        public bool isOpen;
        public Room leadsTo;
        public string informationHowToOpen;
        public string objectYouNeedToOpen;
        public Door(string doorDirection, bool isOpen, Room leadsTo, string informationHowToOpen, string objectYouNeedToOpen)
        {
            this.doorDirection = doorDirection;
            this.isOpen = isOpen;
            this.leadsTo = leadsTo;
            this.informationHowToOpen = informationHowToOpen;
            this.objectYouNeedToOpen = objectYouNeedToOpen;
        }
    }
}
namespace AdventureGame
{
    public class Door
    {
        public string doorDirection;
        public bool isOpen;
        private string leadsTo;
        public string informationHowToOpen;
        public string objectYouNeedToOpen;
        public Door(string doorDirection, bool isOpen, string leadsTo, string informationHowToOpen, string objectYouNeedToOpen)
        {
            this.doorDirection = doorDirection;
            this.isOpen = isOpen;
            this.leadsTo = leadsTo;
            this.informationHowToOpen = informationHowToOpen;
            this.objectYouNeedToOpen = objectYouNeedToOpen;
        }
        public Room LeadsTo()
        {
            Room _room = new Room();
            for (int i = 0; i < Game._rooms.Count; i++)
            {
                if (Game._rooms[i].nameOfRoom == leadsTo)
                    return Game._rooms[i];
            }
            return _room;
        }
    }
}
using System.Collections.Generic;

namespace AdventureGame
{
    public class Room
    {
        private Door north;
        private Door east;
        private Door south;
        private Door west;
        int location;
        private List<NPC> nPCs;
        //special items which are usefull
        private List<string> specialItem;
        private List<string> inventory;

        public Room(Door north, Door east, Door south, Door west, int location, List<NPC> nPCs, List<string> inventory, List<string> specialItem)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;
            this.nPCs = nPCs;
            this.inventory = inventory;
            this.specialItem = specialItem;
        }
        public void ShowRoomDescription()
        {
            //TODO toString with npcs, specialItem, inventory
        }

    }
}
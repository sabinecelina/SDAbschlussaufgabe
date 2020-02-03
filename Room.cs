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

    }
}
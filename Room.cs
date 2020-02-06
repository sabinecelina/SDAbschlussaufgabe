using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Room
    {
        public string nameOfRoom;
        public int location;
        public List<Door> doors;
        public List<NPC> nPCs;
        public List<Item> inventory;

        public Room(string nameOfRoom, int location, List<Door> doors, List<NPC> nPCs, List<Item> inventory)
        {
            this.nameOfRoom = nameOfRoom;
            this.location = location;
            this.doors = doors;
            this.nPCs = nPCs;
            this.inventory = inventory;
        }
        public void ShowRoomDescription()
        {
            Console.WriteLine("You are in a " + nameOfRoom + ". You can see: ");
            foreach (Item _item in inventory)
            {
                Console.WriteLine(_item.item.Key);
            }
            if (nPCs.Count != 0)
            {
                foreach (NPC _nPCs in nPCs)
                {
                    Console.WriteLine(_nPCs.name + " : " + _nPCs.characteristics);
                }
            }
        }

    }
}
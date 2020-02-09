using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Room
    {
        public string nameOfRoom;
        public int location;
        public string description;
        public List<Door> doors;
        public List<NPC> nPCs;
        public List<string> inventory;

        public Room(string nameOfRoom, int location, string description, List<Door> doors, List<NPC> nPCs, List<string> inventory)
        {
            this.nameOfRoom = nameOfRoom;
            this.location = location;
            this.description = description;
            this.doors = doors;
            this.nPCs = nPCs;
            this.inventory = inventory;
        }
        public Room()
        {

        }
        public void ShowRoomDescription()
        {
            Console.WriteLine("You are in a " + nameOfRoom + ". " + description + " You can see: ");
            if (inventory.Count >= 1)
            {
                foreach (string _item in inventory)
                {
                    Console.WriteLine(_item);
                }
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
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Game
    {
        public List<Room> _rooms;
        private Player _player;
        private bool _gameOver = false;
        protected Room _currentRoom;
        private NPC _currentNPC;

        public static void Main(string[] args)
        {
            //TODO
        }
        public void LoadGame()
        {
            //TODO
        }
        public void PlayGame()
        {
            if (!_gameOver)
            {

                for (int i = 0; i < _rooms.Count; i++)
                {
                    if (_rooms[i].location == 1)
                    {
                        _rooms[i].ShowRoomDescription();
                        _currentRoom = _rooms[i];
                    }
                    Console.WriteLine("What do you want to do?");
                    Console.Write(">");

                    string userInput = Console.ReadLine();
                    string[] input = userInput.Split(" ");
                    List<NPC> _npc = _currentRoom.nPCs;
                    for (int n = 0; n < _npc.Count; n++)
                    {
                        if (_npc[n].name == input[1])
                            _currentNPC = _npc[n];
                    }

                    switch (input[0])
                    {
                        case "l":
                            _currentRoom.ShowRoomDescription();
                            break;
                        case "i":
                            _player.ShowInventory();
                            break;
                        case "c":
                            _player.DisplayCommands();
                            break;
                        case "p":
                            _player.TakePotion();
                            break;
                        case "t":
                            _player.TakeItem(input[1]);
                            _currentRoom.inventory.Remove(input[1]);
                            break;
                        case "d":
                            _player.dropItem(input[1]);
                            _currentRoom.inventory.Add(input[1]);
                            break;
                        case "u":
                            _player.UseItem();
                            break;
                        case "a":
                            _player.AttackNPC(_currentNPC);
                            break;
                        case "ask":
                            _currentNPC.GiveInformation();
                            break;

                    }
                }
            }
        }

        public void SaveGame()
        {
            //TODO
        }
        public void QuitGame()
        {
            Debugger.Break();
        }
    }
}
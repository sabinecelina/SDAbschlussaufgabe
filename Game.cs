using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Game
    {
        public List<Room> _rooms;
        private Player _player;
        private bool _gameOver = false;
        private Room currentRoom;

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
                        currentRoom = _rooms[i];
                    }
                    Console.WriteLine("What do you want to do?");
                    Console.Write(">");

                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "l":
                            currentRoom.ShowRoomDescription();
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
            //TODO
        }
    }
}
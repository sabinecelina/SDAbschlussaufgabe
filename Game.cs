using System.Diagnostics;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Linq;

namespace AdventureGame
{
    public class Game
    {
        public static List<Room> _rooms = new List<Room>();
        public static Player _player;
        private bool _gameOver = false;
        public Room _currentRoom;
        private NPC _currentNPC;
        private Door _door;
        private int _newLocation;
        private bool _makeAMove;
        private string _item;
        public static Game _game = new Game();

        public static void Main()
        {
            _game.LoadGame();
            _game.StartGame();
            _game.PlayGame();
        }
        public void LoadGame()
        {
            string path = "C:/RoomsJson.json";

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                _rooms = JsonConvert.DeserializeObject<List<Room>>(json);
                _currentRoom = _rooms[0];
            }
            string path2 = "C:/PlayerJson.json";

            using (StreamReader r = new StreamReader(path2))
            {
                string json = r.ReadToEnd();
                _player = JsonConvert.DeserializeObject<Player>(json);
            }
        }
        public void PlayGame()
        {
            if (!IsGameOver())
            {

                Console.WriteLine("What do you want to do?");
                Console.Write(">");

                string userInput = Console.ReadLine();
                string[] input = userInput.Split(":");
                List<NPC> _npc = _currentRoom.nPCs;

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
                        for (int m = 0; m < _currentRoom.inventory.Count; m++)
                        {
                            if (_currentRoom.inventory[m] == input[1])
                            {
                                _item = _currentRoom.inventory[m];
                                _player.TakeItem(input[1]);
                                _currentRoom.inventory.Remove(_item);
                            }
                        }
                        break;
                    case "d":
                        _player.dropItem(input[1]);
                        _currentRoom.inventory.Add(_item);
                        break;
                    case "u":
                        _player.UseItem();
                        break;
                    case "a":
                        for (int m = 0; m < _currentRoom.nPCs.Count; m++)
                        {
                            if (_currentRoom.nPCs[m].name == input[1])
                            {
                                _currentNPC = _currentRoom.nPCs[m];
                                _currentNPC = _player.AttackNPC(_currentNPC);
                            }
                        }
                        break;
                    case "ask":
                        for (int m = 0; m < _currentRoom.nPCs.Count; m++)
                        {
                            if (_currentRoom.nPCs[m].name == input[1])
                            {
                                _currentNPC = _currentRoom.nPCs[m];
                                _currentNPC.GiveInformation();
                            }
                        }
                        break;
                    case "n":
                    case "s":
                    case "e":
                    case "w":
                        for (int g = 0; g < _currentRoom.doors.Count; g++)
                        {
                            if (_currentRoom.doors[g].doorDirection == input[0])
                            {
                                _door = _currentRoom.doors[g];
                                _currentRoom = _currentRoom.doors[g].LeadsTo();
                                _makeAMove = _player.MakeAMove(_door);
                            }
                            else
                            {
                                Console.WriteLine("There is no door. Please try it with an another door.");
                            }
                        }
                        if (_makeAMove)
                        {
                            _currentRoom.ShowRoomDescription();
                            _makeAMove = false;
                        }
                        break;
                    case "q":
                        QuitGame();
                        break;
                    case "save":
                        SavedGame();
                        break;
                }
                PlayGame();
            }
            else
            {
                Console.WriteLine("You died, this game is over");
            }
        }
        public void StartGame()
        {
            _rooms[0].ShowRoomDescription();
            _currentRoom = _rooms[0];
        }
        public string SaveGameRoom<Room>(string jsonPath, Room _room)
        {
            string jsonString;
            jsonString = System.Text.Json.JsonSerializer.Serialize(_rooms);
            File.WriteAllText("savegames", jsonString);
            return JsonConvert.SerializeObject(_room);
        }
        public string SaveGame<Player>(string jsonPath, Player _room)
        {
            string jsonString;
            jsonString = System.Text.Json.JsonSerializer.Serialize(_player);
            File.WriteAllText("savegames", jsonString);
            return JsonConvert.SerializeObject(_player);
        }
        public void SavedGame()
        {
            string pathText = "SaveGameRoom.json";
            string updatedJson = SaveGameRoom(pathText, _rooms);
            File.WriteAllText(pathText, updatedJson);
            Console.WriteLine(updatedJson.ToString());
            string pathPlayer = "SaveGamePlayer.json";
            string updatedJsonPLayer = SaveGameRoom(pathPlayer, _rooms);
            File.WriteAllText(pathPlayer, updatedJsonPLayer);
            Console.WriteLine(updatedJsonPLayer.ToString());
        }
        public void QuitGame()
        {
            Environment.Exit(0);
        }
        public bool IsGameOver()
        {
            for (int i = 0; i <= Game._rooms.Count - 1; i++)
            {
                for (int j = 0; j <= Game._rooms[i].nPCs.Count - 1; j++)
                {
                    Console.WriteLine(Game._rooms[i].nPCs[j].name);
                    if (_player.healthpoints == 0)
                    {
                        IsGameOver = true;
                    }
                }
            }
        }
    }
}
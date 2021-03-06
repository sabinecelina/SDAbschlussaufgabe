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
        public static Room _currentRoom;
        public static NPC _currentNPC;
        public static int _currentHealthpoints = 0;
        private Door _door;
        public static bool _makeAMove;
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
                _currentHealthpoints = _player.healthpoints;
            }
        }
        public void PlayGame()
        {
            if (!IsGameOver() && !IsGameWinning())
            {

                Console.WriteLine("What do you want to do?");
                Console.Write(">");

                string userInput = Console.ReadLine();
                string[] input = userInput.Split(":");
                List<NPC> _npc = _currentRoom.nPCs;

                switch (input[0])
                {
                    case "l":
                        _currentRoom.ShowRoomDescription(_currentRoom);
                        break;
                    case "i":
                        _player.ShowInventory();
                        break;
                    case "c":
                        _player.DisplayCommands();
                        break;
                    case "p":
                        _currentHealthpoints = _player.TakePotion(_currentHealthpoints);
                        _player.healthpoints = _currentHealthpoints;
                        break;
                    case "t":
                        for (int m = 0; m < _currentRoom.inventory.Count; m++)
                        {
                            if (input.Count() > 1 && _currentRoom.inventory[m] == input[1])
                            {
                                _item = _currentRoom.inventory[m];
                                _player.TakeItem(_player, input[1]);
                                _currentRoom.inventory.Remove(_item);
                            }
                        }
                        _player.healthpoints = _currentHealthpoints;
                        break;
                    case "d":
                        _player.dropItem(_player, input[1]);
                        _currentRoom.inventory.Add(input[1]);
                        break;
                    case "u":
                        _player.UseItem(_player, _currentRoom);
                        break;
                    case "a":
                        _player.healthpoints = _currentHealthpoints;
                        for (int m = 0; m < _currentRoom.nPCs.Count; m++)
                        {
                            if (input.Count() > 1 && _currentRoom.nPCs[m].name == input[1])
                            {
                                _currentNPC = _currentRoom.nPCs[m];
                                _currentNPC = _player.AttackNPC(_currentNPC);
                                if (_currentNPC.isAlive)
                                    _currentHealthpoints = _currentNPC.AttackPlayer(_player);
                                else
                                    _currentHealthpoints = _currentNPC.AttackPlayer(_player);
                            }
                        }
                        break;
                    case "ask":
                        for (int m = 0; m < _currentRoom.nPCs.Count; m++)
                        {
                            if (input.Count() > 1 && _currentRoom.nPCs[m].name == input[1])
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
                        try
                        {
                            {
                                foreach (NPC npc in _currentRoom.nPCs)
                                {
                                    if (npc.isAlive)
                                        _currentHealthpoints = npc.AttackPlayer(_player);
                                }

                            }

                        }
                        catch (Exception)
                        {

                        }
                        foreach (Door _rightDoor in _currentRoom.doors)
                        {
                            if (_rightDoor.doorDirection == input[0])
                            {
                                _door = _rightDoor;
                                _makeAMove = _player.MakeAMove(_player, _door, _rooms, _currentRoom);
                            }
                        }
                        if (_makeAMove)
                        {
                            _currentRoom = _door.LeadsTo();
                            _currentRoom.ShowRoomDescription(_currentRoom);
                        }
                        break;
                    case "q":
                        QuitGame();
                        break;
                    case "save":
                        SavedGame();
                        break;
                }
            }
            else if (IsGameOver())
            {
                Console.WriteLine("You died, this game is over");
                _game.QuitGame();
            }
            else if (IsGameWinning())
            {
                Console.WriteLine(_player.endGameAdventure);
                _game.QuitGame();

            }
            else
                Console.WriteLine("Your input was invalid, please try it again.");
            _game.PlayGame();

        }
        public void StartGame()
        {
            Console.WriteLine(_player.startGameAdventure + "\n");
            _player.DisplayCharacter();
            Console.WriteLine("\n");
            _player.DisplayCommands();
            Console.WriteLine("\n");
            _player.healthpoints = _currentHealthpoints;
            _currentRoom = _rooms[0];
            _rooms[0].ShowRoomDescription(_currentRoom);
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
            if (_player.healthpoints <= 0)
                _gameOver = true;
            return _gameOver;
        }
        public bool IsGameWinning()
        {
            bool _gameWinning = false;
            for (int i = 0; i <= Game._rooms.Count - 1; i++)
            {
                for (int j = 0; j <= Game._rooms[i].nPCs.Count - 1; j++)
                {
                    if (Game._rooms[i].nPCs[j].strength == 3 && !Game._rooms[i].nPCs[j].isAlive)
                    {
                        _gameWinning = true;
                    }
                }
            }
            return _gameWinning;
        }
    }
}
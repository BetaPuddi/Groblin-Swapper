using System;
using System.Collections.Generic;
using Enums;
using Rooms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class DungeonManager : MonoBehaviour
    {
        public static DungeonManager instance;

        public List<RoomBase> listOfRooms;
        public RoomBase currentRoom;
        public bool inChainEncounter;
        public int chainEncountersCleared;

        [SerializeField]
        private int roomsCleared;
        private int exitChanceModifier;

        public void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void NewRoom()
        {
            currentRoom = listOfRooms[Random.Range(0, listOfRooms.Count)];
            inChainEncounter = currentRoom.isChainRoom;
            currentRoom.encounters[0].StartEncounter();
        }

        public void RoomEncounterCleared()
        {
            chainEncountersCleared++;
            if (chainEncountersCleared > currentRoom.encounters.Count - 1)
            {
                chainEncountersCleared = 0;
                GameManager.instance.UpdateGameState(3);
            }
            else
            {
                currentRoom.encounters[chainEncountersCleared].StartEncounter();
            }
        }

        public void Advance()
        {
            if (GameManager.instance._gameState == EGameStates.Advance && roomsCleared <=10)
            {
                LogManager.instance.InstantiateTextLog("You advance further into the dungeon.");
                //GameManager.instance.UpdateGameState(Random.Range(1, 3));
                NewRoom();
                roomsCleared++;
            }
            else if (GameManager.instance._gameState == EGameStates.Advance && roomsCleared > 10)
            {
                if (RollForExit())
                {
                    GameManager.instance.UpdateGameState(6);
                    LogManager.instance.InstantiateTextLog("You find the dungeon exit!");
                    print("exit");
                }
                else
                {
                    exitChanceModifier++;
                    LogManager.instance.InstantiateTextLog("You advance further into the dungeon.");
                    GameManager.instance.UpdateGameState(Random.Range(1, 3));
                    roomsCleared++;
                }
            }
        }

        private bool RollForExit()
        {
            var randomRoll = Random.Range(0, 100);
            var exitChance = 10 + exitChanceModifier;
            return randomRoll <= exitChance;
        }
    }
}
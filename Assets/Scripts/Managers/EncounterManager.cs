using System;
using Enums;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Encounters
{
    public class EncounterManager : MonoBehaviour
    {
        public static EncounterManager instance;

        [SerializeField]
        private string[] encounterType;
        public string currentEncounterType;

        [SerializeField]
        private int roomsCleared;
        private int exitChanceModifier;

        private void Awake()
        {
            if (instance  == null)
            {
                instance  = this;
            }
        }

        private void Start()
        {
            encounterType = new string[encounterType.Length];
            encounterType[0] = "enemy";
            encounterType[1] = "npc";
            encounterType[2] = "advance";
            encounterType[3] = "exit";
        }

        public void NewEncounter(string encounterType)
        {
            currentEncounterType = encounterType;
            switch(currentEncounterType)
            {
                case "enemy":
                    EnemyManager.instance.SpawnNewEnemy();
                    break;
                case "npc":
                    NPCManager.instance.SpawnNewNPC();
                    break;
                case "advance":
                    break;
                case "start":
                    GameManager.instance.UpdateGameState(1);
                    break;
                case "exit":

                    break;
            }
        }

        public void Advance()
        {
            if (GameManager.instance._gameState == EGameStates.Advance && roomsCleared <=10)
            {
                LogManager.instance.InstantiateTextLog("You advance further into the dungeon.");
                GameManager.instance.UpdateGameState(Random.Range(1, 3));
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

        public void Exit()
        {
            if (GameManager.instance._gameState == EGameStates.Exit)
            {
                GameManager.instance.UpdateGameState(7);
            }
        }

        public void SkipNPC()
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                LogManager.instance.InstantiateTextLog("You decline the swap.");
                GameManager.instance.UpdateGameState(3);
            }
        }
    }
}

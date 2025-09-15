using System;
using Encounters;
using Enums;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public EGameStates _gameState;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void UpdateGameState(int newGameState)
        {
            _gameState = (EGameStates)newGameState;
            UIManager.instance.ToggleInfoUI();
            switch (_gameState)
            {
                case EGameStates.Combat:
                    EncounterManager.instance.NewEncounter("enemy");
                    break;
                case EGameStates.NPC:
                    EncounterManager.instance.NewEncounter("npc");
                    break;
                case EGameStates.Advance:
                    EncounterManager.instance.NewEncounter("advance");
                    break;
                case EGameStates.Start:
                    //UIManager.instance.ToggleUI();
                    EncounterManager.instance.NewEncounter("start");
                    break;
                case EGameStates.GameOver:
                    EnemyManager.instance.targetEnemy.Reset();
                    PlayerManager.instance.InitialisePlayer();
                    PlayerManager.instance.player.Reset();
                    MenuManager.instance.ToggleGameOverMenu();
                    break;
                case EGameStates.MainMenu:
                    break;
                case EGameStates.Exit:
                    EncounterManager.instance.NewEncounter("exit");
                    break;
                case EGameStates.Win:
                    MenuManager.instance.ToggleWinMenu();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void EnemyTurn()
        {
            if (_gameState == EGameStates.Combat)
            {
                EnemyManager.instance.targetEnemy.EnemyTakeTurn();
            }
        }
    }
}

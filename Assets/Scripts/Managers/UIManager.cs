using System;
using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public GameObject uiCanvas;
        public GameObject enemyInfoPanel;
        public GameObject playerInfoPanel;
        public GameObject npcInfoPanel;
        public GameObject areaInfoPanel;
        public GameObject settingsPanel;

        public GameObject combatActionSet;
        public GameObject npcActionSet;
        public GameObject areaActionSet;
        public GameObject exitActionSet;

        public AudioSource audioSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            audioSource = GetComponent<AudioSource>();
        }

        public void ToggleInfoUI()
        {
            switch (GameManager.instance._gameState)
            {
                case EGameStates.Combat:
                    enemyInfoPanel.SetActive(true);
                    npcInfoPanel.SetActive(false);
                    areaInfoPanel.SetActive(false);
                    ChangeActionSet();
                    break;
                case EGameStates.Advance:
                    areaInfoPanel.SetActive(true);
                    npcInfoPanel.SetActive(false);
                    enemyInfoPanel.SetActive(false);
                    ChangeActionSet();
                    break;
                case EGameStates.NPC:
                    npcInfoPanel.SetActive(true);
                    areaInfoPanel.SetActive(false);
                    enemyInfoPanel.SetActive(false);
                    ChangeActionSet();
                    break;
                case EGameStates.MainMenu:
                    playerInfoPanel.SetActive(false);
                    npcInfoPanel.SetActive(false);
                    areaInfoPanel.SetActive(false);
                    enemyInfoPanel.SetActive(false);
                    break;
                case EGameStates.GameOver:
                    // playerInfoPanel.SetActive(false);
                    // npcInfoPanel.SetActive(false);
                    // areaInfoPanel.SetActive(false);
                    // enemyInfoPanel.SetActive(false);
                    //ToggleUI();
                    break;
                case EGameStates.Start:
                    playerInfoPanel.SetActive(true);
                    npcInfoPanel.SetActive(false);
                    areaInfoPanel.SetActive(false);
                    enemyInfoPanel.SetActive(false);
                    break;
                case EGameStates.Exit:
                    ChangeActionSet();
                    break;
            }
        }

        public void ToggleUI()
        {
            uiCanvas.SetActive(!uiCanvas.activeSelf);
        }

        public void ChangeActionSet()
        {
            switch (GameManager.instance._gameState)
            {
                case EGameStates.Combat:
                    combatActionSet.SetActive(true);
                    npcActionSet.SetActive(false);
                    areaActionSet.SetActive(false);
                    exitActionSet.SetActive(false);
                    break;
                case EGameStates.NPC:
                    combatActionSet.SetActive(false);
                    npcActionSet.SetActive(true);
                    areaActionSet.SetActive(false);
                    exitActionSet.SetActive(false);
                    break;
                case EGameStates.Advance:
                    combatActionSet.SetActive(false);
                    npcActionSet.SetActive(false);
                    areaActionSet.SetActive(true);
                    exitActionSet.SetActive(false);
                    break;
                case EGameStates.Exit:
                    combatActionSet.SetActive(false);
                    npcActionSet.SetActive(false);
                    areaActionSet.SetActive(false);
                    exitActionSet.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PlayButtonSound()
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
        }

        public void ToggleSettingsMenu()
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }
}
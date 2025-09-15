using System;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;

        public GameObject mainMenu;
        public GameObject gameOverMenu;
        public GameObject winMenu;
        [TextArea]
        public string introText;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void StartGame()
        {
            ToggleMainMenu();
            LogManager.instance.InstantiateTextLog(introText);
            GameManager.instance.UpdateGameState(0);
        }

        public void ToggleMainMenu()
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
        }

        public void ToggleGameOverMenu()
        {
            gameOverMenu.SetActive(!gameOverMenu.activeSelf);
        }

        public void ToggleWinMenu()
        {
            winMenu.SetActive(!winMenu.activeSelf);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ResetGame()
        {
            // if (GameManager.instance._gameState == EGameStates.GameOver)
            // {
            //     ToggleGameOverMenu();
            // }
            // GameManager.instance.UpdateGameState(5);
            // ToggleMainMenu();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Restart()
        {
            if (GameManager.instance._gameState == EGameStates.GameOver)
            {
                ToggleGameOverMenu();
            }
            GameManager.instance.UpdateGameState(0);
        }
    }
}
using Enemies;
using Enums;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnemyInfoPanel : MonoBehaviour
    {
        public static EnemyInfoPanel instance;

        public GameObject panel;
        public TextMeshProUGUI enemyNameText;
        public TextMeshProUGUI enemyHealthText;
        public TextMeshProUGUI enemyATKText;
        public TextMeshProUGUI enemyDEFText;
        public Image icon;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void UpdateEnemyInfo()
        {
            if (EnemyManager.instance.targetEnemy != null /*&& GameManager.instance._gameState == EGameStates.Combat*/)
            {
                panel.SetActive(true);
                enemyNameText.text = EnemyManager.instance.targetEnemy.enemyName;
                enemyHealthText.text = EnemyManager.instance.targetEnemy.currentHealth.ToString();
                enemyATKText.text = EnemyManager.instance.targetEnemy.attackStat.ToString();
                enemyDEFText.text = EnemyManager.instance.targetEnemy.defenseStat.ToString();
                icon.sprite = EnemyManager.instance.targetEnemy.enemyIcon;
            }
            else
            {
                panel.SetActive(false);
            }
        }

        public void UpdateEnemyHealth(int newHealth)
        {
            enemyHealthText.text = newHealth.ToString();
        }

        /*
        public void SetCurrentEnemy(Enemy newEnemy)
        {
            currentEnemy = newEnemy;
            UpdateEnemyInfo();
        }
        */
    }
}

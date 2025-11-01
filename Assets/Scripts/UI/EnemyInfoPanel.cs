using Enemies;
using Enums;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class EnemyInfoPanel : MonoBehaviour
    {
        public static EnemyInfoPanel instance;

        public GameObject panel;
        public TextMeshProUGUI enemyNameText;
        public TextMeshProUGUI enemyHealthText;
        [FormerlySerializedAs("enemyATKText")] public TextMeshProUGUI enemySTRText;
        [FormerlySerializedAs("enemyDEFText")] public TextMeshProUGUI enemyENDText;
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
                enemyNameText.text = EnemyManager.instance.targetEnemy.characterName;
                enemyHealthText.text = EnemyManager.instance.targetEnemy.currentHealth.ToString();
                enemySTRText.text = EnemyManager.instance.targetEnemy.strengthStat.ToString();
                enemyENDText.text = EnemyManager.instance.targetEnemy.enduranceStat.ToString();
                icon.sprite = EnemyManager.instance.targetEnemy.characterSprite;
            }
            else
            {
                panel.SetActive(false);
            }
        }

        public void UpdateEnemyHealth(float newHealth)
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

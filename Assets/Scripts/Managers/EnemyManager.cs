using System;
using Enemies;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager instance;

        public GameObject[] enemies;
        public Enemy targetEnemy;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void SpawnNewEnemy()
        {
            targetEnemy = enemies[Random.Range(0, enemies.Length)].gameObject.GetComponent<Enemy>();
            targetEnemy.EnemyIntroduction();
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public void ImportEnemyStats()
        {

        }

        public void ImportEnemyAbilities()
        {

        }
    }
}
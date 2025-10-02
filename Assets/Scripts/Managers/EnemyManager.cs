using System;
using System.Collections.Generic;
using Character;
using Enemies;
using ScriptableObjects;
using Skills;
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
        public CharacterDataHolder enemyData;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void SpawnNewEnemy()
        {
            enemyData = enemies[Random.Range(0, enemies.Length)].gameObject.GetComponent<CharacterDataHolder>();
            SetEnemyData();
            targetEnemy.Initialise();
            EnemyIntroduction();
            targetEnemy.UpdateCharacterUI();
        }

        public void SetEnemyData()
        {
            ImportEnemyStats(enemyData.stats);
            ImportEnemyAbilities(enemyData.skillSet);
            targetEnemy.UpdateTotalStats();
        }

        public void ImportEnemyStats(CharacterBaseStats stats)
        {
            targetEnemy.characterBase = stats;
        }

        public void ImportEnemyAbilities(SkillSet skillSet)
        {
            targetEnemy.skills = skillSet;
            targetEnemy.ReplaceSkillset();
        }

        public void EnemyIntroduction()
        {
            LogManager.instance.InstantiateTextLog($"Enemy {targetEnemy.characterName} appears!");
        }
    }
}
using System;
using Enums;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public EnemyBaseStats enemyBaseStats;
        public string enemyName;
        public float baseMaxHealth;
        public float baseAttack;
        public float baseDefense;

        public float bonusMaxHealth;
        public float bonusAttack;
        public float bonusDefense;

        public Sprite enemyIcon;
        public float currentHealth;
        public float maxHealth;
        public float attackStat;
        public float defenseStat;

        private void Start()
        {
            if (GameManager.instance._gameState != EGameStates.MainMenu)
            {
                Reset();
            }
            currentHealth = maxHealth;
        }

        public void SetBaseStats()
        {
            baseMaxHealth = enemyBaseStats.maxHealth;
            baseAttack = enemyBaseStats.attack;
            baseDefense = enemyBaseStats.defense;
        }

        public void UpdateTotalStats()
        {
            maxHealth = baseMaxHealth + bonusMaxHealth;
            attackStat = baseAttack + bonusAttack;
            defenseStat = baseDefense + bonusDefense;
        }

        public void EnemyIntroduction()
        {
            LogManager.instance.InstantiateTextLog($"Enemy {enemyName} appears!");
        }

        public virtual void Attack()
        {
            print("Enemy attack");
            PlayerManager.instance.PlayerTakeDamage(attackStat);
        }

        public virtual void Skill_01()
        {
            print("Enemy skill 01");
        }

        public virtual void Skill_02()
        {
            print("Enemy skill 02");
        }

        public virtual void TakeDamage(float damage)
        {
            currentHealth -= Mathf.RoundToInt(Mathf.Clamp(damage, 0, Mathf.Infinity));
            if (currentHealth <= 0)
            {
                EnemyDeath();
            }

            EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public virtual void Heal(float heal)
        {
            currentHealth += Mathf.RoundToInt(heal);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public void Reset()
        {
            currentHealth = maxHealth;
            EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public void EnemyDeath()
        {
            print("Enemy dead");
            Reset();
            LogManager.instance.InstantiateTextLog($"{enemyName} is defeated!");
            GameManager.instance.UpdateGameState(3);
        }

        public virtual void EnemyTakeTurn()
        {
            var actionRoll = Random.Range(0, 2);
            switch (actionRoll)
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    Skill_01();
                    break;
                // case 2:
                //     Skill_02();
                //     break;
            }
        }

        public void ChangeDefense(int amount)
        {
            defenseStat += amount;
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public void ChangeAttack(int amount)
        {
            attackStat += amount;
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public void ChangeMaxHealth(int amount)
        {
            maxHealth += amount;
            if (currentHealth > maxHealth)
            {
                maxHealth = currentHealth;
            }

            if (currentHealth <= 0)
            {
                EnemyDeath();
            }
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}

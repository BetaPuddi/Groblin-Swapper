using Character;
using Enums;
using Managers;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy : CharacterBase
    {
        public void EnemyIntroduction()
        {
            LogManager.instance.InstantiateTextLog($"Enemy {characterName} appears!");
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

        public override void Reset()
        {
            currentHealth = maxHealth;
            EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public void EnemyDeath()
        {
            print("Enemy dead");
            Reset();
            LogManager.instance.InstantiateTextLog($"{characterName} is defeated!");
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
            bonusDefense += amount;
            UpdateTotalStats();
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public void ChangeAttack(int amount)
        {
            bonusAttack += amount;
            UpdateTotalStats();
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public void ChangeMaxHealth(int amount)
        {
            bonusMaxHealth += amount;
            if (currentHealth > maxHealth)
            {
                maxHealth = currentHealth;
            }

            if (currentHealth <= 0)
            {
                EnemyDeath();
            }
            UpdateTotalStats();
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}

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

        // public void TakeDamage(float damage)
        // {
        //     currentHealth -= Mathf.RoundToInt(Mathf.Clamp(damage, 0, Mathf.Infinity));
        //     if (currentHealth <= 0)
        //     {
        //         Death();
        //     }
        //     UpdateCharacterUI();
        // }

        public override void UpdateCharacterUI()
        {
            EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public override void Death()
        {
            print("Enemy dead");
            Reset();
            LogManager.instance.InstantiateTextLog($"{characterName} is defeated!");
            GameManager.instance.UpdateGameState(3);
        }

        public virtual void Heal(float heal)
        {
            currentHealth += Mathf.RoundToInt(heal);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            UpdateCharacterUI();
        }

        public override void Reset()
        {
            currentHealth = maxHealth;
            UpdateCharacterUI();
        }

        public virtual void EnemyTakeTurn()
        {
            var actionRoll = Random.Range(0, currentSkills.Count);
            currentSkills[actionRoll].SetTarget(this, PlayerManager.instance.playerCharacter);
            currentSkills[actionRoll].UseSkill();
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
                Death();
            }
            UpdateTotalStats();
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}

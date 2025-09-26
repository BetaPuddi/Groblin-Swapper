using Character;
using Managers;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerCharacter : CharacterBase
    {
        public virtual void Attack()
        {
            print("Player attack");
        }

        public virtual void UtilitySkill_01()
        {
            print("Player skill 01");
        }

        public virtual void ItemSkill_01()
        {

        }

        // public virtual void TakeDamage(float damage)
        // {
        //     currentHealth -= Mathf.RoundToInt(Mathf.Clamp(damage, 0, Mathf.Infinity));
        //     if (currentHealth <= 0)
        //     {
        //         Death();
        //     }
        //
        //     UpdateCharacterUI();
        // }

        public override void UpdateCharacterUI()
        {
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public override void Death()
        {
            print("Player dead");
            GameManager.instance.UpdateGameState(4);
            Reset();
        }

        public virtual void Heal(float heal)
        {
            currentHealth += Mathf.RoundToInt(Mathf.Clamp(heal, 0, Mathf.Infinity));
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
    }
}

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

        public override void Reset()
        {
            currentHealth = maxHealth;
            UpdateCharacterUI();
        }
    }
}

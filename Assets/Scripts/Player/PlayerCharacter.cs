using Character;
using Managers;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerCharacter : CharacterBase
    {
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

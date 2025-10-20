using Character;
using Encounters;
using Enums;
using Managers;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy : CharacterBase
    {
        public override void UpdateCharacterUI()
        {
            EnemyInfoPanel.instance.UpdateEnemyInfo();
            EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public override void Death()
        {
            print("Enemy dead");
            Reset();
            LogManager.instance.InstantiateTextLog($"{characterName} is defeated!");
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                DungeonManager.instance.RoomEncounterCleared();
            }
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
            AnnounceAction(currentSkills[actionRoll].skillName);
            currentSkills[actionRoll].UseSkill();
        }
    }
}

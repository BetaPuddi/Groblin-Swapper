using Managers;
using UI;

namespace Player
{
    public class PlayerHauntedTofu : PlayerCharacter
    {
        public override void Attack()
        {
            var damageOut = currentHealth * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100 * 0.2f;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            var missingHealth = maxHealth - currentHealth;
            var damageOut = missingHealth * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100 * 0.1f;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            LogManager.instance.InstantiateTextLog("You lose 2 Defense!");
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            defenseStat -= 2;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }
    }
}
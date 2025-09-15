using Managers;
using UI;
using UnityEngine;

namespace Character
{
    public class PlayerHauntedTofu : Player
    {
        public override void Attack()
        {
            var damageOut = currentHealth * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100 * 0.2f;
            LogManager.instance.InstantiateDamageLog(playerName, EnemyManager.instance.targetEnemy.enemyName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            var missingHealth = maxHealth - currentHealth;
            var damageOut = missingHealth * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100 * 0.1f;
            LogManager.instance.InstantiateDamageLog(playerName, EnemyManager.instance.targetEnemy.enemyName, damageOut);
            LogManager.instance.InstantiateTextLog("You lose 2 Defense!");
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            defenseStat -= 2;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }
    }
}
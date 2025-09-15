using Managers;
using UI;
using UnityEngine;

namespace Enemies
{
    public class EnemyHauntedTofu : Enemy
    {
        public override void Attack()
        {
            var damageOut = currentHealth * (100 - PlayerManager.instance.player.defenseStat) / 100 * 0.2f;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(enemyName, PlayerManager.instance.player.playerName, damageOut);
        }

        public override void Skill_01()
        {
            var missingHealth = maxHealth - currentHealth;
            var damageOut = missingHealth * (100 - PlayerManager.instance.player.defenseStat) / 100 * 0.1f;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(enemyName, PlayerManager.instance.player.playerName, damageOut);
            defenseStat -= 2;
            LogManager.instance.InstantiateTextLog($"{enemyName} loses 2 Defense!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
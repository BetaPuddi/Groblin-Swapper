using Managers;
using UnityEngine;

namespace Character
{
    public class PlayerSkelebob : Player
    {
        public override void Attack()
        {
            var damageOut = 2 + Mathf.Clamp(attackStat * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100, 0, Mathf.Infinity);
            LogManager.instance.InstantiateDamageLog(playerName, EnemyManager.instance.targetEnemy.enemyName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            var damageOut = attackStat / 3;
            LogManager.instance.InstantiateDamageLog(playerName, EnemyManager.instance.targetEnemy.enemyName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }
    }
}
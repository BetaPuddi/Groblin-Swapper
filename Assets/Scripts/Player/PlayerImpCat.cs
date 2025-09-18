using Managers;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerImpCat : Player
    {
        public override void Attack()
        {
            var damageOut = (attackStat + Random.Range(-3, 3)) * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            var atkStat = attackStat;
            var defStat = defenseStat;
            attackStat = defStat;
            defenseStat = atkStat;
            LogManager.instance.InstantiateTextLog($"You swapped your stats!");
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public override void UtilitySkill_01()
        {
            var damageOut = (defenseStat + Random.Range(-3, 3)) * (100 - EnemyManager.instance.targetEnemy.attackStat) / 100;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            var atkStat = attackStat;
            var defStat = defenseStat;
            defenseStat = atkStat;
            attackStat = defStat;
            LogManager.instance.InstantiateTextLog($"You swapped your stats!");
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }
    }
}
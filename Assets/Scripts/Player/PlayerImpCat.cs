using Managers;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerImpCat : PlayerCharacter
    {
        public virtual void Attack()
        {
            var damageOut = (strengthStat + Random.Range(-3, 3)) * (100 - EnemyManager.instance.targetEnemy.enduranceStat) / 100;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            var atkStat = strengthStat;
            var defStat = enduranceStat;
            strengthStat = defStat;
            enduranceStat = atkStat;
            LogManager.instance.InstantiateTextLog($"You swapped your stats!");
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public virtual void UtilitySkill_01()
        {
            var damageOut = (enduranceStat + Random.Range(-3, 3)) * (100 - EnemyManager.instance.targetEnemy.strengthStat) / 100;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            var atkStat = strengthStat;
            var defStat = enduranceStat;
            enduranceStat = atkStat;
            strengthStat = defStat;
            LogManager.instance.InstantiateTextLog($"You swapped your stats!");
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }
    }
}
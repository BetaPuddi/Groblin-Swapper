using Managers;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerImpCat : PlayerCharacter
    {
        public virtual void Attack()
        {
            var damageOut = (strengthStat + Random.Range(-3, 3)) * (100 - EnemyManager.instance.targetEnemy.defenceStat) / 100;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            var atkStat = strengthStat;
            var defStat = defenceStat;
            strengthStat = defStat;
            defenceStat = atkStat;
            LogManager.instance.InstantiateTextLog($"You swapped your stats!");
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public virtual void UtilitySkill_01()
        {
            var damageOut = (defenceStat + Random.Range(-3, 3)) * (100 - EnemyManager.instance.targetEnemy.strengthStat) / 100;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            var atkStat = strengthStat;
            var defStat = defenceStat;
            defenceStat = atkStat;
            strengthStat = defStat;
            LogManager.instance.InstantiateTextLog($"You swapped your stats!");
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }
    }
}
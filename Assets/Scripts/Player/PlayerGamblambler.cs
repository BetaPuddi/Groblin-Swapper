using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerGamblambler : Player
    {
        public override void Attack()
        {
            var damageOut = attackStat + EnemyManager.instance.targetEnemy.attackStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    damageOut *= (100 - defenseStat) / 100;
                    LogManager.instance.InstantiateDamageLog(characterName, "itself", damageOut);
                    TakeDamage(damageOut);
                    break;
                case 1:
                    damageOut *= (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100;
                    LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
                    EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
                    break;
            }
        }

        public override void UtilitySkill_01()
        {
            var healOut = defenseStat + EnemyManager.instance.targetEnemy.defenseStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    healOut -= attackStat;
                    LogManager.instance.InstantiateHealLog(characterName, "itself", healOut);
                    Heal(healOut);
                    break;
                case 1:
                    healOut -= EnemyManager.instance.targetEnemy.attackStat;
                    LogManager.instance.InstantiateHealLog(characterName, EnemyManager.instance.targetEnemy.characterName, healOut);
                    EnemyManager.instance.targetEnemy.Heal(healOut);
                    break;
            }
        }
    }
}
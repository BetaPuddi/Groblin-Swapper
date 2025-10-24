using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerGamblambler : PlayerCharacter
    {
        public virtual void Attack()
        {
            var damageOut = strengthStat + EnemyManager.instance.targetEnemy.strengthStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    damageOut *= (100 - defenceStat) / 100;
                    LogManager.instance.InstantiateDamageLog(characterName, "itself", damageOut);
                    TakeDamage(damageOut);
                    break;
                case 1:
                    damageOut *= (100 - EnemyManager.instance.targetEnemy.defenceStat) / 100;
                    LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
                    EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
                    break;
            }
        }

        public virtual void UtilitySkill_01()
        {
            var healOut = defenceStat + EnemyManager.instance.targetEnemy.defenceStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    healOut -= strengthStat;
                    LogManager.instance.InstantiateHealLog(characterName, "itself", healOut);
                    Heal(healOut);
                    break;
                case 1:
                    healOut -= EnemyManager.instance.targetEnemy.strengthStat;
                    LogManager.instance.InstantiateHealLog(characterName, EnemyManager.instance.targetEnemy.characterName, healOut);
                    EnemyManager.instance.targetEnemy.Heal(healOut);
                    break;
            }
        }
    }
}
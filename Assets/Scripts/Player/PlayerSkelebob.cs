using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerSkelebob : PlayerCharacter
    {
        public virtual void Attack()
        {
            var damageOut = 2 + Mathf.Clamp(strengthStat * (100 - EnemyManager.instance.targetEnemy.enduranceStat) / 100, 0, Mathf.Infinity);
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public virtual void UtilitySkill_01()
        {
            var damageOut = strengthStat / 3;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }
    }
}
using Managers;

namespace Player
{
    public class PlayerBatface : PlayerCharacter
    {
        public virtual void Attack()
        {
            LogManager.instance.InstantiateDamageLog("You", EnemyManager.instance.targetEnemy.characterName, strengthStat);
            EnemyManager.instance.targetEnemy.TakeDamage(strengthStat);
        }

        public virtual void UtilitySkill_01()
        {
            var damageOut = strengthStat * 0.5f;
            var skillHeal = (enduranceStat * 0.2f) + (currentHealth * 0.02f);
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            LogManager.instance.InstantiateHealLog("You", "yourself", skillHeal);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            Heal(skillHeal);
        }
    }
}
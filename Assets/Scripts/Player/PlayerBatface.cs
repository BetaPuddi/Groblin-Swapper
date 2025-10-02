using Managers;

namespace Player
{
    public class PlayerBatface : PlayerCharacter
    {
        public virtual void Attack()
        {
            LogManager.instance.InstantiateDamageLog("You", EnemyManager.instance.targetEnemy.characterName, attackStat);
            EnemyManager.instance.targetEnemy.TakeDamage(attackStat);
        }

        public virtual void UtilitySkill_01()
        {
            var damageOut = attackStat * 0.5f;
            var skillHeal = (defenceStat * 0.2f) + (currentHealth * 0.02f);
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            LogManager.instance.InstantiateHealLog("You", "yourself", skillHeal);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            Heal(skillHeal);
        }
    }
}
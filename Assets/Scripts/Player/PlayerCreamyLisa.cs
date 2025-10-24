using Managers;

namespace Player
{
    public class PlayerCreamyLisa : PlayerCharacter
    {
        public virtual void Attack()
        {
            var damageOut = currentHealth * 0.2f;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            LogManager.instance.InstantiateDamageLog("You", "yourself", damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            TakeDamage(damageOut);
        }

        public virtual void UtilitySkill_01()
        {
            float damageOut;
            if (currentHealth < maxHealth * 0.2f)
            {
                damageOut = strengthStat * 2;
            }
            else
            {
                damageOut = strengthStat * (100 - EnemyManager.instance.targetEnemy.defenceStat) / 100;
            }
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }
    }
}
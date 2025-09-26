using Managers;

namespace Player
{
    public class PlayerCreamyLisa : PlayerCharacter
    {
        public override void Attack()
        {
            var damageOut = currentHealth * 0.2f;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            LogManager.instance.InstantiateDamageLog("You", "yourself", damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
            TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            float damageOut;
            if (currentHealth < maxHealth * 0.2f)
            {
                damageOut = attackStat * 2;
            }
            else
            {
                damageOut = attackStat * (100 - EnemyManager.instance.targetEnemy.defenseStat) / 100;
            }
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }
    }
}
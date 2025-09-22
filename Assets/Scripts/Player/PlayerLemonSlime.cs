using Managers;

namespace Player
{
    public class PlayerLemonSlime : PlayerCharacter
    {
        public override void Attack()
        {
            var damageOut = attackStat * ((100 - EnemyManager.instance.targetEnemy.defenseStat) / 100) * 1.5f;
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, attackStat);
            LogManager.instance.InstantiateTextLog($"You reduce {EnemyManager.instance.targetEnemy.characterName}'s Defense by 1!");
            EnemyManager.instance.targetEnemy.TakeDamage(attackStat);
            EnemyManager.instance.targetEnemy.ChangeDefense(-1);
        }
    }
}
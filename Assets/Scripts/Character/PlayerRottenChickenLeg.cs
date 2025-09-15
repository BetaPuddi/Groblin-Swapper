using Managers;
using UnityEngine;

namespace Character
{
    public class PlayerRottenChickenLeg : Player
    {
        public override void Attack()
        {
            var damageOut = attackStat - Random.Range(3, 9);
            LogManager.instance.InstantiateDamageLog(playerName, EnemyManager.instance.targetEnemy.enemyName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            EnemyManager.instance.targetEnemy.ChangeAttack(-1);
            LogManager.instance.InstantiateTextLog($"You reduce {EnemyManager.instance.targetEnemy.enemyName}'s Attack by 1!");
            EnemyManager.instance.targetEnemy.ChangeMaxHealth(-1);
            LogManager.instance.InstantiateTextLog($"You reduce {EnemyManager.instance.targetEnemy.enemyName}'s MaxHealth by 1!");
        }
    }
}
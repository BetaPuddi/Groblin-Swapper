using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerRottenChickenLeg : PlayerCharacter
    {
        public override void Attack()
        {
            var damageOut = attackStat - Random.Range(3, 9);
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            EnemyManager.instance.targetEnemy.ChangeAttack(-1);
            LogManager.instance.InstantiateTextLog($"You reduce {EnemyManager.instance.targetEnemy.characterName}'s Attack by 1!");
            EnemyManager.instance.targetEnemy.ChangeMaxHealth(-1);
            LogManager.instance.InstantiateTextLog($"You reduce {EnemyManager.instance.targetEnemy.characterName}'s MaxHealth by 1!");
        }
    }
}
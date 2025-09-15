using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyBatface : Enemy
    {
        public override void Attack()
        {
            print("Bat Attack");
            PlayerManager.instance.PlayerTakeDamage(attackStat);
            LogManager.instance.InstantiateDamageLog(enemyName, PlayerManager.instance.player.playerName, attackStat);
        }

        public override void Skill_01()
        {
            print("Bat Skill 01");
            var skillDamage = attackStat * 0.5f;
            PlayerManager.instance.PlayerTakeDamage(skillDamage);
            LogManager.instance.InstantiateDamageLog(enemyName, PlayerManager.instance.player.playerName, skillDamage);
            var skillHeal = (defenseStat * 0.2f) + (currentHealth * 0.02f);
            Heal(skillHeal);
            LogManager.instance.InstantiateHealLog(enemyName, "itself", skillHeal);
        }

        public override void Skill_02()
        {
            print("Bat Skill 02");
        }
    }
}

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
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, attackStat);
        }

        public override void Skill_01()
        {
            print("Bat Skill 01");
            var skillDamage = attackStat * 0.5f;
            PlayerManager.instance.PlayerTakeDamage(skillDamage);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, skillDamage);
            var skillHeal = (defenseStat * 0.2f) + (currentHealth * 0.02f);
            Heal(skillHeal);
            LogManager.instance.InstantiateHealLog(characterName, "itself", skillHeal);
        }

        public override void Skill_02()
        {
            print("Bat Skill 02");
        }
    }
}

using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemySkelebob : Enemy
    {
        public override void Attack()
        {
            print("Skeleton Attack");
            var damageOut = 2 + Mathf.Clamp(attackStat * (100f - PlayerManager.instance.playerCharacter.defenseStat) / 100, 0, Mathf.Infinity);
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
        }

        public override void Skill_01()
        {
            print("Skeleton Skill 01");
            var damageOut = attackStat / 3;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
        }

        public override void Skill_02()
        {
            print("Skeleton Skill 02");
        }
    }
}
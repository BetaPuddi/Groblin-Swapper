using Character;
using Managers;
using UnityEngine;

namespace Skills
{
    public class BoneToss : Skill
    {
        public override void UseSkill()
        {
            //SetTarget();
            print("Skeleton Attack");
            var user = selfTarget;
            var damageOut = 2 + Mathf.Clamp(user.attackStat * (100f - PlayerManager.instance.playerCharacter.defenseStat) / 100, 0, Mathf.Infinity);
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            //LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.player.playerName, damageOut);
        }
    }
}
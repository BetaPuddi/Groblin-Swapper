using Managers;
using Player;
using UnityEngine;

namespace Skills
{
    public class BoneToss : Skill
    {
        public override void UseSkill()
        {
            print("Skeleton Attack");
            var user = gameObject.GetComponentInParent<PlayerCharacter>();
            var damageOut = 2 + Mathf.Clamp(user.attackStat * (100f - PlayerManager.instance.playerCharacter.defenseStat) / 100, 0, Mathf.Infinity);
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            //LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.player.playerName, damageOut);
        }
    }
}
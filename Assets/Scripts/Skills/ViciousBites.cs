using Managers;
using UnityEngine;

namespace Skills
{
    public class ViciousBites : Skill
    {
        public override void UseSkill()
        {
            print("Skeleton Skill 01");
            var damageOut = user.attackStat / 3;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
        }
    }
}
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
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
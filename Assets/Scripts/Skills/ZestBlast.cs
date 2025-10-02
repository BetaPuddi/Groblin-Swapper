using Managers;
using UnityEngine;

namespace Skills
{
    public class ZestBlast : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.attackStat * ((100f - opponentTarget.defenceStat) / 100) * 1.5f;
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
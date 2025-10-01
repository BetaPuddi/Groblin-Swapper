using Managers;
using UnityEngine;

namespace Skills
{
    public class SoySlicer : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.currentHealth * (100 - opponentTarget.defenceStat) / 100 * 0.2f;
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
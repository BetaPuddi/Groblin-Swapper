using Managers;
using UnityEngine;
using Utilities;

namespace Skills
{
    public class SoySlicer : Skill
    {
        public override void UseSkill()
        {
            var damageOut = BasicDamageCalculations.BasicCurrentHealthDamageCalculation(user.currentHealth, opponentTarget, 0.2f, false);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
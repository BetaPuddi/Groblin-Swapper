using Managers;
using UnityEngine;
using Utilities;

namespace Skills
{
    public class ViciousBites : Skill
    {
        public override void UseSkill()
        {
            print("Skeleton Skill 01");
            var damageOut = BasicDamageCalculations.BasicStatBasedDamageCalculation(user.strengthStat / 3, null, 0f, true);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
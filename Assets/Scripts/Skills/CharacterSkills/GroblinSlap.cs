using Managers;
using UnityEngine;
using Utilities;

namespace Skills
{
    public class GroblinSlap : Skill
    {
        public override void UseSkill()
        {
            print("Groblin attack!");
            var damageOut = BasicDamageCalculations.BasicStatBasedDamageCalculation(user.strengthStat, null, Random.Range(-3, 4), true);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            opponentTarget.TakeDamage(damageOut);
        }
    }
}
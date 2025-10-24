using Managers;
using UnityEngine;

namespace Skills
{
    public class WingSlap : Skill
    {
        public override void UseSkill()
        {
            print("Bat Attack");
            var damageOut = user.strengthStat;
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
using Managers;
using UnityEngine;

namespace Skills
{
    public class Gambablam : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.strengthStat + opponentTarget.strengthStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    print(damageOut);
                    damageOut *= (100 - user.defenceStat) / 100;
                    print(damageOut);
                    user.TakeDamage(damageOut);
                    LogManager.instance.InstantiateDamageLog(user.characterName, "itself", damageOut);
                    break;
                case 1:
                    damageOut *= (100 - opponentTarget.defenceStat) / 100;
                    print(damageOut);
                    opponentTarget.TakeDamage(damageOut);
                    LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
                    break;
            }
        }
    }
}
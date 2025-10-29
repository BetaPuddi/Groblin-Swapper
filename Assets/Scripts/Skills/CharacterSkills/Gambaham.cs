using Managers;
using UnityEngine;

namespace Skills
{
    public class Gambaham : Skill
    {
        public override void UseSkill()
        {
            var healOut = user.defenceStat + opponentTarget.defenceStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    healOut -= user.strengthStat;
                    user.Heal(healOut);
                    LogManager.instance.InstantiateHealLog(user.characterName, "itself", healOut);
                    break;
                case 1:
                    healOut -= opponentTarget.strengthStat;
                    opponentTarget.Heal(healOut);
                    LogManager.instance.InstantiateHealLog(user.characterName, opponentTarget.characterName, healOut);
                    break;
            }
        }
    }
}
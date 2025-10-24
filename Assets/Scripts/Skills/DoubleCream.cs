using Managers;
using UnityEngine;

namespace Skills
{
    public class DoubleCream : Skill
    {
        public override void UseSkill()
        {
            float damageOut;
            if (user.currentHealth < user.maxHealth * 0.2f)
            {
                damageOut = user.strengthStat * 2;
            }
            else
            {
                damageOut = user.strengthStat * (100 - opponentTarget.defenceStat) / 100;
            }
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
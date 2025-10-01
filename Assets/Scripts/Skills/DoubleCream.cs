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
                damageOut = user.attackStat * 2;
            }
            else
            {
                damageOut = user.attackStat * (100 - opponentTarget.defenceStat) / 100;
            }
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
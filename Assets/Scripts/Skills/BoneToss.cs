using Character;
using Managers;
using UnityEngine;

namespace Skills
{
    public class BoneToss : Skill
    {
        public override void UseSkill()
        {
            //SetTarget();
            print("Bone Toss");
            var damageOut = 2 + Mathf.Clamp(user.attackStat * (100f - opponentTarget.defenseStat) / 100, 0, Mathf.Infinity);
            user.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
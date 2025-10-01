using Managers;
using UnityEngine;

namespace Skills
{
    public class GroblinSlap : Skill
    {
        public override void UseSkill()
        {
            print("Groblin attack!");
            var damageOut = user.attackStat - Random.Range(-3, 4);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            opponentTarget.TakeDamage(damageOut);
        }
    }
}
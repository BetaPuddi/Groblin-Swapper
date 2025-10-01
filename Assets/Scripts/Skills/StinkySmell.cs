using Managers;
using UnityEngine;

namespace Skills
{
    public class StinkySmell : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.attackStat - Random.Range(3, 9);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
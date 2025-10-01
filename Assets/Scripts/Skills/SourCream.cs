using Managers;
using UnityEngine;

namespace Skills
{
    public class SourCream : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.currentHealth * 0.2f;
            opponentTarget.TakeDamage(damageOut);
            user.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, "itself", damageOut);
        }
    }
}
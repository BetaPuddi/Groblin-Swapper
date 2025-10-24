using Managers;
using UnityEngine;

namespace Skills
{
    public class RancidTaste : Skill
    {
        public override void UseSkill()
        {
            opponentTarget.AdjustBonusStrength(-1);
            LogManager.instance.InstantiateTextLog($"{user.characterName} reduces your Attack by 1!");
            opponentTarget.AdjustBonusMaxHealth(-5);
            LogManager.instance.InstantiateTextLog($"{user.characterName} reduces your MaxHealth by 1!");
        }
    }
}
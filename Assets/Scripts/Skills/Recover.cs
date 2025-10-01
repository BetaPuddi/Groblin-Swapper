using Managers;
using UnityEngine;

namespace Skills
{
    public class Recover : Skill
    {
        public override void UseSkill()
        {
            print("Groblin utility skill");
            var healOut = user.defenceStat - Random.Range(-3, 4);
            LogManager.instance.InstantiateHealLog(user.characterName, "itself", healOut);
            user.Heal(healOut);
        }
    }
}
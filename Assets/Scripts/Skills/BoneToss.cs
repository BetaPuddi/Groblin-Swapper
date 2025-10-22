using Managers;
using Utilities;

namespace Skills
{
    public class BoneToss : Skill
    {
        public override void UseSkill()
        {
            print("Bone Toss");
            var damageOut = BasicDamageCalculations.BasicStatBasedDamageCalculation(user.attackStat, opponentTarget, 2f, false);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
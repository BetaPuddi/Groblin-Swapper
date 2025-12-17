using Managers;
using TemporaryEffects;
using Utilities;

namespace Skills
{
    public class BoneToss : Skill
    {
        public TemporaryEnduranceEffect buff;

        public override void UseSkill()
        {
            print("Bone Toss");
            var damageOut = BasicDamageCalculations.BasicStatBasedDamageCalculation(user.strengthStat, opponentTarget, 2f, false);
            opponentTarget.TakeDamage(damageOut);
            var newBuff = Instantiate(buff);
            newBuff.AdjustValue(4);
            newBuff.AdjustTurns(2);
            user.GetComponent<TemporaryEffectHandler>().AddTemporaryEffect(buff);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
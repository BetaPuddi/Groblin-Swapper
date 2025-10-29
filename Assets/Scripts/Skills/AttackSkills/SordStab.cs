using Managers;
using Utilities;

namespace Skills
{
    public class SordStab : Skill
    {
        public override void UseSkill()
        {
            var damageOut = BasicDamageCalculations.BasicDamageCalculation(opponentTarget,
                user.weaponContainer.currentWeaponAttackStat, true);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
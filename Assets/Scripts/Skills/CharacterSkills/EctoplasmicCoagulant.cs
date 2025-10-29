using Managers;
using Utilities;

namespace Skills
{
    public class EctoplasmicCoagulant : Skill
    {
        public override void UseSkill()
        {
            var missingHealth = user.maxHealth - user.currentHealth;
            var damageOut = BasicDamageCalculations.BasicHealthDamageCalculation(missingHealth, opponentTarget, 0.1f, false);
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            user.AdjustBonusDefence(-2);
            LogManager.instance.InstantiateTextLog($"{user.characterName} loses 2 Defence!");
            user.UpdateCharacterUI();
        }
    }
}
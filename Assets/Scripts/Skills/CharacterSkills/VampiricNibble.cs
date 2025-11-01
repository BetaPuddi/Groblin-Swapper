using Managers;

namespace Skills
{
    public class VampiricNibble : Skill
    {
        public override void UseSkill()
        {
            print("Bat Skill 01");
            var damageOut = user.strengthStat * 0.5f;
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            var skillHeal = (user.enduranceStat * 0.2f) + (user.currentHealth * 0.02f);
            user.Heal(skillHeal);
            LogManager.instance.InstantiateHealLog(user.characterName, "itself", skillHeal);
        }
    }
}
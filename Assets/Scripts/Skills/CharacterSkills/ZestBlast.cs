using Managers;

namespace Skills
{
    public class ZestBlast : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.strengthStat * ((100f - opponentTarget.enduranceStat) / 100) * 1.5f;
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
        }
    }
}
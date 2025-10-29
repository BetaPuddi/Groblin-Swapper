using Managers;

namespace Skills
{
    public class CitricAcid : Skill
    {
        public override void UseSkill()
        {
            var damageOut = user.strengthStat;
            user.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            opponentTarget.AdjustBonusDefence(-1);
            LogManager.instance.InstantiateTextLog($"{user.characterName} reduces {opponentTarget.characterName}'s Defense by 1!");
            opponentTarget.UpdateCharacterUI();
        }
    }
}
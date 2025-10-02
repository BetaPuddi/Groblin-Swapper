using Managers;
using UI;
using UnityEngine;

namespace Skills
{
    public class EctoplasmicCoagulant : Skill
    {
        public override void UseSkill()
        {
            var missingHealth = user.maxHealth - user.currentHealth;
            var damageOut = missingHealth * (100 - PlayerManager.instance.playerCharacter.defenceStat) / 100 * 0.1f;
            opponentTarget.TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            user.AdjustBonusDefence(-2);
            LogManager.instance.InstantiateTextLog($"{user.characterName} loses 2 Defense!");
            user.UpdateCharacterUI();
        }
    }
}
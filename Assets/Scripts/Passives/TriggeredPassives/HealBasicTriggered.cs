using Character;
using Managers;
using UnityEngine;

namespace Passives.TriggeredPassives
{
    public class HealBasicTriggered : PassiveBase
    {
        public override void TriggerEffect(CharacterBase user, CharacterBase opponent)
        {
            user.Heal(5f);
            LogManager.instance.InstantiateHealLog(user.characterName, user.characterName, 5f);
        }
    }
}
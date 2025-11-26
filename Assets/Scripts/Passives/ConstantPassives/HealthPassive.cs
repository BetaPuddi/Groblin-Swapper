using Character;
using UnityEngine;

namespace Passives.ConstantPassives
{
    public class HealthPassive : PassiveBase
    {
        [SerializeField] private float healthValue;

        public override void ApplyConstantEffect(CharacterBase user)
        {
            user.AdjustBonusMaxHealth(healthValue);
        }

        public override void RemoveConstantEffect(CharacterBase user)
        {
            user.AdjustBonusMaxHealth(-healthValue);
        }
    }
}
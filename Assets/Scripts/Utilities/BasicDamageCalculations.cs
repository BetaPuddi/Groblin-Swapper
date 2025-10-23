using Character;
using UnityEngine;

namespace Utilities
{
    public static class BasicDamageCalculations
    {
        public static float BasicDamageCalculation(CharacterBase target, float baseDamage, bool isPiercing)
        {
            if (!isPiercing)
            {
                var damageOut = Mathf.Clamp(baseDamage * (100f - target.defenceStat) / 100, 0, Mathf.Infinity);
                return damageOut;
            }
            else
            {
                var damageOut = Mathf.Clamp(baseDamage * (100f - 0) / 100, 0, Mathf.Infinity);
                return damageOut;
            }
        }

        public static float BasicStatBasedDamageCalculation(float damageStat, CharacterBase target, float baseDamage, bool isPiercing)
        {
            if (!isPiercing)
            {
                var damageOut = baseDamage + Mathf.Clamp(damageStat * (100f - target.defenceStat) / 100, 0, Mathf.Infinity);
                return damageOut;
            }
            else
            {
                var damageOut = baseDamage + Mathf.Clamp(damageStat * (100f - 0) / 100, 0, Mathf.Infinity);
                return damageOut;
            }
        }

        public static float BasicHealthDamageCalculation(float healthValue, CharacterBase target, float modifier, bool isPiercing)
        {
            if (!isPiercing)
            {
                var damageOut = healthValue * Mathf.Clamp((100 - target.defenceStat) / 100 * modifier, 0, Mathf.Infinity);
                return damageOut;
            }
            else
            {
                var damageOut = healthValue * Mathf.Clamp((100 - 0) / 100 * modifier, 0, Mathf.Infinity);
                return damageOut;
            }
        }

    }
}
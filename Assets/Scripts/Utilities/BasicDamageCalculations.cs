using Character;
using UnityEngine;

namespace Utilities
{
    public static class BasicDamageCalculations
    {
        public static float BasicDamageCalculation(CharacterBase target, float baseDamage)
        {
            var damageOut = Mathf.Clamp(baseDamage * (100f - target.defenceStat) / 100, 0, Mathf.Infinity);
            return damageOut;
        }

        public static float BasicPiercingDamageCalculation(float baseDamage)
        {
            var damageOut = Mathf.Clamp(baseDamage * (100f - 0) / 100, 0, Mathf.Infinity);
            return damageOut;
        }

        public static float BasicPiercingStatBasedDamageCalculation(float damageStat, float baseDamage)
        {
            var damageOut = baseDamage + Mathf.Clamp(damageStat * (100f - 0) / 100, 0, Mathf.Infinity);
            return damageOut;
        }

        public static float BasicStatBasedDamageCalculation(float damageStat, CharacterBase target, float baseDamage)
        {
            var damageOut = baseDamage + Mathf.Clamp(damageStat * (100f - target.defenceStat) / 100, 0, Mathf.Infinity);
            return damageOut;
        }
    }
}
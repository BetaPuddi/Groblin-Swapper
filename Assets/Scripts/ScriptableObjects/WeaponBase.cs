using Skills;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Equipment/New Weapon", order = 0)]
    public class WeaponBase : ScriptableObject
    {
        public string weaponName;
        public float weaponAttackStat;
        public Skill weaponAttackSkill;
    }
}
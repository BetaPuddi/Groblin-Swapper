using System;
using ScriptableObjects;
using Skills;
using UnityEngine;

namespace Weapons
{
    public class WeaponContainer : MonoBehaviour
    {
        public WeaponBase currentWeapon;

        public string currentWeaponName;
        public int currentWeaponAttackStat;
        public Skill currentWeaponAttackSkill;

        private void Start()
        {
            AssignCurrentAttackSkill();
        }

        public void AssignCurrentAttackSkill()
        {
            currentWeaponAttackSkill = currentWeapon.weaponAttackSkill;
        }

        public virtual void UseAttackSkill()
        {
            currentWeaponAttackSkill.UseSkill();
        }
    }
}
using System;
using Equipment;
using ScriptableObjects;
using Skills;
using UnityEngine;

namespace Weapons
{
    public class WeaponContainer : MonoBehaviour
    {
        public WeaponBase currentWeapon;

        public string currentWeaponName;
        public float currentWeaponAttackStat;
        public Skill currentWeaponAttackSkill;

        private void Start()
        {
            UpdateWeaponContainer();
        }

        public void UpdateWeaponContainer()
        {
            AssignCurrentAttackSkill();
            AssignCurrentWeaponName();
            AssignCurrentWeaponAttackStat();
        }

        public void AssignCurrentAttackSkill()
        {
            currentWeaponAttackSkill = currentWeapon.weaponAttackSkill;
        }

        public void AssignCurrentWeaponName()
        {
            currentWeaponName = currentWeapon.weaponName;
        }

        public void AssignCurrentWeaponAttackStat()
        {
            currentWeaponAttackStat = currentWeapon.weaponAttackStat;
        }

        public virtual void UseAttackSkill()
        {
            currentWeaponAttackSkill.UseSkill();
        }
    }
}
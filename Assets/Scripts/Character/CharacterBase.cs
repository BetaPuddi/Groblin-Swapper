using System;
using System.Collections.Generic;
using Enums;
using Equipment;
using Interfaces;
using Managers;
using ScriptableObjects;
using Skills;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

namespace Character
{
    public abstract class CharacterBase : MonoBehaviour, IDamageable, IHealable
    {
        [FormerlySerializedAs("baseStats")] public CharacterBaseStats characterBase;

        public Sprite characterSprite;
        public string characterName;

        [Header("Base Stats")]
        public float baseMaxHealth;
        [FormerlySerializedAs("baseAttack")] public float baseStrength;
        [FormerlySerializedAs("baseDefence")] [FormerlySerializedAs("baseDefense")] public float baseEndurance;
        public int baseMaxItemUses;

        [Header("Bonus Stats")]
        public float bonusMaxHealth;
        [FormerlySerializedAs("bonusAttack")] public float bonusStrength;
        [FormerlySerializedAs("bonusDefence")] [FormerlySerializedAs("bonusDefense")] public float bonusEndurance;
        public int bonusMaxItemUses;

        [Header("Total Stats")]
        public float maxHealth;
        [FormerlySerializedAs("attackStat")] public float strengthStat;
        [FormerlySerializedAs("defenceStat")] [FormerlySerializedAs("defenseStat")] public float enduranceStat;
        public int maxItemUses;

        [Header("Equipment Stats")]
        public float totalEquipmentAttack;
        public float totalEquipmentDefence;

        [Header("Current Resources")]
        public float currentHealth;
        [FormerlySerializedAs("itemUses")] public int currentItemUses;

        [Header("Skills")]
        public SkillSet skills;
        public List<Skill> currentSkills;

        [Header("Equipment")]
        public WeaponContainer weaponContainer;
        public CharacterInventory characterInventory;

        private void Start()
        {
            if (GameManager.instance._gameState != EGameStates.MainMenu)
            {
                Reset();
            }
            Initialise();
        }

        public void Initialise()
        {
            SetName();
            SetSprite();
            SetBaseStats();
            UpdateTotalStats();
            ReplaceSkillset();
            Reset();
            UpdateCharacterUI();
            currentHealth = maxHealth;
            currentItemUses = maxItemUses;
        }

        private void SetSprite()
        {
            characterSprite = characterBase.icon;
        }

        public void SetName()
        {
            characterName = characterBase.characterName;
        }

        public void SetBaseStats()
        {
            baseMaxHealth = characterBase.maxHealth;
            baseStrength = characterBase.strength;
            baseEndurance = characterBase.endurance;
            baseMaxItemUses = characterBase.maxItemUses;
        }

        public void UpdateTotalStats()
        {
            maxHealth = baseMaxHealth + bonusMaxHealth;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            strengthStat = baseStrength + bonusStrength;
            if (strengthStat < 0)
            {
                strengthStat = 0;
            }
            enduranceStat = baseEndurance + bonusEndurance;
            if (enduranceStat < 0)
            {
                enduranceStat = 0;
            }
            maxItemUses = baseMaxItemUses + bonusMaxItemUses;
            if (maxItemUses < 0)
            {
                maxItemUses = 0;
            }
            UpdateCharacterUI();
        }

        public void CalculateTotalEquipmentDefence()
        {
            totalEquipmentDefence = characterInventory.armSlot.defenceValue +
                                    characterInventory.chestSlot.defenceValue +
                                    characterInventory.headSlot.defenceValue + characterInventory.legSlot.defenceValue;
        }

        public void ClearBonusStats()
        {
            bonusStrength = 0;
            bonusEndurance = 0;
            bonusMaxHealth = 0;
            bonusMaxItemUses = 0;
        }

        public void ReplaceSkillset()
        {
            currentSkills = skills.skillList;
        }

        public virtual void Reset()
        {
            currentHealth = maxHealth;
            //EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public void TakeDamage(float damageIn)
        {
            currentHealth -= Mathf.RoundToInt(Mathf.Clamp(damageIn, 0, Mathf.Infinity));
            if (currentHealth <= 0)
            {
                Death();
            }
            UpdateCharacterUI();
        }

        public abstract void UpdateCharacterUI();

        public abstract void Death();

        public void Heal(float healIn)
        {
            currentHealth += Mathf.RoundToInt(Mathf.Clamp(healIn, 0, Mathf.Infinity));
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            UpdateCharacterUI();
        }

        public void AdjustEndurance(float amount)
        {
            bonusEndurance += amount;
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AdjustBonusStrength(float amount)
        {
            bonusStrength += amount;
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AdjustBonusMaxHealth(float amount)
        {
            bonusMaxHealth += amount;
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AdjustBonusMaxItemUses(int amount)
        {
            bonusMaxItemUses += amount;
            if (currentItemUses > maxItemUses)
            {
                currentItemUses = maxItemUses;
            }
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AnnounceAction(string action)
        {
            LogManager.instance.InstantiateActionLog(characterName, action);
        }

        public void AnnounceAttack(string attack)
        {
            LogManager.instance.InstantiateAttackLog(characterName, attack);
        }
    }
}
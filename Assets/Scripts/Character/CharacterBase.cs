using System;
using System.Collections.Generic;
using Enums;
using Interfaces;
using Managers;
using ScriptableObjects;
using Skills;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public abstract class CharacterBase : MonoBehaviour, IDamageable, IHealable
    {
        [FormerlySerializedAs("baseStats")] public CharacterBaseStats characterBase;

        public Sprite characterSprite;
        public string characterName;

        [Header("Base Stats")]
        public float baseMaxHealth;
        public float baseAttack;
        [FormerlySerializedAs("baseDefense")] public float baseDefence;

        [Header("Bonus Stats")]
        public float bonusMaxHealth;
        public float bonusAttack;
        [FormerlySerializedAs("bonusDefense")] public float bonusDefence;

        [Header("Total Stats")]
        public float maxHealth;
        public float attackStat;
        [FormerlySerializedAs("defenseStat")] public float defenceStat;

        [Header("Current Resources")]
        public float currentHealth;
        public int itemUses;

        public SkillSet skills;
        public List<Skill> currentSkills;

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
            currentHealth = maxHealth;
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
            baseAttack = characterBase.attack;
            baseDefence = characterBase.defence;
        }

        public void UpdateTotalStats()
        {
            maxHealth = baseMaxHealth + bonusMaxHealth;
            attackStat = baseAttack + bonusAttack;
            defenceStat = baseDefence + bonusDefence;
        }

        public void ClearBonusStats()
        {
            bonusAttack = 0;
            bonusDefence = 0;
            bonusMaxHealth = 0;
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

        public void AdjustBonusDefence(int amount)
        {
            bonusDefence += amount;
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AdjustBonusAttack(int amount)
        {
            bonusAttack += amount;
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AdjustBonusMaxHealth(int amount)
        {
            bonusMaxHealth += amount;
            UpdateTotalStats();
            UpdateCharacterUI();
        }

        public void AnnounceAction(string action)
        {
            LogManager.instance.InstantiateActionLog(characterName, action);
        }
    }
}
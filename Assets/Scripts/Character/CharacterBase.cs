using System;
using System.Collections.Generic;
using Enums;
using Managers;
using ScriptableObjects;
using Skills;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    public abstract class CharacterBase : MonoBehaviour, IDamageable
    {
        [FormerlySerializedAs("baseStats")] public CharacterBaseStats characterBase;

        public Sprite characterSprite;
        public string characterName;

        [Header("Base Stats")]
        public float baseMaxHealth;
        public float baseAttack;
        public float baseDefense;

        [Header("Bonus Stats")]
        public float bonusMaxHealth;
        public float bonusAttack;
        public float bonusDefense;

        [Header("Total Stats")]
        public float maxHealth;
        public float attackStat;
        public float defenseStat;

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
            baseDefense = characterBase.defense;
        }

        public void UpdateTotalStats()
        {
            maxHealth = baseMaxHealth + bonusMaxHealth;
            attackStat = baseAttack + bonusAttack;
            defenseStat = baseDefense + bonusDefense;
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
    }
}
using Enums;
using Managers;
using ScriptableObjects;
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

        public float baseMaxHealth;
        public float baseAttack;
        public float baseDefense;

        public float bonusMaxHealth;
        public float bonusAttack;
        public float bonusDefense;

        public float currentHealth;
        public float maxHealth;
        public float attackStat;
        public float defenseStat;
        public int itemUses;

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
            //EnemyInfoPanel.instance.UpdateEnemyHealth(currentHealth);
        }

        public abstract void Death();
    }
}
using System;
using System.Collections.Generic;
using Enums;
using Items;
using UI;
using UnityEngine;
using Player;
using ScriptableObjects;
using Skills;
using UnityEngine.Serialization;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        [FormerlySerializedAs("player")] public PlayerCharacter playerCharacter;
        public PlayerCharacter defaultPlayerCharacter;
        public Item currentItem;

        public delegate void PlayerAttack();
        public delegate void PlayerUtility();
        public delegate void TakeDamage(float damage);
        public delegate void Heal(float heal);

        private PlayerAttack _playerAttack;
        private PlayerUtility _playerUtility;
        private TakeDamage _takeDamage;
        private Heal _heal;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            InitialisePlayer();
        }

        private void OnEnable()
        {
            UpdateMainPlayer();
        }

        private void Start()
        {
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void SwapPlayerStats(CharacterBaseStats newPlayerStats)
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                playerCharacter.characterBase = newPlayerStats;
                playerCharacter.SetBaseStats();
                playerCharacter.UpdateTotalStats();
                //UpdateMainPlayer();
                PlayerInfoPanel.instance.UpdatePlayerInfo();
                GameManager.instance.UpdateGameState(3);
            }
        }

        public void SwapPlayerSkillSet(List<Skill> newPlayerSkillSet)
        {
            playerCharacter.currentSkills = newPlayerSkillSet;
            GameManager.instance.UpdateGameState(3);
        }

        public void SwapItem(Item newItem)
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                currentItem = newItem;
                playerCharacter.itemUses = 2;
                PlayerInfoPanel.instance.UpdatePlayerInfo();
                GameManager.instance.UpdateGameState(3);
            }
        }

        public void UpdateMainPlayer()
        {
            _playerAttack = playerCharacter.Attack;
            _playerUtility = playerCharacter.UtilitySkill_01;
            _takeDamage = playerCharacter.TakeDamage;
            _heal = playerCharacter.Heal;
        }

        public void MainAttack()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                _playerAttack();
            }
        }

        public void MainUtility()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                _playerUtility();
            }
        }

        public void Item()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                if (playerCharacter.itemUses > 0)
                {
                    print("Player skill 02");
                    LogManager.instance.InstantiateTextLog(currentItem.itemUseText);
                    currentItem.UseItem();
                    playerCharacter.itemUses--;
                }
                else
                {
                    LogManager.instance.InstantiateTextLog("No uses remaining.");
                }
                PlayerInfoPanel.instance.UpdatePlayerInfo();
            }
        }

        public void PlayerTakeDamage(float damage)
        {
            _takeDamage(Mathf.RoundToInt(damage));
        }

        public void PlayerHeal(float heal)
        {
            _heal(Mathf.RoundToInt(heal));
        }

        public void ChangeDefense(int amount)
        {
            playerCharacter.defenseStat += amount;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void ChangeAttack(int amount)
        {
            playerCharacter.attackStat += amount;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void ChangeMaxHealth(int amount)
        {
            playerCharacter.maxHealth += amount;
            if (playerCharacter.currentHealth > playerCharacter.maxHealth)
            {
                playerCharacter.maxHealth = playerCharacter.currentHealth;
            }

            if (playerCharacter.currentHealth <= 0)
            {
                playerCharacter.Death();
            }
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void InitialisePlayer()
        {
            playerCharacter = defaultPlayerCharacter;
        }
    }
}
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
            //UpdateMainPlayer();
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

        }

        public void PlayerSkill01()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                playerCharacter.currentSkills[0].SetTarget(playerCharacter, EnemyManager.instance.targetEnemy);
                playerCharacter.currentSkills[0].UseSkill();
            }
        }

        public void PlayerSkill02()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                playerCharacter.currentSkills[1].SetTarget(playerCharacter, EnemyManager.instance.targetEnemy);
                playerCharacter.currentSkills[1].UseSkill();
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
            playerCharacter.TakeDamage(Mathf.RoundToInt(damage));
        }

        public void PlayerHeal(float heal)
        {
            playerCharacter.Heal(Mathf.RoundToInt(heal));
        }

        public void ChangeDefense(int amount)
        {
            playerCharacter.defenceStat += amount;
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
            playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
            playerCharacter.currentSkills = new List<Skill>(playerCharacter.skills.skillList);
        }
    }
}
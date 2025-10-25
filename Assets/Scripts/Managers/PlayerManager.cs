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
using Weapons;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        [FormerlySerializedAs("player")] public PlayerCharacter playerCharacter;
        public Item currentItem;
        public WeaponContainer weaponContainer;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            InitialisePlayer();
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
                playerCharacter.currentItemUses = playerCharacter.maxItemUses;
                PlayerInfoPanel.instance.UpdatePlayerInfo();
                GameManager.instance.UpdateGameState(3);
            }
        }

        public void PlayerSkill01()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                playerCharacter.currentSkills[0].SetTarget(playerCharacter, EnemyManager.instance.targetEnemy);
                playerCharacter.AnnounceAction(playerCharacter.currentSkills[0].skillName);
                playerCharacter.currentSkills[0].UseSkill();
            }
        }

        public void PlayerSkill02()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                playerCharacter.currentSkills[1].SetTarget(playerCharacter, EnemyManager.instance.targetEnemy);
                playerCharacter.AnnounceAction(playerCharacter.currentSkills[1].skillName);
                playerCharacter.currentSkills[1].UseSkill();
            }
        }

        public void PlayerWeaponAttack()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                playerCharacter.weaponContainer.currentWeaponAttackSkill.SetTarget(playerCharacter, EnemyManager.instance.targetEnemy);
                playerCharacter.AnnounceAction(playerCharacter.weaponContainer.currentWeaponName);
                playerCharacter.weaponContainer.UseAttackSkill();
            }
        }

        public void Item()
        {
            if (GameManager.instance._gameState == EGameStates.Combat)
            {
                if (playerCharacter.currentItemUses > 0)
                {
                    print("Player skill 02");
                    playerCharacter.AnnounceAction(currentItem.itemName);
                    LogManager.instance.InstantiateTextLog(currentItem.itemUseText);
                    currentItem.UseItem();
                    playerCharacter.currentItemUses--;
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

        public void ChangeDefence(int amount)
        {
            playerCharacter.defenceStat += amount;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void ChangeStrength(int amount)
        {
            playerCharacter.strengthStat += amount;
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
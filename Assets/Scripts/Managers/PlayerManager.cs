using System;
using Enums;
using Items;
using UI;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Player.Player player;
        public Player.Player defaultPlayer;
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

        public void SwapPlayer(Player.Player newPlayer)
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                player = newPlayer;
                UpdateMainPlayer();
                PlayerInfoPanel.instance.UpdatePlayerInfo();
                GameManager.instance.UpdateGameState(3);
            }
        }

        public void SwapItem(Item newItem)
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                currentItem = newItem;
                player.itemUses = 2;
                PlayerInfoPanel.instance.UpdatePlayerInfo();
                GameManager.instance.UpdateGameState(3);
            }
        }

        public void UpdateMainPlayer()
        {
            _playerAttack = player.Attack;
            _playerUtility = player.UtilitySkill_01;
            _takeDamage = player.TakeDamage;
            _heal = player.Heal;
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
                if (player.itemUses > 0)
                {
                    print("Player skill 02");
                    LogManager.instance.InstantiateTextLog(currentItem.itemUseText);
                    currentItem.UseItem();
                    player.itemUses--;
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
            player.defenseStat += amount;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void ChangeAttack(int amount)
        {
            player.attackStat += amount;
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void ChangeMaxHealth(int amount)
        {
            player.maxHealth += amount;
            if (player.currentHealth > player.maxHealth)
            {
                player.maxHealth = player.currentHealth;
            }

            if (player.currentHealth <= 0)
            {
                player.GameOver();
            }
            PlayerInfoPanel.instance.UpdatePlayerInfo();
        }

        public void InitialisePlayer()
        {
            player = defaultPlayer;
        }
    }
}
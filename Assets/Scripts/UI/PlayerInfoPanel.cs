using System;
using UnityEngine;
using TMPro;
using Managers;

namespace UI
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        public static PlayerInfoPanel instance;

        public Player.PlayerCharacter playerCharacterRef;
        public TextMeshProUGUI playerNameText;
        public TextMeshProUGUI playerHealthText;
        public TextMeshProUGUI playerATKText;
        public TextMeshProUGUI playerDEFText;
        public TextMeshProUGUI playerItemText;

        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            //UpdatePlayerRef();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            UpdatePlayerInfo();
        }

        public void UpdatePlayerRef()
        {
            playerCharacterRef = PlayerManager.instance.playerCharacter;
        }

        public void UpdatePlayerInfo()
        {
            UpdatePlayerRef();
            playerNameText.text = playerCharacterRef.characterName;
            playerHealthText.text = playerCharacterRef.currentHealth.ToString();
            playerATKText.text = playerCharacterRef.attackStat.ToString();
            playerDEFText.text = playerCharacterRef.defenseStat.ToString();
            playerItemText.text = playerCharacterRef.itemUses.ToString();
        }

        public void SetPlayerStats()
        {

        }
    }
}

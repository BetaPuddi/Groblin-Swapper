using System;
using UnityEngine;
using TMPro;
using Managers;

namespace UI
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        public static PlayerInfoPanel instance;

        public Player.Player playerRef;
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
            playerRef = PlayerManager.instance.player;
        }

        public void UpdatePlayerInfo()
        {
            UpdatePlayerRef();
            playerNameText.text = playerRef.characterName;
            playerHealthText.text = playerRef.currentHealth.ToString();
            playerATKText.text = playerRef.attackStat.ToString();
            playerDEFText.text = playerRef.defenseStat.ToString();
            playerItemText.text = playerRef.itemUses.ToString();
        }

        public void SetPlayerStats()
        {

        }
    }
}

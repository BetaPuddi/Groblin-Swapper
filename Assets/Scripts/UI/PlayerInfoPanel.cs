using System;
using UnityEngine;
using TMPro;
using Managers;
using Player;
using UnityEngine.Serialization;

namespace UI
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        public static PlayerInfoPanel instance;

        public PlayerCharacter playerCharacterRef;
        public TextMeshProUGUI playerNameText;
        public TextMeshProUGUI playerHealthText;
        [FormerlySerializedAs("playerATKText")] public TextMeshProUGUI playerSTRText;
        [FormerlySerializedAs("playerDEFText")] public TextMeshProUGUI playerENDText;
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
            playerSTRText.text = playerCharacterRef.strengthStat.ToString();
            playerENDText.text = playerCharacterRef.enduranceStat.ToString();
            playerItemText.text = playerCharacterRef.currentItemUses.ToString();
        }

        public void SetPlayerStats()
        {

        }
    }
}

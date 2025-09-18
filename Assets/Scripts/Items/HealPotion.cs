using Managers;
using UnityEngine;

namespace Items
{
    public class HealPotion : Item
    {
        public override void UseItem()
        {
            var currentHealth = PlayerManager.instance.playerCharacter.currentHealth;
            var maxHealth = PlayerManager.instance.playerCharacter.maxHealth;
            PlayerManager.instance.PlayerHeal(maxHealth - currentHealth);
        }
    }
}
using Managers;
using UnityEngine;

namespace Items
{
    public class HealPotion : Item
    {
        public override void UseItem()
        {
            var currentHealth = PlayerManager.instance.player.currentHealth;
            var maxHealth = PlayerManager.instance.player.maxHealth;
            PlayerManager.instance.PlayerHeal(maxHealth - currentHealth);
        }
    }
}
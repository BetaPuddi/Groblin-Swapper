using Managers;
using UnityEngine;

namespace Items
{
    public class DefensePotion : Item
    {
        public override void UseItem()
        {
            PlayerManager.instance.ChangeMaxHealth(50);
            PlayerManager.instance.PlayerHeal(50);
            PlayerManager.instance.ChangeDefense(5);
        }
    }
}
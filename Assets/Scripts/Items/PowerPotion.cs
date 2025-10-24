using Managers;
using UnityEngine;

namespace Items
{
    public class PowerPotion : Item
    {
        public override void UseItem()
        {
            PlayerManager.instance.playerCharacter.AdjustBonusStrength(10);
        }
    }
}
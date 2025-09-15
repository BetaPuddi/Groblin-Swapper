using Managers;
using UnityEngine;

namespace Items
{
    public class SmokeBomb : Item
    {
        public override void UseItem()
        {
            GameManager.instance.UpdateGameState(3);
        }
    }
}
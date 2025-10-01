using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerGroblin : PlayerCharacter
    {
        public override void Attack()
        {

        }

        public override void UtilitySkill_01()
        {

        }

        public override void ItemSkill_01()
        {
            if (itemUses > 0)
            {
                print("Groblin item skill");
                itemUses--;

            }
            else
            {
                print("No uses remaining");
            }
        }
    }
}
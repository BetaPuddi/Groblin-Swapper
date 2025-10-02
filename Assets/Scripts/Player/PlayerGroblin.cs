using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerGroblin : PlayerCharacter
    {
        public virtual void Attack()
        {

        }

        public virtual void UtilitySkill_01()
        {

        }

        public virtual void ItemSkill_01()
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
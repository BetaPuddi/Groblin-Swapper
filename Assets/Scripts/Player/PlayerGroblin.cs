using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerGroblin : Player
    {
        public override void Attack()
        {
            print("Groblin attack!");
            var damageOut = attackStat - Random.Range(-3, 4);
            LogManager.instance.InstantiateDamageLog(characterName, EnemyManager.instance.targetEnemy.characterName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            print("Groblin utility skill");
            var healOut = defenseStat - Random.Range(-3, 4);
            LogManager.instance.InstantiateHealLog(characterName, "itself", healOut);
            PlayerManager.instance.PlayerHeal(healOut);
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
using Managers;
using UnityEngine;

namespace Character
{
    public class PlayerGroblin : Player
    {
        public override void Attack()
        {
            print("Groblin attack!");
            var damageOut = attackStat - Random.Range(-3, 4);
            LogManager.instance.InstantiateDamageLog(playerName, EnemyManager.instance.targetEnemy.enemyName, damageOut);
            EnemyManager.instance.targetEnemy.TakeDamage(damageOut);
        }

        public override void UtilitySkill_01()
        {
            print("Groblin utility skill");
            var healOut = defenseStat - Random.Range(-3, 4);
            LogManager.instance.InstantiateHealLog(playerName, "itself", healOut);
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
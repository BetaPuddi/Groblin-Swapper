using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyCreamyLisa : Enemy
    {
        public override void Attack()
        {
            var damageOut = currentHealth * 0.2f;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            TakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.player.characterName, damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, "itself", damageOut);
        }

        public override void Skill_01()
        {
            float damageOut;
            if (currentHealth < maxHealth * 0.2f)
            {
                damageOut = attackStat * 2;
            }
            else
            {
                damageOut = attackStat * (100 - PlayerManager.instance.player.defenseStat) / 100;
            }
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.player.characterName, damageOut);
        }
    }
}
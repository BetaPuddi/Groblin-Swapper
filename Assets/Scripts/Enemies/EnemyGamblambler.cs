using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyGamblambler : Enemy
    {
        public override void Attack()
        {
            float damageOut = attackStat + PlayerManager.instance.playerCharacter.attackStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    print(damageOut);
                    damageOut *= (100 - defenseStat) / 100;
                    print(damageOut);
                    TakeDamage(damageOut);
                    LogManager.instance.InstantiateDamageLog(characterName, "itself", damageOut);
                    break;
                case 1:
                    damageOut *= (100 - PlayerManager.instance.playerCharacter.defenseStat) / 100;
                    print(damageOut);
                    PlayerManager.instance.PlayerTakeDamage(damageOut);
                    LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
                    break;
            }
        }

        public override void Skill_01()
        {
            var healOut = defenseStat + PlayerManager.instance.playerCharacter.defenseStat;
            var targetRoll = Random.Range(0, 2);
            switch (targetRoll)
            {
                case 0:
                    healOut -= attackStat;
                    Heal(healOut);
                    LogManager.instance.InstantiateHealLog(characterName, "itself", healOut);
                    break;
                case 1:
                    healOut -= PlayerManager.instance.playerCharacter.attackStat;
                    PlayerManager.instance.PlayerHeal(healOut);
                    LogManager.instance.InstantiateHealLog(characterName, PlayerManager.instance.playerCharacter.characterName, healOut);
                    break;
            }
        }
    }
}
using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyLemonSlime : Enemy
    {
        public override void Attack()
        {
            var damageOut = attackStat * ((100f - PlayerManager.instance.playerCharacter.defenseStat) / 100) * 1.5f;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
        }

        public override void Skill_01()
        {
            PlayerManager.instance.PlayerTakeDamage(attackStat);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, attackStat);
            PlayerManager.instance.ChangeDefense(-1);
            LogManager.instance.InstantiateTextLog($"{characterName} reduces your Defense by 1!");
        }
    }
}
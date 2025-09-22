using Managers;
using UI;
using UnityEngine;

namespace Enemies
{
    public class EnemyImpCat : Enemy
    {
        public override void Attack()
        {
            var damageOut = (attackStat + Random.Range(-3, 3)) * (100 - PlayerManager.instance.playerCharacter.defenseStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
            var atkStat = attackStat;
            var defStat = defenseStat;
            attackStat = defStat;
            defenseStat = atkStat;
            LogManager.instance.InstantiateTextLog($"{characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public override void Skill_01()
        {
            var damageOut = (defenseStat + Random.Range(-3, 3)) * (100 - PlayerManager.instance.playerCharacter.attackStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.playerCharacter.characterName, damageOut);
            var atkStat = attackStat;
            var defStat = defenseStat;
            defenseStat = atkStat;
            attackStat = defStat;
            LogManager.instance.InstantiateTextLog($"{characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
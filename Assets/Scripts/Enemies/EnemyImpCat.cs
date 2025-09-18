using Managers;
using UI;
using UnityEngine;

namespace Enemies
{
    public class EnemyImpCat : Enemy
    {
        public override void Attack()
        {
            var damageOut = (attackStat + Random.Range(-3, 3)) * (100 - PlayerManager.instance.player.defenseStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.player.characterName, damageOut);
            var atkStat = attackStat;
            var defStat = defenseStat;
            attackStat = defStat;
            defenseStat = atkStat;
            LogManager.instance.InstantiateTextLog($"{characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }

        public override void Skill_01()
        {
            var damageOut = (defenseStat + Random.Range(-3, 3)) * (100 - PlayerManager.instance.player.attackStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(characterName, PlayerManager.instance.player.characterName, damageOut);
            var atkStat = attackStat;
            var defStat = defenseStat;
            defenseStat = atkStat;
            attackStat = defStat;
            LogManager.instance.InstantiateTextLog($"{characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
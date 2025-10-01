using Managers;
using UI;
using UnityEngine;

namespace Skills
{
    public class CatScratch : Skill
    {
        public override void UseSkill()
        {
            var damageOut = (user.attackStat + Random.Range(-3, 3)) * (100 - opponentTarget.defenceStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            var atkStat = user.attackStat;
            var defStat = user.defenceStat;
            user.attackStat = defStat;
            user.defenceStat = atkStat;
            LogManager.instance.InstantiateTextLog($"{user.characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
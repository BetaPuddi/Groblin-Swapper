using Managers;
using UI;
using UnityEngine;

namespace Skills
{
    public class ImpHug : Skill
    {
        public override void UseSkill()
        {
            var damageOut = (user.defenceStat + Random.Range(-3, 3)) * (100 - opponentTarget.attackStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            var atkStat = user.attackStat;
            var defStat = user.defenceStat;
            user.defenceStat = atkStat;
            user.attackStat = defStat;
            LogManager.instance.InstantiateTextLog($"{user.characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
using Managers;
using UI;
using UnityEngine;

namespace Skills
{
    public class ImpHug : Skill
    {
        public override void UseSkill()
        {
            var damageOut = (user.enduranceStat + Random.Range(-3, 3)) * (100 - opponentTarget.strengthStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            var atkStat = user.strengthStat;
            var defStat = user.enduranceStat;
            user.enduranceStat = atkStat;
            user.strengthStat = defStat;
            LogManager.instance.InstantiateTextLog($"{user.characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
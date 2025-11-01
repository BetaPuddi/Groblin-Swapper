using Managers;
using UI;
using UnityEngine;

namespace Skills
{
    public class CatScratch : Skill
    {
        public override void UseSkill()
        {
            var damageOut = (user.strengthStat + Random.Range(-3, 3)) * (100 - opponentTarget.enduranceStat) / 100;
            PlayerManager.instance.PlayerTakeDamage(damageOut);
            LogManager.instance.InstantiateDamageLog(user.characterName, opponentTarget.characterName, damageOut);
            var atkStat = user.strengthStat;
            var endStat = user.enduranceStat;
            user.strengthStat = endStat;
            user.enduranceStat = atkStat;
            LogManager.instance.InstantiateTextLog($"{user.characterName} swapped their stats!");
            EnemyInfoPanel.instance.UpdateEnemyInfo();
        }
    }
}
using Enums;
using Managers;
using UnityEngine;

namespace Passives
{
    public class PassiveBase : MonoBehaviour
    {
        public string passiveName;
        public bool isTriggeredEffect;
        public EPassiveTypes passiveType;
        public EExecutionOrder executionOrder;

        public virtual void TriggerEffect()
        {
            PlayerManager.instance.playerCharacter.TakeDamage(100);
            LogManager.instance.InstantiateTextLog("Passive effect worked?");
        }
    }
}

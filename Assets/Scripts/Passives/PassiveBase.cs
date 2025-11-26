using Character;
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

        public virtual void TriggerEffect(CharacterBase user, CharacterBase opponent)
        {
            LogManager.instance.InstantiateTextLog("Passive effect worked");
        }

        public virtual void ApplyConstantEffect(CharacterBase user)
        {
            LogManager.instance.InstantiateTextLog("Constant effect applied");
        }

        public virtual void RemoveConstantEffect(CharacterBase user)
        {
            LogManager.instance.InstantiateTextLog("Constant effect removed");
        }
    }
}

using Character;
using UnityEngine;

namespace TemporaryEffects
{
    public class TemporaryEffect : MonoBehaviour
    {
        public string tempEffectName;
        public float turnsRemaining;
        public bool isStackable;
        public bool isRefreshable;
        public CharacterBase character;

        public virtual void ApplyTemporaryEffect(CharacterBase user, CharacterBase opponent)
        {
            print("Temporary effect applied.");
        }

        public virtual void RemoveTemporaryEffect(CharacterBase user, CharacterBase opponent)
        {
            print("Temporary effect removed.");
        }
    }
}
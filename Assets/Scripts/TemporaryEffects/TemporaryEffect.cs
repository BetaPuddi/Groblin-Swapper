using System;
using Character;
using UnityEngine;

namespace TemporaryEffects
{
    [Serializable]
    public class TemporaryEffect
    {
        //TODO: try non-mono

        public string tempEffectName;
        public float turnsRemaining;
        public bool isStackable;
        public bool isRefreshable;
        public CharacterBase character;

        public TemporaryEffect(string effectName, float turns, bool stackable, bool refreshable)
        {
            tempEffectName = effectName;
            turnsRemaining = turns;
            isStackable = stackable;
            isRefreshable = refreshable;
        }

        public virtual void ApplyTemporaryEffect(CharacterBase user, CharacterBase opponent)
        {
            //print("Temporary effect applied.");
        }

        public virtual void RemoveTemporaryEffect(CharacterBase user, CharacterBase opponent)
        {
            //print("Temporary effect removed.");
        }
    }
}
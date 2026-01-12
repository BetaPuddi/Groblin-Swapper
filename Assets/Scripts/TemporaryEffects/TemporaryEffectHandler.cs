using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

namespace TemporaryEffects
{
    public class TemporaryEffectHandler : MonoBehaviour
    {
        public CharacterBase user;
        public CharacterBase opponent;

        public List<TemporaryEffect> temporaryEffects;

        public void AddTemporaryEffect(TemporaryEffect effectToAdd)
        {
            if (effectToAdd.isRefreshable && temporaryEffects.Any(i => i.tempEffectName == effectToAdd.tempEffectName))
            {
                var effectIndex = temporaryEffects.FindIndex(i => i.tempEffectName == effectToAdd.tempEffectName);
                temporaryEffects[effectIndex].turnsRemaining = effectToAdd.turnsRemaining;
            }
            else
            {
                temporaryEffects.Add(effectToAdd);
                temporaryEffects[temporaryEffects.Count - 1].ApplyTemporaryEffect(user, opponent);
            }

            print(temporaryEffects[temporaryEffects.Count - 1].turnsRemaining.ToString());
        }

        public void RemoveTemporaryEffect(TemporaryEffect effectToRemove)
        {
            effectToRemove.RemoveTemporaryEffect(user, opponent);
        }

        public void ClearAllTemporaryEffects()
        {
            for (int i = 0; i < temporaryEffects.Count; i++)
            {
                temporaryEffects[i].RemoveTemporaryEffect(user, opponent);
                temporaryEffects.RemoveAt(i);
            }
        }

        public void DecrementTurnsRemaining()
        {
            for (int i = 0; i < temporaryEffects.Count; i++)
            {
                temporaryEffects[i].turnsRemaining--;
                if (temporaryEffects[i].turnsRemaining <= 0)
                {
                    RemoveTemporaryEffect(temporaryEffects[i]);
                    temporaryEffects.RemoveAt(i);
                }
            }
        }
    }
}
using Character;
using UnityEngine;

namespace TemporaryEffects
{
    public class TemporaryEnduranceEffect : TemporaryEffect
    {
        public float value;

        public TemporaryEnduranceEffect(string effectName, float turns, bool stackable, bool refreshable, float value) : base(effectName, turns, stackable, refreshable)
        {
            this.value = value;
        }

        public void AdjustValue(float newValue)
        {
            value = newValue;
        }

        public void AdjustTurns(float newTurnValue)
        {
            turnsRemaining += newTurnValue;
        }

        public override void ApplyTemporaryEffect(CharacterBase user, CharacterBase opponent)
        {
            user.AdjustEndurance(value);
        }

        public override void RemoveTemporaryEffect(CharacterBase user, CharacterBase opponent)
        {
            user.AdjustEndurance(-value);
        }
    }
}
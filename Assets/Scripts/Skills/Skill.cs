using System;
using Character;
using UnityEngine;

namespace Skills
{
    public abstract class Skill : MonoBehaviour
    {
        public string skillName;
        public CharacterBase user;
        public CharacterBase opponentTarget;

        public abstract void UseSkill();

        public virtual void SetTarget(CharacterBase self, CharacterBase opponent)
        {
            user = self;
            opponentTarget = opponent;
        }

        public virtual void ApplyTemporaryEffect()
        {
            print("No effect to apply.");
        }
    }
}
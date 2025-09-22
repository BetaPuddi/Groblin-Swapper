using System;
using Character;
using UnityEngine;

namespace Skills
{
    public abstract class Skill : MonoBehaviour
    {
        public string skillName;
        public CharacterBase selfTarget;
        public CharacterBase opponentTarget;

        public abstract void UseSkill();

        public virtual void SetTarget(CharacterBase self, CharacterBase opponent)
        {
            selfTarget = self;
            opponentTarget = opponent;
        }
    }
}
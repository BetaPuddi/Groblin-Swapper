using System.Collections.Generic;
using Skills;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Skill Set", menuName = "Skill Sets/New Skill Set", order = 0)]
    public class SkillSet : ScriptableObject
    {
        public List<Skill> skillList;
    }
}
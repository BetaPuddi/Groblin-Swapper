using UnityEngine;

namespace Skills
{
    public abstract class Skill : MonoBehaviour
    {
        public string skillName;
        public GameObject selfTarget;
        public GameObject opponentTarget;

        public abstract void UseSkill();

    }
}
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Stats/Character Stats", order = 1, fileName = "New Character Stats")]
    public class CharacterBaseStats : ScriptableObject
    {
        public Sprite icon;
        [FormerlySerializedAs("enemyName")] public string characterName;
        public float maxHealth;
        public float attack;
        public float defense;
    }
}
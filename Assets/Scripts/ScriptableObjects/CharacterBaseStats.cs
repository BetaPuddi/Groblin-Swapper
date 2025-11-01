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
        [FormerlySerializedAs("attack")] public float strength;
        [FormerlySerializedAs("defence")] [FormerlySerializedAs("defense")] public float endurance;
        public int maxItemUses;
    }
}
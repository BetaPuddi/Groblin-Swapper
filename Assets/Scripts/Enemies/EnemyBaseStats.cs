using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Stats/Enemy Stats", order = 1, fileName = "New Enemy Stats")]
    public class EnemyBaseStats : ScriptableObject
    {
        public Sprite icon;
        public string enemyName;
        public float maxHealth;
        public float attack;
        public float defense;
    }
}
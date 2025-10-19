using Character;
using Enemies;
using Managers;
using UnityEngine;

namespace Encounters
{
    [CreateAssetMenu(menuName = "Encounters/New Single Enemy Encounter", order = 1, fileName = "NewSingleEnemyEncounter")]
    public class SingleEnemy : Encounter
    {
        public CharacterDataHolder[] enemyData;
        private CharacterDataHolder selectedEnemy;

        private void SelectEnemyToFight()
        {
            selectedEnemy = enemyData[Random.Range(0, enemyData.Length)];
        }

        public override void StartEncounter()
        {
            SelectEnemyToFight();
            GameManager.instance.UpdateGameState(1);
            EnemyManager.instance.SpawnNewEnemy(selectedEnemy);
        }
    }
}
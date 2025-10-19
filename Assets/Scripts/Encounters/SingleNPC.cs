using Managers;
using NPCs;
using UnityEngine;

namespace Encounters
{
    [CreateAssetMenu(menuName = "Encounters/New Single NPC Encounter", order = 1, fileName = "NewSingleNPCEncounter")]
    public class SingleNPC : Encounter
    {
        public NPC[] NPCArray;
        public NPC selectedNPC;

        public void SelectNPC()
        {
            selectedNPC = NPCArray[Random.Range(0, NPCArray.Length)];
        }

        public override void StartEncounter()
        {
            SelectNPC();
            GameManager.instance.UpdateGameState(2);
            NPCManager.instance.SpawnNewNPC(selectedNPC);
        }
    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using NPCs;

namespace Managers
{
    public class NPCManager : MonoBehaviour
    {
        public static NPCManager instance;

        public NPC[] npcArray;
        public NPC currentNpc;

        private void Awake()
        {
            if (instance  == null)
            {
                instance = this;
            }
        }

        public void SpawnNewNPC()
        {
            currentNpc = npcArray[Random.Range(0, npcArray.Length)];
            currentNpc.InitialiseNPC();
            NPCInfoPanel.instance.UpdateNPCInfo();
        }

        public void SwapButton()
        {
            currentNpc.Swap();
        }
    }
}
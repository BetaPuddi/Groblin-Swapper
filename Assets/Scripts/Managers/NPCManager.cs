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

        public void SpawnNewNPC(NPC selectedNPC)
        {
            currentNpc = selectedNPC;
            currentNpc.InitialiseNPC();
            NPCInfoPanel.instance.UpdateNPCInfo();
        }

        public void SwapButton()
        {
            currentNpc.Swap();
        }
    }
}
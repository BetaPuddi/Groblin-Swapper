using UnityEngine;

namespace NPCs
{
    public abstract class NPC : MonoBehaviour
    {
        public GameObject[] swapTargets;
        public GameObject thingToSwap;
        public string npcName;
        public Sprite icon;

        public abstract void Swap();

        public abstract void Interact();

        public virtual void InitialiseNPC()
        {
            NewSwapTarget();
            Introduction();
        }

        public abstract void NewSwapTarget();

        public abstract void Introduction();
    }
}
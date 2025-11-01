using Managers;
using ScriptableObjects;
using UnityEngine;
using Weapons;

namespace NPCs
{
    public class InventorySwapper : NPC
    {
        public InventoryData[] inventorySwapTargets;
        public InventoryData inventoryToSwap;

        public override void Swap()
        {
            var newInventory = inventoryToSwap;
            PlayerManager.instance.SwapInventory(newInventory);
            var text = "You accept the swap.";
            LogManager.instance.InstantiateTextLog(text);
            DungeonManager.instance.RoomEncounterCleared();
        }

        public override void Interact()
        {
            throw new System.NotImplementedException();
        }

        public override void NewSwapTarget()
        {
            inventoryToSwap = inventorySwapTargets[Random.Range(0, swapTargets.Length)];
        }

        public override void Introduction()
        {
            var text =
                $"{npcName} appears and offers to swap your inventory with {inventoryToSwap.inventoryName}'s!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
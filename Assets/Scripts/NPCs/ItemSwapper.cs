using Enums;
using Items;
using Managers;
using UnityEngine;

namespace NPCs
{
    public class ItemSwapper : NPC
    {
        public override void Swap()
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                var item = thingToSwap.GetComponent<Item>();
                PlayerManager.instance.SwapItem(item);
                GameManager.instance._gameState = EGameStates.Advance;
                var text = "You accept the swap.";
                LogManager.instance.InstantiateTextLog(text);
            }
        }

        public override void Interact()
        {
            throw new System.NotImplementedException();
        }

        public override void NewSwapTarget()
        {
            thingToSwap = swapTargets[Random.Range(0, swapTargets.Length)];
        }

        public override void Introduction()
        {
            var text =
                $"{npcName} appears and offers to swap your item for {thingToSwap.GetComponent<Item>().itemName}!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
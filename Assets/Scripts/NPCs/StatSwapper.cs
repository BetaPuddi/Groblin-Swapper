using Character;
using Enums;
using Managers;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NPCs
{
    public class StatSwapper : NPC
    {
        public override void Swap()
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                var statsToSwap = thingToSwap.GetComponent<CharacterDataHolder>().stats;
                PlayerManager.instance.SwapPlayerStats(statsToSwap);
                GameManager.instance._gameState = EGameStates.Advance;
                var text = "You accept the swap.";
                LogManager.instance.InstantiateTextLog(text);
            }
        }

        public override void Interact()
        {
            throw new System.NotImplementedException();
        }

        // public override void InitialiseNPC()
        // {
        //     NewSwapTarget();
        // }

        public override void NewSwapTarget()
        {
            thingToSwap = swapTargets[Random.Range(0, swapTargets.Length)];
        }

        public override void Introduction()
        {
            var text =
                $"{npcName} appears and offers to swap your stats with {thingToSwap.GetComponent<CharacterDataHolder>().stats.characterName}!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
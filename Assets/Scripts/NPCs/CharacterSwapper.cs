using Character;
using Enums;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NPCs
{
    public class CharacterSwapper : NPC
    {
        public override void Swap()
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                var player = thingToSwap.GetComponent<Player>();
                PlayerManager.instance.SwapPlayer(player);
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
                $"{npcName} appears and offers to swap your form with {thingToSwap.GetComponent<Player>().playerName}!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
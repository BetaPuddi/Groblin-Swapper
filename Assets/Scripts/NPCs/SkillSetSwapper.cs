using Enums;
using Managers;
using Player;
using UnityEngine;

namespace NPCs
{
    public class SkillSetSwapper : NPC
    {
        public override void Swap()
        {
            if (GameManager.instance._gameState == EGameStates.NPC)
            {
                var skillsToSwap = thingToSwap.GetComponent<PlayerCharacter>().currentSkills;
                PlayerManager.instance.SwapPlayerSkillSet(skillsToSwap);
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
                $"{npcName} appears and offers to swap your skills with {thingToSwap.GetComponent<PlayerCharacter>().characterName}!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
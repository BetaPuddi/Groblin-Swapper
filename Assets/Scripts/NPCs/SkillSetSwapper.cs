using Character;
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
                var skillsToSwap = thingToSwap.GetComponent<CharacterDataHolder>().skillSet.skillList;
                PlayerManager.instance.SwapPlayerSkillSet(skillsToSwap);
                var text = "You accept the swap.";
                LogManager.instance.InstantiateTextLog(text);
                DungeonManager.instance.RoomEncounterCleared();
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
                $"{npcName} appears and offers to swap your skills with {thingToSwap.GetComponent<CharacterDataHolder>().stats.characterName}!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
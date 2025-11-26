using Equipment;
using Managers;
using ScriptableObjects;
using UnityEngine;
using Weapons;

namespace NPCs
{
    public class WeaponSwapper : NPC
    {
        public override void Swap()
        {
            var weaponToSwap = thingToSwap.GetComponent<WeaponBase>();
            PlayerManager.instance.SwapWeapon(weaponToSwap);
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
            thingToSwap = swapTargets[Random.Range(0, swapTargets.Length)];
        }

        public override void Introduction()
        {
            var text =
                $"{npcName} appears and offers to swap your weapon with {thingToSwap.GetComponent<WeaponBase>().weaponName}!";
            LogManager.instance.InstantiateTextLog(text);
        }
    }
}
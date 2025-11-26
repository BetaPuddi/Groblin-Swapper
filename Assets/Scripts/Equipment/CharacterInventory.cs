using System.Linq;
using Character;
using Passives;
using ScriptableObjects;
using UnityEngine;

namespace Equipment
{
    public class CharacterInventory : MonoBehaviour
    {
        public InventoryData inventoryData;

        public EquipmentHead headSlot;
        public EquipmentChest chestSlot;
        public EquipmentLegs legSlot;
        public EquipmentArms armSlot;

        public CharacterBase user;

        public void SetInventoryData(InventoryData dataToSet)
        {
            inventoryData = dataToSet;
            EquipInventory();
        }

        public void EquipInventory()
        {
            if (inventoryData.headSlot != null)
            {
                EquipHead();
            }

            if (inventoryData.chestSlot != null)
            {
                EquipChest();
            }

            if (inventoryData.legSlot != null)
            {
                EquipLegs();
            }

            if (inventoryData.armSlot != null)
            {
                EquipArms();
            }
        }

        private void EquipArms()
        {
            if (armSlot != null && armSlot.passiveEffects.Length > 0)
            {
                foreach (var passive in armSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
                {
                    passive.RemoveConstantEffect(user);
                }
            }

            armSlot = inventoryData.armSlot;

            foreach (var passive in armSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
            {
                passive.ApplyConstantEffect(user);
            }
        }

        private void EquipLegs()
        {
            if (legSlot != null && legSlot.passiveEffects.Length > 0)
            {
                foreach (var passive in legSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
                {
                    passive.RemoveConstantEffect(user);
                }
            }

            legSlot = inventoryData.legSlot;

            foreach (var passive in legSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
            {
                passive.ApplyConstantEffect(user);
            }
        }

        public void EquipHead()
        {
            if (headSlot != null && inventoryData.headSlot.passiveEffects.Length > 0)
            {
                foreach (var equipmentPassive in headSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
                {
                    equipmentPassive.RemoveConstantEffect(user);
                }
            }

            headSlot = inventoryData.headSlot;

            foreach (var passive in headSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
            {
                passive.ApplyConstantEffect(user);
            }
        }

        public void EquipChest()
        {
            if (chestSlot != null && inventoryData.chestSlot.passiveEffects.Length > 0)
            {
                foreach (var passive in chestSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
                {
                    passive.RemoveConstantEffect(user);
                }
            }

            chestSlot = inventoryData.chestSlot;

            foreach (var passive in chestSlot.passiveEffects.Where(passive => !passive.isTriggeredEffect))
            {
                passive.ApplyConstantEffect(user);
            }
        }
    }
}
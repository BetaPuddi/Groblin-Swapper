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

        public void SetInventoryData(InventoryData dataToSet)
        {
            inventoryData = dataToSet;
            EquipInventory();
        }

        public void EquipInventory()
        {
            EquipHead();
            EquipChest();
            EquipLegs();
            EquipArms();
        }

        private void EquipArms()
        {
            armSlot = inventoryData.armSlot;
        }

        private void EquipLegs()
        {
            legSlot = inventoryData.legSlot;
        }

        public void EquipHead()
        {
            headSlot = inventoryData.headSlot;
        }

        public void EquipChest()
        {
            chestSlot = inventoryData.chestSlot;
        }
    }
}
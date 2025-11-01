using Equipment;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Equipment/New Inventory", order = 0)]
    public class InventoryData : ScriptableObject
    {
        public string inventoryName;
        public EquipmentHead headSlot;
        public EquipmentChest chestSlot;
        public EquipmentLegs legSlot;
        public EquipmentArms armSlot;
    }
}
using Enums;
using Passives;
using UnityEngine;

namespace Equipment
{
    public class EquipmentBase : MonoBehaviour
    {
        public string equipmentName;
        public EEquipmentTypes equipmentType;
        public float defenceValue;
        public PassiveBase[] passiveEffects;


    }
}